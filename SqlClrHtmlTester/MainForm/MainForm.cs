using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Configuration;
using Utilities;
using System.Text;

namespace SqlClrHtmlTester
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class MainForm : Form
    {
        MyFormState state = new MyFormState();
        string connectionString = "";

        Dictionary<string, string> mystyle = new Dictionary<string, string>();
        Evaluator se = new Evaluator("", "", new string[] { Directory.GetCurrentDirectory() + "\\Microsoft.Office.Interop.Excel.dll" });
        DataSet ds = null;
        string path = "";
        string errorMessage = string.Empty;
        object compObj = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private List<KeyValuePair<int, string>> listConnection = new List<KeyValuePair<int, string>>();
        Security.TesterEncryptSupport.Simple3Des wrapper = new Security.TesterEncryptSupport.Simple3Des(ConfigurationManager.AppSettings["SqlServerCentral"]);
        private const string HELPERSPLITTER = "HELPER";

        #region Form loader

        private void Form1_Load(object sender, System.EventArgs e)
        {

            //Determine is load appdomain button is visible
            btnLoadAppDomain.Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showLoadAppDomainButton"]);
            btnUnloadAppDomain.Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showUnLoadAppDomainButton"]);
           
            //Create output directory if not exists 
            if (Directory.Exists(ConfigurationManager.AppSettings["outputPath"]) == false)
            {
                try
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["outputPath"]);
                }
                catch (Exception ex)
                {
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    else
                        MessageBox.Show("Unable to create default directory.Please change path in app.config " + ex.Message);
                }
                
            }
            string codeToCompile = ConfigurationManager.AppSettings["codeToCompile"];


            compObj= se.Compile(codeToCompile.ToString().Trim(), true, "SqlServerCentral", ref errorMessage);
            //Fill styles 
            FillStyles();

            //Restore user inputs
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["saveInput"]) && File.Exists(ConfigurationManager.AppSettings["fileToSaveInput"]))
            {
                state = Helper.loadConfig();
                if (state != null)
                {
                    try
                    {
                        txtQuery.Text = state.QueryText;
                        txtParams.Text = state.ParamText;
                        txtCaption.Text = state.CaptionText;
                        txtFooter.Text = state.FooterText;
                        if (state.StyleText != null)
                            cmbStyle.SelectedIndex = cmbStyle.FindStringExact(state.StyleText);
                        txtServer.Text = state.ServerText;
                        if (cmbAuth.SelectedIndex != -1)
                            cmbAuth.SelectedIndex = cmbAuth.FindStringExact(state.AuthText);

                        txtUserName.Text = state.UserNameText;
                        try
                        {
                            txtPassword.Text = wrapper.DecryptData(state.PasswordText);
                        }
                        catch (Exception ex)
                        {
                            if (Debugger.IsAttached)
                            {
                                MessageBox.Show("Exception :" + ex.Message);
                                Debugger.Break();
                            }

                        }
                        if (txtUserName.Text.Trim().Equals(string.Empty) && txtPassword.Text.Trim().Equals(string.Empty))
                        {
                            cmbAuth.SelectedIndex = 0;
                        }
                        //bind database information
                        BindDataBases();
                        cmbDatabase.SelectedIndex = cmbDatabase.FindStringExact(state.DataBaseText);

                        cmbRotate.SelectedIndex = cmbRotate.FindStringExact(state.RotateText);
                        if (cmbRotate.SelectedIndex == -1)
                            cmbRotate.SelectedIndex = 0;
                        txtRCO.Value = Convert.ToInt32(state.RcoText);
                        txtCustomStyle.Text = state.CustomStyleText;
                        if (state.ListBoxText != null)
                            makeListConnection(state.ListBoxText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
                    }
                    catch (Exception ex)
                    {
                        if (Debugger.IsAttached)
                            Debugger.Break();
                        else
                            MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                //If we do not want saving inputs, defaults are blue style and windows auth
                cmbStyle.SelectedIndex = 1;
                cmbAuth.SelectedIndex = 0;
                cmbRotate.SelectedIndex = 1;
            }
            //put focus on this control
            if (listBoxConnection.Items.Count > 0)
            {
                listBoxConnection.SelectedIndex = 0;
                BindAssemblyList("SimpleTalk.SQLCLR.SendMail");
            }
                
            
            txtServer.Select();

        }
        #endregion

        #region Styles helper
        private void FillStyles()
        {
            mystyle.Add("Custom style", "ST_CUSTOM");
            mystyle.Add("Blue style(default)", "ST_BLUE");
            mystyle.Add("Black style", "ST_BLACK");
            mystyle.Add("Red style", "ST_RED");
            mystyle.Add("Rose style", "ST_ROSE");
            mystyle.Add("Green style", "ST_GREEN");
            mystyle.Add("Brown style", "ST_BROWN");
            mystyle.Add("Horisontal minimal", "ST_HORISONTAL");
            mystyle.Add("No style", "ST_NO_STYLE");
            mystyle.Add("Simple style", "ST_SIMPLE");
            
            foreach (string s in mystyle.Keys)
                cmbStyle.Items.Add(s);
        }
        private string MapStyleToCode(string styleText)
        {
            if (cmbStyle.SelectedIndex == 0)
            {
                return txtCustomStyle.Text.Replace("'","''");
            }
            return mystyle[styleText];
        }
        private string MapCodeToStyle(string styleCode)
        {
            return mystyle.FirstOrDefault(x => x.Value == styleCode).Key;
        }

        #endregion

        #region Get HTML
        private void btnGetIt_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Equals(string.Empty))
            {
                txtServer.Focus();
                MessageBox.Show("Please enter valid server name");
                return;
            }
            if (cmbAuth.SelectedIndex == -1)
            {
                cmbAuth.Focus();
                MessageBox.Show("Please choose Authentication type!");
                return;
            }
            if (cmbDatabase.SelectedIndex == -1)
            {
                cmbDatabase.Focus();
                MessageBox.Show("Please choose database");
                return;
            }
            if (listBoxConnection.Items.Count == 0)
            {
                btnTestConnection.Focus();
                MessageBox.Show("Please choose 'Test connection'");
                return;
            }
            if (txtQuery.Text.Trim().Equals(String.Empty))
            {
                txtQuery.Select();
                MessageBox.Show("Please enter query!");
                return;
            }
            btnGetHtml.Enabled = false;

            if (checkInstallation() == false)
            {
                MessageBox.Show("Your connection does not point to SQLCLR assembly installation!");
                tabControl1.SelectedTab = tabConnect;
                btnGetHtml.Enabled = true;
                return;
            }
            if (cmbStyle.SelectedIndex == -1)
            {
                btnGetHtml.Enabled = true;
                MessageBox.Show("Style should be selected!");
                cmbStyle.Select();
                return;
            }
            if (cmbStyle.SelectedIndex == 0 && txtCustomStyle.Text.Trim().Equals(string.Empty))
            {
                btnGetHtml.Enabled = true;
                cmbStyle.Select();
                txtCustomStyle.Focus();
                MessageBox.Show("Please write css style sheet");
                return;
            }

            connectionString = DataAccess.GetConnectionString(txtServer.Text, cmbDatabase.Text, cmbAuth.SelectedIndex == 0 ? true : false, txtUserName.Text, txtPassword.Text);
            string result = DataAccess.GetHtml(connectionString, txtQuery.Text, txtParams.Text, txtCaption.Text, txtFooter.Text, MapStyleToCode(cmbStyle.Text), cmbRotate.SelectedIndex.ToString(), txtRCO.Value.ToString());

            tabControl1.SelectedTab = tabResult;
            if (chkAppend.Checked)
                webBrowser1.DocumentText = DataAccess.ConCatHtml(connectionString, webBrowser1.DocumentText, result);
            else
                webBrowser1.DocumentText = result;

            webBrowser1.Visible = true;
            webBrowser1.Show();
         
        }

        #endregion

        #region Get T-SQL
        private void btnGetTSQL_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Equals(string.Empty))
            {
                txtServer.Focus();
                MessageBox.Show("Please enter valid server name");
                return;
            }
            if (cmbAuth.SelectedIndex == -1)
            {
                cmbAuth.Focus();
                MessageBox.Show("Please choose Authentication type!");
                return;
            }
            if (cmbDatabase.SelectedIndex == -1)
            {
                cmbDatabase.Focus();
                MessageBox.Show("Please choose database");
                return;
            }
            if (listBoxConnection.Items.Count == 0)
            {
                btnTestConnection.Focus();
                MessageBox.Show("Please choose 'Test connection'");
                return;
            }
            btnGetTSql.Enabled = false;
            if (checkInstallation() == false)
            {
                MessageBox.Show("Your connection does not point to SQLCLR assembly installation!");
                tabControl1.SelectedTab = tabConnect;
                btnGetTSql.Enabled = true;
                return;
            }
            if (cmbStyle.SelectedIndex == -1)
            {
                btnGetTSql.Enabled = true;
                MessageBox.Show("Style should be selected!");
                cmbStyle.Select();
                return;
            }
            if (cmbStyle.SelectedIndex == 0 && txtCustomStyle.Text.Trim().Equals(string.Empty))
            {
                btnGetTSql.Enabled = true;
                cmbStyle.Select();
                txtCustomStyle.Focus();
                MessageBox.Show("Please write css style sheet!");
                return;
            }
            if (txtQuery.Text.Trim().Equals(String.Empty))
            {
                btnGetTSql.Enabled = true;
                txtQuery.Select();
                MessageBox.Show("Please enter query!");
                return;

            }
            string result = String.Format(@"SELECT EMAIL.QueryToHtml(
'{0}', --query
'{1}', --parameters
'{2}', --caption
'{3}', --footer
 {4},  --rotation mode
 {5},  --rco
'{6}'  --css
);SELECT EMAIL.CleanMemory();", 
txtQuery.Text.Replace("'","''"),
txtParams.Text.Replace("'","''"),
txtCaption.Text,
txtFooter.Text, 
cmbRotate.SelectedIndex,
txtRCO.Value,
MapStyleToCode(cmbStyle.Text)
);

            Clipboard.SetText(result);
            pn.Image = SqlClrHtmlTester.Properties.Resources.sql_icon;
            string fileName = ConfigurationManager.AppSettings["outputPath"] + txtCaption.Text.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            path = fileName;
            File.WriteAllText(fileName, result, Encoding.UTF8);
            pn.Popup();

            btnGetTSql.Enabled = true;                  


        }

        #endregion



        #region Save configuration
        /// <summary>
        /// Write inputs 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["saveInput"]))
                Helper.writeConfig(state, txtQuery.Text, txtParams.Text, cmbStyle.Text, txtServer.Text, txtCaption.Text, txtFooter.Text, cmbAuth.Text, txtUserName.Text, wrapper.EncryptData(txtPassword.Text), cmbDatabase.Text, cmbRotate.Text, txtRCO.Value.ToString(), txtCustomStyle.Text,savelstConnection());
        }

        #endregion

        #region Bind database information

        private string buildConnString(string serverName, string databaseName, string userName, string password, bool IsWinAuth)
        {
            string connectionString = "Data Source=" + serverName + ";Integrated Security=SSPI;Initial Catalog=" + databaseName;
            if (IsWinAuth == false)
                connectionString = connectionString = "Data Source=" + serverName + ";User Id=" + userName + "; password= " + password + ";Initial Catalog=" + databaseName;
            return connectionString;
        }

        private void cmbAuth_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbAuth.SelectedItem != null)
            {
                if (isError)
                    isError = false;

                if (cmbAuth.SelectedIndex == 0)
                {
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtUserName.Enabled = false;
                    txtPassword.Enabled = false;
                }
                else if (cmbAuth.SelectedIndex == 1)
                {
                    txtUserName.Enabled = true;
                    txtPassword.Enabled = true;
                    txtUserName.Select();
                }
            }
        }


        private bool isError = false;
        private void cmbDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbAuth.SelectedIndex != 0 && (txtUserName.Text.Trim().Equals(string.Empty) || txtPassword.Text.Trim().Equals(string.Empty)))
            {
                MessageBox.Show("Please enter userName and password");
                if (isError)
                    isError = false;
                return;
            }
            if (isError == false )
            {
                BindDataBases();
            }
        }

        private void BindDataBases()
        {
            string error = "";
            cmbDatabase.Items.Clear();
            DataSet ds = DataAccess.GetDataSet(DataAccess.GetConnectionString(txtServer.Text, "master", cmbAuth.SelectedIndex == 0 ? true : false, txtUserName.Text, txtPassword.Text), @"SELECT name 
                                                                FROM sys.databases
                                                                WHERE state = 0 
                                                                    AND is_read_only = 0 
                                                                ORDER BY name", null, out error);
            if (error.Equals(string.Empty) == false)
            {
                isError = true;
                MessageBox.Show("Error binding database information : " + error);
                ds = null;
            }
            else
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                    cmbDatabase.Items.Add(r["Name"].ToString());
                ds = null;

            }

        }
        #endregion

        #region ListBox

        private void lstConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fill with information about database,server etc.
            //Put item on the top - sync with collection
            if (listBoxConnection.SelectedIndex == 0)
                return;
            if (listBoxConnection.SelectedItem == null)
                return;

            int index = listBoxConnection.SelectedIndex;
            string s = listConnection[index].Value;
            KeyValuePair<int,string> kp = listConnection[index];

            listConnection.RemoveAt(index);
            listConnection.Insert(0, kp);

            listBoxConnection.Items.RemoveAt(index);
            listBoxConnection.Items.Insert(0, drawItem(s));
            listBoxConnection.SelectedIndex = 0;

            string[] splitter = s.Split('@');
            string[] splitter2 = splitter[1].Split(new string[] { HELPERSPLITTER }, StringSplitOptions.None);

            txtServer.Text = splitter2[0].Substring(0, splitter2[0].IndexOf("("));
            if (splitter2[1].Equals(string.Empty))
            {
                cmbAuth.Text = cmbAuth.Items[0].ToString();
                txtPassword.Text = string.Empty;
                txtUserName.Text = string.Empty;
            }
            else
            {
                cmbAuth.Text = cmbAuth.Items[1].ToString();
                txtPassword.Text = splitter2[1];
                txtUserName.Text = splitter2[0].Substring(splitter2[0].IndexOf("(") + 1, splitter2[0].Length - splitter2[0].IndexOf("(") - 2);
            }
            cmbDatabase.Text = splitter[0];

          
            BindAssemblyList("SimpleTalk.SQLCLR.SendMail");
            //labelConnectionInfo.Text = drawItem(s).Replace("\r\n", ".");
            labelConnectionInfo.Text = SetLabel();


        }

        private void makeListConnection(string[] stateList)
        {
            foreach (string s in stateList)
            {
                if (s.Equals(string.Empty))
                    continue;
                string[] splitter = s.Split(new string[] { HELPERSPLITTER }, StringSplitOptions.None);
                string second = wrapper.DecryptData(splitter[1]);
                string result = splitter[0] + HELPERSPLITTER + second;
                int hasher = result.GetHashCode();
                listConnection.Add(new KeyValuePair<int, string>(hasher, result));
                listBoxConnection.Items.Add(drawItem(s));

            }
            //labelConnectionInfo.Text = listBoxConnection.Items[0].ToString().Replace("\r\n", ".");
            labelConnectionInfo.Text = SetLabel();
        }
        private void lstConnections_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
         
            string stringToDraw = listBoxConnection.Items[e.Index].ToString();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor, Color.FromArgb(236, 233, 216));


            e.DrawBackground();

            e.Graphics.DrawString(stringToDraw,
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private string makeListItem(string databaseName, string serverName, string userName, string password)
        {
            return databaseName.ToUpper().Trim() + "@" + serverName.ToUpper().Trim() + "(" + userName.ToUpper().Trim() + ")" + HELPERSPLITTER + password;
        }
        private string drawItem(string itemToDraw)
        {
            string[] splitter = itemToDraw.Split('@');
            return splitter[0] + Environment.NewLine + splitter[1].Split(new string[] { HELPERSPLITTER},StringSplitOptions.None)[0];
        }
        private string savelstConnection()
        {
            string retValue = "";
            foreach (KeyValuePair<int, string> s in listConnection)
            {
                string[] splitter = s.Value.Split(new string[] { HELPERSPLITTER }, StringSplitOptions.None);
                string second = wrapper.EncryptData(splitter[1]);
                string result = splitter[0] + HELPERSPLITTER + second;
                retValue += result + Environment.NewLine;
            }
            return retValue;


            



        }
        #endregion

        #region  Test connection

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please enter server name!");
                return;
            }
            if (cmbAuth.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose authentication type!");
                return;
            }
            if (cmbDatabase.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose database!");
                return;
            }
            btnTestConnection.Enabled = false;
            //if (checkInstallation() == false)
            //    MessageBox.Show("SQLCLR assembly is not installed");
            
            //else
            //{
                string descriptive = makeListItem(cmbDatabase.Text, txtServer.Text, txtUserName.Text, txtPassword.Text);
                int hashCode = descriptive.GetHashCode();
                bool isInList = false;
                foreach (KeyValuePair<int, string> s in listConnection)
                {
                    if (s.Key == hashCode)
                    {
                        isInList = true;
                        break;
                    }
                }

                if (isInList == false)
                {
                    listBoxConnection.Items.Clear();
                    //Add at first position
                    listBoxConnection.Items.Add(drawItem(descriptive));
                    //Add the rest
                    foreach (KeyValuePair<int, string> s in listConnection)
                        listBoxConnection.Items.Add(drawItem(s.Value));
                    //syncronise
                    listConnection.Insert(0, new KeyValuePair<int, string>(hashCode, descriptive));
                    listBoxConnection.SelectedIndex = 0;
                  
                    //BindAssemblyList("SQLCLRReporter");
                    //labelConnectionInfo.Text = listBoxConnection.Items[0].ToString().Replace("\r\n", ".");
                    labelConnectionInfo.Text = SetLabel();
                }
                else
                {
                    
                    //BindAssemblyList("SQLCLRReporter");
                    MessageBox.Show("Everything seems to be OK!");
                }
                    
            //}
            btnTestConnection.Enabled = true;

        }
        private string SetLabel()
        {
            return txtServer.Text.Trim() + "." + cmbDatabase.Text.Trim() + "(" + txtUserName.Text.Trim() + ")";
        }
        private bool checkInstallation()
        {
            bool isOk = false;
            string query = @"SELECT
	(SELECT
			COUNT(*) counter
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'[EMAIL].[QueryToHtml]')
		AND type IN (N'FS'))
	+ (SELECT
			COUNT(*) counter
		FROM SYS.assemblies
		WHERE NAME = 'SimpleTalk.SQLCLR.SendMail')
	ALLTEST";
            int magicNumber = Convert.ToInt16(DataAccess.ExecuteScalar(buildConnString(txtServer.Text, cmbDatabase.Text, txtUserName.Text, txtPassword.Text, cmbAuth.SelectedIndex == 0 ? true : false), query));
            isOk = magicNumber == 2 ? true : false;
            return isOk;
        }

        #endregion


        #region Style
        private void cmbStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbStyle.SelectedItem != null)
            {
                if (cmbStyle.SelectedIndex != 0)
                {
                    txtCustomStyle.Enabled = false;
                    txtCustomStyle.Text = "";
                }
                else
                {
                    txtCustomStyle.Enabled = true;
                }

            }
        }
        #endregion

        #region Custom render of tab control
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs ee)
        {

            Graphics g = ee.Graphics;
            TabPage tp = tabControl1.TabPages[ee.Index];
            Brush br;
            StringFormat sf = new StringFormat();
            RectangleF r = new RectangleF(ee.Bounds.X, (ee.Bounds.Y + 2), (ee.Bounds.Width + 5), (ee.Bounds.Height - 2));
            System.Drawing.Font font = new System.Drawing.Font(tabControl1.Font.FontFamily,tabControl1.Font.Size);
            Brush TabTextBrush = new SolidBrush(Color.Black);
            Brush TabBackBrush = new SolidBrush(Color.FromArgb(236, 233, 216));
            sf.Alignment = StringAlignment.Center;
            string strTitle = tp.Text;
            if ((tabControl1.SelectedIndex == ee.Index))
            {
                br = TabBackBrush;
                g.FillRectangle(br, ee.Bounds);
                br = TabTextBrush;
                g.DrawString(strTitle, font, br, r, sf);
            }
            else
            {
                br = new SolidBrush(Color.White);
                g.FillRectangle(br, ee.Bounds);
                br = new SolidBrush(Color.Black);
                g.DrawString(strTitle, font, br, r, sf);
            }

        }

        #endregion

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnGetHtml.Enabled = true;
            //Refresh assembly information 
            BindAssemblyList("SimpleTalk.SQLCLR.SendMail");


        }

    }
}