using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BusinessLogicLibrary
{
    public class Main
    {
        public static void InserData(string pathInputFile, string separator, string columnNumber, string connectionString, string pathError)
        {
            string[] columns =
            {
                "EMAIL PROCESSED",
                "TRANSACTION TYPE"
            };

            DataTable pendingTransactionsTable = new DataTable();

            foreach (string column in columns)
            {
                pendingTransactionsTable.Columns.Add(column);
            }
            List<string[]> inputData = ReadInput.ReadInputFile(pathInputFile, separator);
            List<string[]> transactionStatus = new List<string[]>();
            string[] comulns = inputData[0];
            int count = 0;
            if ( comulns.GetLength(0).ToString() == columnNumber)
            {
                foreach (var data in inputData)
                {
                    if(count > 0)
                    {
                        string[] transactionStatusArray = new string[2];
                        string transactionType;
                        Model insertData = new Model();
                        insertData.Company = data[0].Replace("'", "''");
                        insertData.Full_Name = data[1].Replace("'","''");
                        insertData.primaryWorkEmail = data[2].Replace("'", "''");
                        insertData.CF_ADP_Payroll_ID_or_Workday_ID = data[3].Replace("'", "''");
                        insertData.Cost_Center_Code = data[4].Replace("'", "''");
                        insertData.Location_Address_Country = data[5].Replace("'", "''");
                        insertData.primaryWorkEmail1 = data[6].Replace("'", "''");
                        transactionType = InsertData.InsertDataFile(connectionString, insertData, pathError);
                        if (transactionType == "TRUE")
                        {
                            transactionStatusArray[0] = insertData.primaryWorkEmail1;
                            transactionStatusArray[1] = "UPDATE";                        
                        }
                        else if(transactionType == "FALSE")
                        {
                            transactionStatusArray[0] = insertData.primaryWorkEmail1;
                            transactionStatusArray[1] = "INSERT";
                        }
                        transactionStatus.Add(transactionStatusArray);
                    }
                    count++;
                }
            }
            else
            {
                File.WriteAllText(pathError, "he number of columns found in the read file does not match the number of columns stipulated for this file, verify that the file has the correct information.");
            }
        }
    }
}
