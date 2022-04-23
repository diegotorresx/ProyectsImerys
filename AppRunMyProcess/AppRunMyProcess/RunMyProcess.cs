using System;
using System.Collections.Generic;

namespace AppRunMyProcess
{
    public class RunMyProcess
    {
        // This is the Main class of the classes library. This class is for call aother classes into classes library. This class is called to console app
        public static void InsertData(string query, string connectionString, string pathInputFile)
        {
            List<string[]> inputData = BusinessLogic.BusinessLogic.InputData(pathInputFile);
            BusinessLogic.BusinessLogic.InsertDataSQL(inputData, query, connectionString);
        }
    }
}
