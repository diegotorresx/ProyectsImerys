using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace BusinessLogicLibrary
{
    public class InsertData
    {
        public static string InsertDataFile(string connectionString, Model data, string pathError)
        {
            string resultQuery = string.Empty;
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    return db.Query<string>("InsertBraswareMailData", new { email = data.email, firstname = data.firstname, lastname = data.lastname }, commandType: CommandType.StoredProcedure).ToString();
                }
            }
            catch (Exception e)
            {
                File.WriteAllText(pathError, e.ToString());
                return resultQuery;
            }
        }
    }
}
