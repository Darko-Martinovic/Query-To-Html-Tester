using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace SqlClrHtmlTester
{
    partial class MainForm 
    {
        #region " Browser context menu "

        private void itemCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                string html = webBrowser1.DocumentText;
                Clipboard.SetText(html);
                pn.Image = Properties.Resources.Clipboard;
                var fileName = ConfigurationManager.AppSettings["outputPath"] + txtCaption.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                _path = fileName;
                File.WriteAllText(fileName, html, Encoding.UTF8);
                pn.Popup();

            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error copying to clipboard! Error :{ex.Message}");
            }

        }

        private void itemSaveAsHtml_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ConfigurationManager.AppSettings["outputPath"]) == false)
                return;
            try
            {
                var html = webBrowser1.DocumentText;
                var fileName = ConfigurationManager.AppSettings["outputPath"] + txtCaption.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
                _path = fileName;
                File.WriteAllText(fileName, html, Encoding.UTF8);
                pn.Image = Properties.Resources.HTML;
                pn.Popup();

            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error while making output : {ex.Message}");
            }

        }

        private void ItemExcel_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ConfigurationManager.AppSettings["outputPath"]) == false)
                return;
            var html = webBrowser1.DocumentText;
            var result = ConfigurationManager.AppSettings["outputPath"] + txtCaption.Text.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss");
            var fileName = result + ".html";
            _path = fileName;
            System.IO.File.WriteAllText(fileName, html, Encoding.UTF8);
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Microsoft.Office.Interop.Excel.dll") == false)
            {
                fileName = Directory.GetCurrentDirectory() + "\\";
                
                EmbeddedAssembly.Load("SqlClrHtmlTester.OfficeDll.Microsoft.Office.Interop.Excel.dll", "Microsoft.Office.Interop.Excel.dll", false, fileName);
                                      // SqlClrHtmlTester
            }
            if (_compObj == null)
            {
                var codeToCompile = ConfigurationManager.AppSettings["codeToCompile"];
                _compObj = _se.Compile(codeToCompile.ToString().Trim(), true, "SqlServerCentral", ref _errorMessage);
            }
            if (_compObj != null)
            {
                string em = string.Empty;
                Evaluator.Eval("EvalCode", _compObj, result + ".html", ref em);
                this.Focus();
                if (em == string.Empty)
                {
                    pn.Image = Properties.Resources.ExcelLarge;
                    _path = _path.Replace(".html", ".xlsx");
                    pn.Popup();

                }
                else
                    MessageBox.Show($@"I'm not able to save content as xlsx file. An error occured :{em}");
            }
            else
                MessageBox.Show($@"I'm not able to save content as xlsx file. An error occured :{_errorMessage}");


        }
        #endregion

        #region " Notifier "
        
        private void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == mnuOpen)
            {
                pn.Hide();
                Process.Start(_path);
            }
            else if (e.ClickedItem == mnuLocate)
            {
                pn.Hide();
                Process.Start("EXPLORER.EXE", "/select," + _path);
            }
            else if (e.ClickedItem == mnuClose)
                pn.Hide();
        }
        private void pn_Click(object sender, EventArgs e)
        {
            pn.Hide();
            Process.Start("EXPLORER.EXE", "/select," + _path);
        }

        #endregion

    }
}
