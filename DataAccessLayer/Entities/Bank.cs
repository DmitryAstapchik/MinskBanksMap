using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ExchangeRates ExchangeRates { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
