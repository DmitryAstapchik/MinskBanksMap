using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public class Department
    {
        public int Id { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual ExchangeRates ExchangeRates { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
