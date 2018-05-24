using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlClrHtmlTester
{
    class Monitor
    {
        public static DataSet GetAssemblies(string connectionString)
        {
            var commandText = @"SELECT 
                                        USER_NAME(principal_id) UserName,*
                                   FROM sys.assemblies;
";
            var ds = DataAccess.GetDataSet(connectionString, commandText, null, out var error);
            return ds;
        }
        public static DataSet GetAssemblyDetails(string connectionString, string assmblyName)
        {
            var listOfParams = new List<SqlParameter>();
            var assName = new SqlParameter("@name", SqlDbType.NVarChar, 128) {Value = assmblyName};
            listOfParams.Add(assName);
            var ds = DataAccess.GetDataSet(connectionString, @"SELECT
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
", listOfParams, out _);
            return ds;
        }

        public static bool HasViewServerStatePermission(string connectionString)
        {
            var command = @"SELECT
	HAS_PERMS_BY_NAME(NULL, NULL, 'VIEW SERVER STATE');  
";
            var hasPerm = DataAccess.ExecuteScalar(connectionString, command);
            var hasViewStatePerm = hasPerm != null && (int)hasPerm != 0;
            return hasViewStatePerm;
        }

        public static bool ReleaseMemory(string connectionString, string assName, string permissionLevel)
        {
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
            var command = @"ALTER ASSEMBLY " + assName + 
" WITH PERMISSION_SET = " + startPerm + ";";
            DataAccess.ExecuteNonQuery(connectionString, command,out var isException);
            command = @"ALTER ASSEMBLY " + assName + 
" WITH PERMISSION_SET = " + endPerm + ";";
            var retValue = DataAccess.ExecuteNonQuery(connectionString, command, out isException);

            return isException == false;

        }
    }

}
