using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BusinessLogicLibrary
{
    public class Main
    {
        public static void InserData(string pathInputFile, string separator, string columnNumber, string connectionString, string pathError, string query)
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
                        insertData.GLAccountNumber = data[0].Replace("'", "''");
                        insertData.GLAccountName = data[1].Replace("'","''");
                        insertData.AccountType = data[2].Replace("'", "''");
                        insertData.Mapping = data[3].Replace("'", "''");
                        InsertData.InsertDataFile(connectionString, insertData, pathError, query);
                        
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
