using System;
using System.Collections.Generic;
using System.Text;

namespace InsertData2.Model
{
    public class ModelData
    {
        public string RequestID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string RequestStatus { get; set; }
        public string Market { get; set; }
        public string SubMarket { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Rebill { get; set; }
        public string Correction { get; set; }
        public string TypeOfRequest { get; set; }
        public string TextToShowOnCustomerDoc { get; set; }
        public string Reason { get; set; }
        public string CSAssistant { get; set; }
        public string ShipToCustomerNumber { get; set; }
        public string ShipToCustomerName { get; set; }
        public string Country { get; set; }
        public string OrderNumber { get; set; }
        public string AccountManager { get; set; }
        public string InvoiceNumberToBeCredited { get; set; }
        public string CirculationList { get; set; }
        public string ReturnOrderNumber { get; set; }
        public string ProductNumber { get; set; }
        public string ProductDescription { get; set; }
        public string LegalEntity { get; set; }
        public string DespatchSite { get; set; }
        public string ErpImplementationContact { get; set; }
        public string ComplaintReference { get; set; }
        public string QuantityToBeCredited { get; set; }
        public string CustomerCurrency { get; set; }
        public string ValueOfRequest { get; set; }
        public string ExchangeRate { get; set; }
        public string ValueForApproval { get; set; }
        public string CnDnNumber { get; set; }
        public string ERP { get; set; }
        public string STATUS { get; set; }
        public string Comments { get; set; }
        public DateTime dateInsert { get; set; }
    }
}
