using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlClrHtmlTester
{
    class Monitor
    {
        public static DataSet GetAssemblies(string connectionString)
        {
            string commandText = @"SELECT 
                                        USER_NAME(principal_id) UserName,*
                                   FROM sys.assemblies;
";
            string error;
            DataSet ds = DataAccess.GetDataSet(connectionString, commandText, null, out error);
            return ds;
        }
        public static DataSet GetAssemblyDetails(string connectionString, string assmblyName)
        {
            string commandText = @"SELECT
	assembly_id
	,'0x' + CONVERT(VARCHAR(16), appdomain_address, 2) appdomain_address
	,load_time
FROM sys.dm_clr_loaded_assemblies
WHERE assembly_id = (SELECT
			a.assembly_id
		FROM sys.assemblies a
		WHERE name = @name);
SELECT
	*
FROM sys.dm_clr_appdomains
WHERE appdomain_address = (SELECT
			appdomain_address
		FROM sys.dm_clr_loaded_assemblies
		WHERE assembly_id = (SELECT
				a.assembly_id
			FROM sys.assemblies a
			WHERE name = @name))
";
            string error;
            List<SqlParameter> listOfParams = new List<SqlParameter>();
            SqlParameter assName = new SqlParameter("@name", SqlDbType.NVarChar, 128);
            assName.Value = assmblyName;
            listOfParams.Add(assName);
            DataSet ds = DataAccess.GetDataSet(connectionString, commandText, listOfParams, out error);
            return ds;
        }

        public static bool HasViewServerStatePermission(string connectionString)
        {
            string command = @"SELECT
	HAS_PERMS_BY_NAME(NULL, NULL, 'VIEW SERVER STATE');  
";
            object hasPerm = DataAccess.ExecuteScalar(connectionString, command);
            bool hasViewStatePerm = hasPerm == null || (int)hasPerm == 0 ? false : true;
            return hasViewStatePerm;
        }

        public static bool ReleaseMemory(string connectionString, string assName, string permissionLevel)
        {
            bool isException = false;
            var endPerm = "";
            var startPerm = "";
            if (permissionLevel.Contains("UNSAFE"))
            {
                startPerm = "SAFE";
                endPerm = "UNSAFE";
            }
            else if (permissionLevel.Contains("SAFE"))
            {
                startPerm = "UNSAFE";
                endPerm = "SAFE";
            }
            else if (permissionLevel.Contains("EXTERNAL"))
            {
                startPerm = "SAFE";
                endPerm = "EXTERNAL_ACCESS";
            }
            else
            {
                return false;
            }
            string command = @"ALTER ASSEMBLY " + assName + 
" WITH PERMISSION_SET = " + startPerm + ";";
            DataAccess.ExecuteNonQuery(connectionString, command,out isException);
            command = @"ALTER ASSEMBLY " + assName + 
" WITH PERMISSION_SET = " + endPerm + ";";
            object retValue = DataAccess.ExecuteNonQuery(connectionString, command, out isException);

            return isException == false ? true : false;

        }
    }

}
