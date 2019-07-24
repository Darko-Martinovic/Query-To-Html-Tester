using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlClrHtmlTester
{
    internal class DataAccess
    {
        public static DataSet GetDataSet(string connectionString, string commandText, List<SqlParameter> listOfParams, out string error)
        {
            var ds = new DataSet();
            error = string.Empty;
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {

                    using (var command = new SqlCommand(commandText, cnn))
                    {
                        cnn.Open();
                        if (listOfParams != null)
                        {
                            foreach (var p in listOfParams)
                            {
                                command.Parameters.Add(p);
                            }
                        }
                        using (var sqlAdp = new SqlDataAdapter())
                        {
                            sqlAdp.SelectCommand = command;
                            sqlAdp.Fill(ds);
                        }
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return ds;
        }
        public static string GetConnectionString(string serverName, string dataBaseName,bool isWindowsAuth, string userName, string password)
        {
            var connectionString = $"Data Source={serverName};Integrated Security=SSPI;Initial Catalog={dataBaseName}";
            if (isWindowsAuth == false)
                connectionString =
                    $"Data Source={serverName};User Id={userName}; password= {password};Initial Catalog={dataBaseName}";
            return connectionString;
        }
        public static string GetHtml(string connectionString, string query, string queryParams, string caption,
            string footer, string style, string rotate, string rco)
        {
            var result = "";
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {

                    using (var command =
                        new SqlCommand(
                            "SELECT EMAIL.QueryToHtml(@query ,@queryParams,@caption,@footer,@rotate,@rco,@style);SELECT EMAIL.CleanMemory()",
                            cnn))

                    {
                        //query
                        command.Parameters.Add(new SqlParameter("@query", SqlDbType.NVarChar, -1));
                        command.Parameters["@query"].Value = query;

                        //queryparams
                        command.Parameters.Add(new SqlParameter("@queryParams", SqlDbType.NVarChar, 4000));
                        command.Parameters["@queryParams"].Value = queryParams;

                        //caption
                        command.Parameters.Add(new SqlParameter("@caption", SqlDbType.NVarChar, 200));
                        command.Parameters["@caption"].Value = caption;

                        //footer
                        command.Parameters.Add(new SqlParameter("@footer", SqlDbType.NVarChar, 1000));
                        command.Parameters["@footer"].Value = footer;

                        //style
                        command.Parameters.Add(new SqlParameter("@style", SqlDbType.NVarChar, 4000));
                        command.Parameters["@style"].Value = style;

                        //rotate
                        command.Parameters.Add(new SqlParameter("@rotate", SqlDbType.SmallInt));
                        command.Parameters["@rotate"].Value = rotate;

                        //rco
                        command.Parameters.Add(new SqlParameter("@rco", SqlDbType.SmallInt));
                        command.Parameters["@rco"].Value = rco;

                        cnn.Open();
                        result = command.ExecuteScalar().ToString();
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public static string ConCatHtml(string connectionString, string mainHtml, string addOnHtml)
        {
            var result = "";
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {

                    using (var command = new SqlCommand("SELECT EMAIL.ConCatHtml(@mainHtml,@addOnHtml);SELECT EMAIL.CleanMemory()", cnn))
                    {
                        command.Parameters.Add(new SqlParameter("@mainHtml", SqlDbType.NVarChar, -1));
                        command.Parameters["@mainHtml"].Value = mainHtml;

                        command.Parameters.Add(new SqlParameter("@addOnHtml", SqlDbType.NVarChar,-1));
                        command.Parameters["@addOnHtml"].Value = addOnHtml;

                        cnn.Open();
                        result = command.ExecuteScalar().ToString();
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public static object ExecuteScalar(string connectionString, string query)
        {
            object retvalue;
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {

                    using (var command = new SqlCommand(query, cnn))
                    {
                        cnn.Open();
                        retvalue = command.ExecuteScalar();
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                retvalue = ex.Message;
            }
            return retvalue;
        }

        public static object ExecuteNonQuery(string connectionString, string query,out bool isException)
        {
            object retvalue;
            isException = false;
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {

                    using (var command = new SqlCommand(query, cnn))
                    {
                        cnn.Open();
                        retvalue = command.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                retvalue = ex.Message;
                isException = true;
            }

            return retvalue;
        }


    }
}
