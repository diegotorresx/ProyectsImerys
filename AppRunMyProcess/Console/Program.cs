using AppRunMyProcess;
using System;
using System.Collections.Generic;
using CsvHelper;
using System.IO;

namespace Console
{
    class Program
    {
        //This is the main class of the console application. It is used to call the functions of the class library with which the main functionality of the console application is executed
        static void Main(string[] args)
        {
            try
            {
                List<string[]> readConfig = AppRunMyProcess.BusinessLogic.BusinessLogic.InputData(@"..\Files\Config.csv");
                //"Data Source=190.25.18.23;initial catalog=FlowerBucketApp;persist security info=True;user id=SA;password=Diego96071204186"
                string[] dataConfig = readConfig[1];
                string ConnectionString = string.Format("Data Source = {0}; Initial Catalog={1};Integrated Security=True;", dataConfig[1], dataConfig[3]);
                RunMyProcess.InsertData(dataConfig[0], ConnectionString,@dataConfig[2]);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                File.WriteAllText(@"..\Files\Exception.csv", e.ToString());
            }
            
        }
    }
}
