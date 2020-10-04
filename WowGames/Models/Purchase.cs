using System;

namespace WowGames.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Serial { get; set; }
        public string Token { get; set; }
        public string SuggestedPrice { get; set; }
        public string PaidPrice { get; set; }
        public int PartnerId { get; set; }
        public string Partner { get; set; }
        public string Sku { get; set; }
        public string Receipt { get; set; }
        public string TransactionId { get; set; }
        public bool Cancelled { get; set; }
        public DateTime? CancelDate { get; set; }
        public string Status { get { return Cancelled ? "Cancelado" : "Ativo"; } }
    }
}
