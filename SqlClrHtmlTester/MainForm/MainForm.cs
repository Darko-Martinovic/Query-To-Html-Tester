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
using System.Globalization;
using Utilities;
using System.Text;

namespace SqlClrHtmlTester
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class MainForm : Form
    {
        private MyFormState _state = new MyFormState();
        private string _connectionString = "";
        private string _assemblyName = "";

        private readonly Dictionary<string, string> _mystyle = new Dictionary<string, string>();

        private readonly Evaluator _se = new Evaluator("", "",
            new string[] {Directory.GetCurrentDirectory() + "\\Microsoft.Office.Interop.Excel.dll"});


        private DataSet _ds;
        private string _path = "";
        private string _errorMessage = string.Empty;
        private object _compObj = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly List<KeyValuePair<int, string>> _listConnection = new List<KeyValuePair<int, string>>();
        private readonly Security.TesterEncryptSupport.Simple3Des _wrapper = new Security.TesterEncryptSupport.Simple3Des(ConfigurationManager.AppSettings["SqlServerCentral"]);
        private const string Helpersplitter = "HELPER";

        #region Form loader

        private void Form1_Load(object sender, System.EventArgs e)
        {

            //Determine is load appdomain button is visible
            btnLoadAppDomain.Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showLoadAppDomainButton"]);
            btnUnloadAppDomain.Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showUnLoadAppDomainButton"]);
            _assemblyName = ConfigurationManager.AppSettings["assemblyName"];

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
                        MessageBox.Show(
                            $@"Unable to create default directory.Please change path in app.config {ex.Message}");
                }
                
            }
            var codeToCompile = ConfigurationManager.AppSettings["codeToCompile"];


            _compObj= _se.Compile(codeToCompile.Trim(), true, "SqlServerCentral", ref _errorMessage);
            //Fill styles 
            FillStyles();

            //Restore user inputs
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["saveInput"]) && File.Exists(ConfigurationManager.AppSettings["fileToSaveInput"]))
            {
                _state = Helper.loadConfig();
                if (_state != null)
                {
                    try
                    {
                        txtQuery.Text = _state.QueryText;
                        txtParams.Text = _state.ParamText;
                        txtCaption.Text = _state.CaptionText;
                        txtFooter.Text = _state.FooterText;
                        if (_state.StyleText != null)
                            cmbStyle.SelectedIndex = cmbStyle.FindStringExact(_state.StyleText);
                        txtServer.Text = _state.ServerText;
                        if (cmbAuth.SelectedIndex != -1)
                            cmbAuth.SelectedIndex = cmbAuth.FindStringExact(_state.AuthText);

                        txtUserName.Text = _state.UserNameText;
                        try
                        {
                            txtPassword.Text = _wrapper.DecryptData(_state.PasswordText);
                        }
                        catch (Exception ex)
                        {
                            if (Debugger.IsAttached)
                            {
                                MessageBox.Show($@"Exception :{ex.Message}");
                                Debugger.Break();
                            }

                        }
                        if (txtUserName.Text.Trim().Equals(string.Empty) && txtPassword.Text.Trim().Equals(string.Empty))
                        {
                            cmbAuth.SelectedIndex = 0;
                        }
                        //bind database information
                        BindDataBases();
                        cmbDatabase.SelectedIndex = cmbDatabase.FindStringExact(_state.DataBaseText);

                        cmbRotate.SelectedIndex = cmbRotate.FindStringExact(_state.RotateText);
                        if (cmbRotate.SelectedIndex == -1)
                            cmbRotate.SelectedIndex = 0;
                        txtRCO.Value = Convert.ToInt32(_state.RcoText);
                        txtCustomStyle.Text = _state.CustomStyleText;
                        if (_state.ListBoxText != null)
                            MakeListConnection(_state.ListBoxText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
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
                BindAssemblyList(_assemblyName);
            }
                
            
            txtServer.Select();

        }
        #endregion

        #region Styles helper
        private void FillStyles()
        {
            _mystyle.Add("Custom style", "ST_CUSTOM");
            _mystyle.Add("Blue style(default)", "ST_BLUE");
            _mystyle.Add("Black style", "ST_BLACK");
            _mystyle.Add("Red style", "ST_RED");
            _mystyle.Add("Rose style", "ST_ROSE");
            _mystyle.Add("Green style", "ST_GREEN");
            _mystyle.Add("Brown style", "ST_BROWN");
            _mystyle.Add("Horisontal minimal", "ST_HORISONTAL");
            _mystyle.Add("No style", "ST_NO_STYLE");
            _mystyle.Add("Simple style", "ST_SIMPLE");
            
            foreach (var s in _mystyle.Keys)
                cmbStyle.Items.Add(s);
        }
        private string MapStyleToCode(string styleText)
        {
            if (cmbStyle.SelectedIndex == 0)
            {
                return txtCustomStyle.Text.Replace("'","''");
            }
            return _mystyle[styleText];
        }
        private string MapCodeToStyle(string styleCode)
        {
            return _mystyle.FirstOrDefault(x => x.Value == styleCode).Key;
        }

        #endregion

        #region Get HTML
        private void btnGetIt_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Equals(string.Empty))
            {
                txtServer.Focus();
                MessageBox.Show(@"Please enter valid server name", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (cmbAuth.SelectedIndex == -1)
            {
                cmbAuth.Focus();
                MessageBox.Show(@"Please choose Authentication type!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (cmbDatabase.SelectedIndex == -1)
            {
                cmbDatabase.Focus();
                MessageBox.Show(@"Please choose database", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (listBoxConnection.Items.Count == 0)
            {
                btnTestConnection.Focus();
                MessageBox.Show(@"Please choose 'Test connection'",
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (txtQuery.Text.Trim().Equals(String.Empty))
            {
                txtQuery.Select();
                MessageBox.Show(@"Please enter query!",
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            btnGetHtml.Enabled = false;

            if (CheckInstallation() == false)
            {
                MessageBox.Show(@"Your connection does not point to SQLCLR assembly installation!",
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabConnect;
                btnGetHtml.Enabled = true;
                return;
            }
            if (cmbStyle.SelectedIndex == -1)
            {
                btnGetHtml.Enabled = true;
                MessageBox.Show(@"Style should be selected!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                cmbStyle.Select();
                return;
            }
            if (cmbStyle.SelectedIndex == 0 && txtCustomStyle.Text.Trim().Equals(string.Empty))
            {
                btnGetHtml.Enabled = true;
                cmbStyle.Select();
                txtCustomStyle.Focus();
                MessageBox.Show(@"Please write css style sheet", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            _connectionString = DataAccess.GetConnectionString(
                txtServer.Text, 
                cmbDatabase.Text, 
                cmbAuth.SelectedIndex == 0 , 
                txtUserName.Text, 
                txtPassword.Text
                );
            var result = DataAccess.GetHtml(
                _connectionString, 
                txtQuery.Text, 
                txtParams.Text, 
                txtCaption.Text, 
                txtFooter.Text, 
                MapStyleToCode(cmbStyle.Text), 
                cmbRotate.SelectedIndex.ToString(), 
                txtRCO.Value.ToString(CultureInfo.InvariantCulture)
                );

            tabControl1.SelectedTab = tabResult;
            if (chkAppend.Checked)
                webBrowser1.DocumentText = DataAccess.ConCatHtml(_connectionString, webBrowser1.DocumentText, result);
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
                MessageBox.Show(@"Please enter valid server name", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (cmbAuth.SelectedIndex == -1)
            {
                cmbAuth.Focus();
                MessageBox.Show(@"Please choose Authentication type!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (cmbDatabase.SelectedIndex == -1)
            {
                cmbDatabase.Focus();
                MessageBox.Show(@"Please choose database", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (listBoxConnection.Items.Count == 0)
            {
                btnTestConnection.Focus();
                MessageBox.Show(@"Please choose 'Test connection'", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            btnGetTSql.Enabled = false;
            if (CheckInstallation() == false)
            {
                MessageBox.Show(@"Your connection does not point to SQLCLR assembly installation!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabConnect;
                btnGetTSql.Enabled = true;
                return;
            }
            if (cmbStyle.SelectedIndex == -1)
            {
                btnGetTSql.Enabled = true;
                MessageBox.Show(@"Style should be selected!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                cmbStyle.Select();
                return;
            }
            if (cmbStyle.SelectedIndex == 0 && txtCustomStyle.Text.Trim().Equals(string.Empty))
            {
                btnGetTSql.Enabled = true;
                cmbStyle.Select();
                txtCustomStyle.Focus();
                MessageBox.Show(@"Please write css style sheet!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (txtQuery.Text.Trim().Equals(String.Empty))
            {
                btnGetTSql.Enabled = true;
                txtQuery.Select();
                MessageBox.Show(@"Please enter query!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;

            }
            var result = $@"SELECT EMAIL.QueryToHtml(
'{txtQuery.Text.Replace("'", "''")}', --query
'{txtParams.Text.Replace("'", "''")}', --parameters
'{txtCaption.Text}', --caption
'{txtFooter.Text}', --footer
 {cmbRotate.SelectedIndex},  --rotation mode
 {txtRCO.Value},  --rco
'{MapStyleToCode(cmbStyle.Text)}'  --css
);SELECT EMAIL.CleanMemory();";

            Clipboard.SetText(result);
            pn.Image = SqlClrHtmlTester.Properties.Resources.sql_icon;
            string fileName = ConfigurationManager.AppSettings["outputPath"] + txtCaption.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            _path = fileName;
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
                Helper.writeConfig(_state, txtQuery.Text, txtParams.Text, cmbStyle.Text, txtServer.Text,
                    txtCaption.Text, txtFooter.Text, cmbAuth.Text, txtUserName.Text,
                    _wrapper.EncryptData(txtPassword.Text), cmbDatabase.Text, cmbRotate.Text, txtRCO.Value.ToString(CultureInfo.InvariantCulture),
                    txtCustomStyle.Text, SavelstConnection());
        }

        #endregion

        #region Bind database information

        private static string BuildConnString(string serverName, string databaseName, string userName, string password, bool isWinAuth)
        {
            var connectionString =
                $"Data Source={serverName};Integrated Security=SSPI;Initial Catalog={databaseName}";
            if (isWinAuth == false)
                connectionString =
                    $"Data Source={serverName};User Id={userName}; password= {password};Initial Catalog={databaseName}";
            return connectionString;
        }

        private void CmbAuth_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbAuth.SelectedItem != null)
            {
                if (_isError)
                    _isError = false;

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


        private bool _isError = false;
        private void cmbDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbAuth.SelectedIndex != 0 && (txtUserName.Text.Trim().Equals(string.Empty) ||
                                               txtPassword.Text.Trim().Equals(string.Empty)))
            {
                MessageBox.Show(@"Please enter userName and password", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                if (_isError)
                    _isError = false;
                return;
            }
            if (_isError == false )
            {
                BindDataBases();
            }
        }

        private void BindDataBases()
        {
            cmbDatabase.Items.Clear();
            var ds = DataAccess.GetDataSet(
                DataAccess.GetConnectionString(txtServer.Text, "master", cmbAuth.SelectedIndex == 0, txtUserName.Text,
                    txtPassword.Text), @"SELECT name 
                                                                FROM sys.databases
                                                                WHERE state = 0 
                                                                    AND is_read_only = 0 
                                                                ORDER BY name", null, out var error);
            if (error.Equals(string.Empty) == false)
            {
                _isError = true;
                MessageBox.Show($@"Error binding database information : {error}");
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

        private void LstConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fill with information about database,server etc.
            //Put item on the top - sync with collection
            if (listBoxConnection.SelectedIndex == 0)
                return;
            if (listBoxConnection.SelectedItem == null)
                return;

            var index = listBoxConnection.SelectedIndex;
            var s = _listConnection[index].Value;
            var kp = _listConnection[index];

            _listConnection.RemoveAt(index);
            _listConnection.Insert(0, kp);

            listBoxConnection.Items.RemoveAt(index);
            listBoxConnection.Items.Insert(0, drawItem(s));
            listBoxConnection.SelectedIndex = 0;

            var splitter = s.Split('@');
            var splitter2 = splitter[1].Split(new string[] { Helpersplitter }, StringSplitOptions.None);

            txtServer.Text = splitter2[0].Substring(0, splitter2[0].IndexOf("(", StringComparison.Ordinal));
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
                txtUserName.Text = splitter2[0].Substring(splitter2[0].IndexOf("(", StringComparison.Ordinal) + 1,
                    splitter2[0].Length - splitter2[0].IndexOf("(", StringComparison.Ordinal) - 2);
            }
            cmbDatabase.Text = splitter[0];

          
            BindAssemblyList(_assemblyName);
            //labelConnectionInfo.Text = drawItem(s).Replace("\r\n", ".");
            labelConnectionInfo.Text = SetLabel();


        }

        private void MakeListConnection(string[] stateList)
        {
            foreach (var s in stateList)
            {
                if (s.Equals(string.Empty))
                    continue;
                var splitter = s.Split(new string[] { Helpersplitter }, StringSplitOptions.None);
                var second = _wrapper.DecryptData(splitter[1]);
                var result = splitter[0] + Helpersplitter + second;
                var hasher = result.GetHashCode();
                _listConnection.Add(new KeyValuePair<int, string>(hasher, result));
                listBoxConnection.Items.Add(drawItem(s));

            }
            //labelConnectionInfo.Text = listBoxConnection.Items[0].ToString().Replace("\r\n", ".");
            labelConnectionInfo.Text = SetLabel();
        }
        private void LstConnections_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var myBrush = Brushes.Black;
         
            var stringToDraw = listBoxConnection.Items[e.Index].ToString();
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

        private string MakeListItem(string databaseName, string serverName, string userName, string password) => 
            databaseName.ToUpper().Trim() + "@" + serverName.ToUpper().Trim() + "(" + userName.ToUpper().Trim() + ")" + Helpersplitter + password;
        private string drawItem(string itemToDraw)
        {
            var splitter = itemToDraw.Split('@');
            return splitter[0] + Environment.NewLine + splitter[1].Split(new string[] { Helpersplitter},StringSplitOptions.None)[0];
        }
        private string SavelstConnection()
        {
            var retValue = "";
            foreach (var s in _listConnection)
            {
                var splitter = s.Value.Split(new string[] { Helpersplitter }, StringSplitOptions.None);
                var second = _wrapper.EncryptData(splitter[1]);
                var result = splitter[0] + Helpersplitter + second;
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
                MessageBox.Show(@"Please enter server name!",
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (cmbAuth.SelectedIndex == -1)
            {
                MessageBox.Show(@"Please choose authentication type!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (cmbDatabase.SelectedIndex == -1)
            {
                MessageBox.Show(@"Please choose database!", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            btnTestConnection.Enabled = false;
            //if (checkInstallation() == false)
            //    MessageBox.Show("SQLCLR assembly is not installed");
            
            //else
            //{
                var descriptive = MakeListItem(cmbDatabase.Text, txtServer.Text, txtUserName.Text, txtPassword.Text);
                var hashCode = descriptive.GetHashCode();
                var isInList = false;
                foreach (var s in _listConnection)
                {
                    if (s.Key != hashCode) continue;
                    isInList = true;
                    break;
                }

                if (isInList == false)
                {
                    listBoxConnection.Items.Clear();
                    //Add at first position
                    listBoxConnection.Items.Add(drawItem(descriptive));
                    //Add the rest
                    foreach (var s in _listConnection)
                        listBoxConnection.Items.Add(drawItem(s.Value));
                    //syncronise
                    _listConnection.Insert(0, new KeyValuePair<int, string>(hashCode, descriptive));
                    listBoxConnection.SelectedIndex = 0;
                  
                    //BindAssemblyList("SQLCLRReporter");
                    //labelConnectionInfo.Text = listBoxConnection.Items[0].ToString().Replace("\r\n", ".");
                    labelConnectionInfo.Text = SetLabel();
                }
                else
                {
                    
                    //BindAssemblyList("SQLCLRReporter");
                    MessageBox.Show(@"Everything seems to be OK!", @"OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
            //}
            btnTestConnection.Enabled = true;

        }
        private string SetLabel() =>
            txtServer.Text.Trim() + "." + cmbDatabase.Text.Trim() + "(" + txtUserName.Text.Trim() + ")";

        private bool CheckInstallation()
        {
            var isOk = false;
            var query = $@"SELECT
	(SELECT
			COUNT(*) counter
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'[EMAIL].[QueryToHtml]')
		AND type IN (N'FS'))
	+ (SELECT
			COUNT(*) counter
		FROM SYS.assemblies
		WHERE NAME = '{_assemblyName}') ALLTEST";
            int magicNumber = Convert.ToInt16(DataAccess.ExecuteScalar(
                BuildConnString(txtServer.Text, cmbDatabase.Text, txtUserName.Text, txtPassword.Text,
                    cmbAuth.SelectedIndex == 0), query));
            isOk = magicNumber == 2;
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

            var g = ee.Graphics;
            var tp = tabControl1.TabPages[ee.Index];
            var sf = new StringFormat();
            var r = new RectangleF(ee.Bounds.X, (ee.Bounds.Y + 2), (ee.Bounds.Width + 5), (ee.Bounds.Height - 2));
            var font = new Font(tabControl1.Font.FontFamily,tabControl1.Font.Size);
            var tabTextBrush = new SolidBrush(Color.Black);
            var tabBackBrush = new SolidBrush(Color.FromArgb(236, 233, 216));
            sf.Alignment = StringAlignment.Center;
            string strTitle = tp.Text;
            Brush br;
            if ((tabControl1.SelectedIndex == ee.Index))
            {
                br = tabBackBrush;
                g.FillRectangle(br, ee.Bounds);
                br = tabTextBrush;
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

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnGetHtml.Enabled = true;
            //Refresh assembly information 
            BindAssemblyList(_assemblyName);


        }

    }
}