using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.Rixty
{
    public class RixtyProduct
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string SmallProductImage { get; set; }
        public int SupplierID { get; set; }
        public int GameID { get; set; }
        public string SupplierName { get; set; }
        public string GameName { get; set; }
        public bool IsStockAvailable { get; set; }
        public int StockQuantity { get; set; }
        public double Commission { get; set; }
        public double SellingPrice { get; set; }
        public string PayablePrice { get; set; }
        public double Price { get; set; }
        public double UnitPrice { get; set; }
        public string Currency { get; set; }
    }
}
