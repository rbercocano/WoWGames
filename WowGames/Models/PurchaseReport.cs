using System;

namespace WowGames.Models
{
    public class PurchaseReport
    {
        public string Partner { get; set; }
        public string Sku { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int Qtd { get; set; }
    }
}
