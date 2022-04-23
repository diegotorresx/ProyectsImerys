using System;
using System.Collections.Generic;
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
    }
}
