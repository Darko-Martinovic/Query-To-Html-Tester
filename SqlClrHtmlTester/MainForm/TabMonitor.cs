using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace SqlClrHtmlTester
{
    partial class MainForm
    {
        #region " Bind assmebly list"
        private void BindAssemblyList(string name)
        {
            listBoxAssemblies.Items.Clear();

            
            connectionString = DataAccess.GetConnectionString(txtServer.Text, cmbDatabase.Text, cmbAuth.SelectedIndex == 0 ? true : false, txtUserName.Text, txtPassword.Text);

            bool hasViewStatePermission = Monitor.HasViewServerStatePermission(connectionString);
            if (hasViewStatePermission == false)
            {
                return;
            }

            ds = Monitor.GetAssemblies(connectionString);
            int i = 0;
            int j = 0;

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                listBoxAssemblies.Items.Add(r["name"].ToString());
                if (name != null)
                {
                    if (r["name"].ToString().Equals(name))
                        j = i;
                }
                i++;
            }
            listBoxAssemblies.SelectedIndex = j;

        }
        private void BindAssembly(DataRow dt)
        {
            try
            {
                txtPrincipalId.Text = dt["principal_id"].ToString();
                txtPrincipalName.Text = dt["UserName"].ToString();

                txtAssemblyId.Text = dt["assembly_id"].ToString();
                txtClrName.Text = dt["clr_name"].ToString();
                txtPermissionSet.Text = dt["permission_set_desc"].ToString();

                txtCreatedDate.Text = dt["create_date"].ToString();
                txtModifiedDate.Text = dt["modify_date"].ToString();
                chkIsUserDefined.Checked = (bool)(dt["is_user_defined"]);
                chbUserVisible.Checked = (bool)(dt["is_visible"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in binding assembly information : " + ex.Message);
            }

        }
        private void BindAssemblyDetails(DataSet details)
        {
            try
            {
                if (details.Tables.Count == 0)
                {
                    return;
                }
                DataTable dt = details.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtAppDomainAddress.Text = dt.Rows[0]["appdomain_address"].ToString();
                    txtLoadTime.Text = dt.Rows[0]["load_time"].ToString();
                }
                else
                {
                    txtAppDomainAddress.Text = "N/A";
                    txtLoadTime.Text = "N/A";
                }
                DataTable dtAppDomains = details.Tables[1];
                if (dtAppDomains.Rows.Count > 0)
                {
                    txtAppDomainName.Text = dtAppDomains.Rows[0]["appdomain_name"].ToString();
                    txtCreationTime.Text = dtAppDomains.Rows[0]["creation_time"].ToString();
                    txtState.Text = dtAppDomains.Rows[0]["state"].ToString();


                    txtStrongRefCount.Text = Convert.ToInt32(dtAppDomains.Rows[0]["strong_refcount"]).ToString("N0");

                    txtWeakRefCount.Text = Convert.ToInt32(dtAppDomains.Rows[0]["weak_refcount"]).ToString("N0");

                    txtCost.Text = Convert.ToInt64(dtAppDomains.Rows[0]["cost"]).ToString("N0");
                    txtValue.Text = Convert.ToInt64(dtAppDomains.Rows[0]["value"]).ToString("N0");

                    if (dtAppDomains.Columns.Contains("total_processor_time_ms"))
                    {
                        totalProcesorTime.Text = Convert.ToInt64(dtAppDomains.Rows[0]["total_processor_time_ms"]).ToString("N0");
                    }
                    else
                    {
                        totalProcesorTime.Text = "N/A";
                    }
                    if (dtAppDomains.Columns.Contains("total_allocated_memory_kb"))
                    {
                        totalAllocatedMemory.Text = Convert.ToInt64(dtAppDomains.Rows[0]["total_allocated_memory_kb"]).ToString("N0");
                    }
                    else
                    {
                        totalAllocatedMemory.Text = "N/A";
                    }
                    if (dtAppDomains.Columns.Contains("survived_memory_kb"))
                    {
                        txtSurvivedMemory.Text = Convert.ToInt64(dtAppDomains.Rows[0]["survived_memory_kb"]).ToString("N0");
                    }
                    else
                    {
                        txtSurvivedMemory.Text = "N/A";
                    }


                }
                else
                {
                    txtAppDomainName.Text = "N/A";
                    txtCreationTime.Text = "N/A";
                    txtState.Text = "N/A";
                    txtStrongRefCount.Text = "N/A";
                    txtWeakRefCount.Text = "N/A";
                    txtCost.Text = "N/A";
                    txtValue.Text = "N/A";
                    totalProcesorTime.Text = "N/A";
                    totalAllocatedMemory.Text = "N/A";
                    txtSurvivedMemory.Text = "N/A";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in binding assembly details information : " + ex.Message);
            }

        }

        #endregion

        private void listBoxAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAssembly(ds.Tables[0].Rows[listBoxAssemblies.SelectedIndex]);
            string name = ds.Tables[0].Rows[listBoxAssemblies.SelectedIndex]["name"].ToString();
            DataSet details = Monitor.GetAssemblyDetails(connectionString, name);
            BindAssemblyDetails(details);

        }

        private void listBoxAssemblies_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush myBrush = Brushes.Black;

            string stringToDraw = listBoxAssemblies.Items[e.Index].ToString();
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

        private void btnLoadAppDomain_Click(object sender, EventArgs e)
        {
            if (txtAppDomainAddress.Text != "N/A")
            {
                MessageBox.Show("The application domain is already loaded");
                return;
            }
            if (listBoxAssemblies.Text.Equals("SQLCLRReporter"))
            {
                bool isException = false;
                DataAccess.ExecuteNonQuery(GetConnectionString(), @"SELECT * FROM EMAIL.SqlClrReporterHelp('ConCatHtml') WHERE 1=2;", out isException);
                if (isException)
                {
                    MessageBox.Show("I'm not able to load the application domain");
                }
                else
                {
                    BindAssemblyList("SQLCLRReporter");
                }
            }
            else if (listBoxAssemblies.Text.Equals(assemblyName))
            {
                bool isException = false;
                DataAccess.ExecuteNonQuery(GetConnectionString(), @"SELECT * FROM EMAIL.CustomSendMailHelp('test');", out isException);
                if (isException)
                {
                    MessageBox.Show("I'm not able to load the application domain");
                }
                else
                {
                    BindAssemblyList(assemblyName);
                }

            }
            else if (listBoxAssemblies.Text.Equals("Microsoft.SqlServer.Types"))
            {
                bool isException = false;
                DataAccess.ExecuteNonQuery(GetConnectionString(), @"declare @test geometry = 'POINT(1 1)';", out isException);
                if (isException)
                {
                    MessageBox.Show("I'm not able to load the application domain");
                }
                else
                {
                    BindAssemblyList("Microsoft.SqlServer.Types");
                }

            }
            else
            {
                MessageBox.Show("Not supported for assembly : " + listBoxAssemblies.Text);
            }
        }
        private string GetConnectionString()
        {
            return DataAccess.GetConnectionString(txtServer.Text, cmbDatabase.Text, cmbAuth.SelectedIndex == 0 ? true : false, txtUserName.Text, txtPassword.Text);
        }
        private void btnUnLoadAppDomain_Click(object sender, EventArgs e)
        {
            SqlClientPermission sqlPerm =
                    new SqlClientPermission(PermissionState.Unrestricted);
            sqlPerm.Assert();
            if (txtAppDomainAddress.Text.Equals("N/A"))
            {
                MessageBox.Show("The application domain is not loaded");
                return;
            }
            btnUnloadAppDomain.Enabled = false;
            btnLoadAppDomain.Enabled = false;
            btnGetHtml.Enabled = false;
            string permissionSet = txtPermissionSet.Text;
            connectionString = DataAccess.GetConnectionString(txtServer.Text, cmbDatabase.Text, cmbAuth.SelectedIndex == 0 ? true : false, txtUserName.Text, txtPassword.Text);
            if (Monitor.ReleaseMemory(connectionString, "[" + listBoxAssemblies.Text + "]", permissionSet))
            {
                BindAssemblyList(listBoxAssemblies.Text);
            }
            else
            {
                MessageBox.Show("I'm not able to unload the application domain!");
            }
            btnUnloadAppDomain.Enabled = true;
            btnLoadAppDomain.Enabled = true;
            btnGetHtml.Enabled = true;


        }

    }

}

