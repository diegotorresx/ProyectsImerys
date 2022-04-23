using AppRunMyProcess.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace AppRunMyProcess.DataLogic
{
    class DataLayer
    {
        //This class contains functions that are used to insert, query and update the database. These functions are called by the functions of the other classes  
        public static void InserData(string connectionString, string query, ModelData data)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    db.Execute(query, new
                    {
                        RequestID = data.RequestID,
                        CreatedBy = data.CreatedBy,
                        CreatedOn = data.CreatedOn,
                        RequestStatus = data.RequestStatus,
                        Market = data.Market,
                        SubMarket = data.SubMarket,
                        Category = data.Category,
                        SubCategory = data.SubCategory,
                        Rebill = data.Rebill,
                        Correction = data.Correction,
                        TypeOfRequest = data.TypeOfRequest,
                        TextToShowOnCustomerDoc = data.TextToShowOnCustomerDoc,
                        Reason = data.Reason,
                        CSAssistant = data.CSAssistant,
                        ShipToCustomerNumber = data.ShipToCustomerNumber,
                        ShipToCustomerName = data.ShipToCustomerName,
                        Country = data.Country,
                        OrderNumber = data.OrderNumber,
                        AccountManager = data.AccountManager,
                        InvoiceNumberToBeCredited = data.InvoiceNumberToBeCredited,
                        CirculationList = data.CirculationList,
                        ReturnOrderNumber = data.ReturnOrderNumber,
                        ProductNumber = data.ProductNumber,
                        ProductDescription = data.ProductDescription,
                        LegalEntity = data.LegalEntity,
                        DespatchSite = data.DespatchSite,
                        ErpImplementationContact = data.ErpImplementationContact,
                        ComplaintReference = data.ComplaintReference,
                        QuantityToBeCredited = data.QuantityToBeCredited,
                        CustomerCurrency = data.CustomerCurrency,
                        ValueOfRequest = data.ValueOfRequest,
                        ExchangeRate = data.ExchangeRate,
                        ValueForApproval = data.ValueForApproval,
                        CnDnNumber = data.CnDnNumber,
                        ERP = data.ERP,
                        dateInsert = data.dateInsert
                    }, commandType: CommandType.StoredProcedure, commandTimeout: 0);
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
