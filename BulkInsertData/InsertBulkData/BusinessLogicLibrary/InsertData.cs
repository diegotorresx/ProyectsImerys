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
                    return db.Query<string>("InsertWorkDayData", new { Company = data.Company, Full_Name = data.Full_Name, primaryWorkEmail = data.primaryWorkEmail, CF_ADP_Payroll_ID_or_Workday_ID = data.CF_ADP_Payroll_ID_or_Workday_ID, Cost_Center_Code = data.Cost_Center_Code, Location_Address_Country  = data.Location_Address_Country, primaryWorkEmail1 = data.primaryWorkEmail1}, commandType: CommandType.StoredProcedure).ToString();
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
