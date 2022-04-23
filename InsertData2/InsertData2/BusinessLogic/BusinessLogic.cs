using InsertData2.DataLogic;
using InsertData2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InsertData2.BusinessLogic
{
    public class BusinessLogic
    {
        public static void InsertDataSQL(List<string[]> inputData, string query, string connectionString)
        {
            DateTime date = DateTime.Now;
            foreach (var inputTable in inputData)
            {
                ModelData data = new ModelData();
                data.RequestID = inputTable[0];
                data.CreatedBy = inputTable[1];
                data.CreatedOn = inputTable[2];
                data.RequestStatus = inputTable[3];
                data.Market = inputTable[4];
                data.SubMarket = inputTable[5];
                data.Category = inputTable[6];
                data.SubCategory = inputTable[7];
                data.Rebill = inputTable[8];
                data.Correction = inputTable[9];
                data.TypeOfRequest = inputTable[10];
                data.TextToShowOnCustomerDoc = inputTable[11];
                data.Reason = inputTable[12];
                data.CSAssistant = inputTable[13];
                data.ShipToCustomerNumber = inputTable[14];
                data.ShipToCustomerName = inputTable[15];
                data.Country = inputTable[16];
                data.OrderNumber = inputTable[17];
                data.AccountManager = inputTable[18];
                data.InvoiceNumberToBeCredited = inputTable[19];
                data.CirculationList = inputTable[20];
                data.ReturnOrderNumber = inputTable[21];
                data.ProductNumber = inputTable[22];
                data.ProductDescription = inputTable[23];
                data.LegalEntity = inputTable[24];
                data.DespatchSite = inputTable[25];
                data.ErpImplementationContact = inputTable[26];
                data.ComplaintReference = inputTable[27];
                data.QuantityToBeCredited = inputTable[28];
                data.CustomerCurrency = inputTable[29];
                data.ValueOfRequest = inputTable[30];
                data.ExchangeRate = inputTable[31];
                data.ValueForApproval = inputTable[32];
                data.CnDnNumber = inputTable[33];
                data.ERP = inputTable[34];
                data.dateInsert = date;
                DataLayer.InserData(connectionString, query, data);
            }
        }

        public static List<string[]> InputData(string pathInputFile)
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
    }
}
