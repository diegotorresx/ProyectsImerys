using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace BusinessLogicLibrary
{
    public class ReadInput
    {
        public static List<string[]> ReadInputFile(string pathInputFile, string separator)
        {
            List<string[]> readData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(pathInputFile))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Replace(", Inc.", " Inc.").Split(separator);
                    readData.Add(row);
                }
            }

            return readData;
        }
        public static DataTable ReadData(string pathInputFile, string separator)
        {
            DataSet readData = null;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(pathInputFile, FileMode.Open, FileAccess.Read))
            {
                using (var readFile = ExcelReaderFactory.CreateBinaryReader(stream))
                {
                    readData = readFile.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        { UseHeaderRow = true }
                    });
                }

                DataTable returnData = readData.Tables[0];
                return returnData;
            }
        }
    }
}
