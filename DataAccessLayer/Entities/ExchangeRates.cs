using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class ExchangeRates
    {
        [Key]
        public int BankId { get; set; }
        public int DepId { get; set; }
        public double? USDSell { get; set; }
        public double? USDBuy { get; set; }
        public double? EURSell { get; set; }
        public double? EURBuy { get; set; }
        public double? RURSell { get; set; }
        public double? RURBuy { get; set; }
    }
}
