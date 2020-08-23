using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class PaymentResultData
    {
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public string Reference { get; set; }
        public int ProviderTransactionId { get; set; }
        public int TransactionId { get; set; }
        public string ProviderCode { get; set; }
        public DateTime Date { get; set; }
        public object InvoiceGenerated { get; set; }
        public bool PrizeAwarded { get; set; }
        public object PrizeAwardedResultText { get; set; }
        public string InvoiceCustomerName { get; set; }
        public int InvoiceCustomerVatNumber { get; set; }
        public string InvoiceDocument { get; set; }
        public object InvoiceDate { get; set; }
        public object InvoiceBaseValue { get; set; }
        public object InvoiceVatValue { get; set; }
        public double InvoiceVatRate { get; set; }
        public string SerialNumber { get; set; }
        public object CustomerName { get; set; }
        public object CustomerIdNumber { get; set; }
        public object CustomerPhone { get; set; }
        public object CustomerEmail { get; set; }
        public List<string> Receipt { get; set; }
        public object GroupKey { get; set; }
        public object UpSellMessage { get; set; }
        public double UpSellAmount { get; set; }
        public object NextMethodCall { get; set; }
        public object VisibleFields { get; set; }
        public object MandatoryFields { get; set; }
    }
}
