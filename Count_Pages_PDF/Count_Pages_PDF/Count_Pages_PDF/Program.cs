using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace Count_Pages_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            int countFor=1;
            string pathInput = AppDomain.CurrentDomain.BaseDirectory + "Files\\Config.txt";
            List<string[]> pdfFiles = ReadInputFile(pathInput);
            List<string> writeResultCount = new List<string>();
            writeResultCount.Add("File,Pages");
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Files\\Result.csv"))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Files\\Result.csv");
            }
            try
            {
                foreach (string[] row in pdfFiles)
                {
                    if (countFor > 1)
                    {
                        string countResult = row[0].ToString() + "," + CountPDFFile(@row[1].ToString());
                        writeResultCount.Add(countResult);
                    }
                    countFor++;
                }
                File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + "Files\\Result.csv", writeResultCount);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        private static List<string[]> ReadInputFile(string pathInputFile)
        {
            List<string[]> readData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(pathInputFile))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    readData.Add(row);
                }
            }

            return readData;
        }
        private static int CountPDFFile(string pathPDF)
        {
            PdfReader pdfReader = new PdfReader(pathPDF);
            int numberOfPages = pdfReader.NumberOfPages;
            return numberOfPages;
        }
    }
}
