using System;

namespace BulkInsertApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathInput = AppDomain.CurrentDomain.BaseDirectory + "Input\\InputData.csv";
            BulkInsertLibrary.Main.BulkInsert(pathInput);
        }
    }
}
