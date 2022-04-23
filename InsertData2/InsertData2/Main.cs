using InsertData2.DataLogic;
using InsertData2.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace InsertData2
{
    public class InitProcess
    {
        public static void InsertData(string query, string connectionString, string pathInputFile)
        {
            List<string[]> inputData = BusinessLogic.BusinessLogic.InputData(pathInputFile);
            BusinessLogic.BusinessLogic.InsertDataSQL(inputData, query, connectionString);
        }
    }
}
