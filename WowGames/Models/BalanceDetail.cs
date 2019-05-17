using System;

namespace WowGames.Models
{
    public class BalanceDetail
    {
        public int Id{ get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
    }
}
