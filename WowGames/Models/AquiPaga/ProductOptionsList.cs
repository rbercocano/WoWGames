using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class ProductOptionsList
    {
        public string Name { get; set; }
        public string ProductOptionCode { get; set; }
        public string Description { get; set; }
        public double? Value { get; set; }
        public MinMaxRangeValue MinMaxRangeValue { get; set; }
        public object RechargeBonus { get; set; }
        public object RechargeBonusPercent { get; set; }
        public object RechargeCost { get; set; }
        public object ValityPeriod { get; set; }
        public object RechargeValueCategoryDescription { get; set; }
        public object ValityPeriodBonus { get; set; }
        public object Message { get; set; }
        public object RechargeValueKey { get; set; }
        public object RechargeBonusCategoryDescription { get; set; }
        public object BranchCode { get; set; }
        public object RechargeValueCode { get; set; }
    }

    public class MinMaxRangeValue
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}
