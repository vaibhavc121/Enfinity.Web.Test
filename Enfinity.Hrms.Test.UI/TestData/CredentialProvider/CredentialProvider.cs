using Enfinity.Hrms.Test.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.TestData.CredentialProvider
{
    public class CredentialProvider
    {

        //private readonly string _connectionString = VaultUtils.GetConnectionString();
        //private readonly string _connectionString = "Server=tcp:vaibhavc121.database.windows.net,1433;Initial Catalog=Enfinity;Persist Security Info=False;User ID=vaibhavc121;Password=roH!tc121@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private readonly string _connectionString = "Data Source=db-server-on-enfinity.database.windows.net;Initial Catalog=enfinitysysdb;User Id=dbadmin;password=Dba##2022@OnEnfinity;";
        public (string Username, string Password) GetCredentials()
        {
            string username = null;
            string password = null;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                //var cmd = new SqlCommand("SELECT Username, Password FROM Credentials WHERE Id = 1", conn);

                var cmd = new SqlCommand("Select Username, Password from AppUsers Where SysID IN (Select MappedToUserId from Employees Where Name like '%vaibhav chavan%')", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        username = reader.GetString(0);
                        password = reader.GetString(1);
                    }
                }
            }

            return (username, password);
        }
    }
}
