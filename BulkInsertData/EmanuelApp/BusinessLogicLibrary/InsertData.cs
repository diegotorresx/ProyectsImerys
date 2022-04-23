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
        public static void InsertDataFile(string connectionString, Model data, string pathError, string query)
        {
            string resultQuery = string.Empty;
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    db.Query(string.Format(query, data.GLAccountNumber, data.GLAccountName, data.AccountType, data.Mapping), commandType: CommandType.Text);
                    db.Close();
                }
            }
            catch (Exception e)
            {
                File.WriteAllText(pathError, e.ToString());
            }
        }
    }
}
