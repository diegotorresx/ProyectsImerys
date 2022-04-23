using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BulkInsertLibrary
{
    public class Main
    {
        public static void BulkInsert(string pathInput)
        {
            int count = 0;
            List<string[]> inputData = ReadInputFile(pathInput);
            foreach (var record in inputData)
            {
                if (count > 0 && inputData.Count > 0)
                {
                    InserData(record[0], record[1], record[2], record[3]);
                    break;
                }
                count++;
            }
            
        }
        
        public static List<string[]> ReadInputFile(string pathInputFile)
        {
            List<string[]> readData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(pathInputFile))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split('|');
                    readData.Add(row);
                }
            }

            return readData;
        }

        public static void InserData(string connectionString, string spName, string tableName, string pathFile)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    db.Execute(spName, new{}, commandType: CommandType.StoredProcedure, commandTimeout: 0);
                    db.Close();
                }
            }
            catch (Exception e)
            {
                File.WriteAllText(@"..\Files\Exception.csv", e.ToString());
            }
        }
    }
}
