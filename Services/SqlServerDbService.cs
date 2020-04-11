using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace tut6.Services
{
    public class SqlServerDbService : IDbService
    {
        public bool CheckIndex(string index)
        {
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18963;Integrated Security=True"))
            {
                using (var com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Select IndexNumber from Student Where IndexNumber = @index";
                    com.Parameters.AddWithValue("index", index);

                    con.Open();
                    var dr = com.ExecuteReader();
                    return dr.Read();
                }
            }
        }
    }
}

