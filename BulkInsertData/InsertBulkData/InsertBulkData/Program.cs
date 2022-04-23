using BusinessLogicLibrary;
using System;
using System.Collections.Generic;

namespace InsertBulkData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> config = ReadInput.ReadInputFile(AppDomain.CurrentDomain.BaseDirectory + "Config\\Config.csv", "|");
            int count = 0;
            string pathError = AppDomain.CurrentDomain.BaseDirectory + "Error\\Error.csv";
            foreach (var data in config)
            {
                if (count > 0)
                {
                    BusinessLogicLibrary.Main.InserData(data[3], data[0], data[1], data[2], pathError);
                    break;
                }
                count++;
            }
        }
    }
}
