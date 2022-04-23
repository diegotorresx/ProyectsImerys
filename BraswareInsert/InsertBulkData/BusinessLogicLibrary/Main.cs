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
            DataTable inputData = ReadInput.ReadData(pathInputFile, separator);
            List<string[]> transactionStatus = new List<string[]>();
            DataRow comulns = inputData.Rows[0];
            int count = 0;
            if (comulns.ItemArray.Length.ToString() == columnNumber)
            {
                foreach (DataRow data in inputData.Rows)
                {
                    if (count > 0)
                    {
                        string transactionType;
                        Model insertData = new Model();
                        insertData.email = data[4].ToString().Replace("'", "''");
                        insertData.firstname = data[0].ToString().Replace("'", "''");
                        insertData.lastname = data[1].ToString().Replace("'", "''");
                        transactionType = InsertData.InsertDataFile(connectionString, insertData, pathError);
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
