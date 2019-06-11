using DataAccessLayer.Entities;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Xml.Linq;

namespace DataAccessLayer.Context
{
    public class BanksContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<ExchangeRates> ExchangeRates { get; set; }

        static BanksContext()
        {
            Database.SetInitializer(new Initialize());
        }

        public class Initialize : DropCreateDatabaseAlways<BanksContext>
        {
            protected override void Seed(BanksContext context)
            {
                XDocument banksDoc = XDocument.Load("banks.xml");

                // add banks and departments
                foreach (var b in banksDoc.Root.Elements("bank"))
                {
                    Bank bank = new Bank()
                    {
                        Name = b.Attribute("name").Value
                    };

                    foreach (var dep in b.Elements())
                    {
                        Department department = new Department()
                        {
                            Id = Convert.ToInt16(dep.Element("id").Value),
                            Address = dep.Element("address").Value.ToString(),
                            Latitude = Convert.ToDouble(dep.Element("latitude").Value),
                            Longitude = Convert.ToDouble(dep.Element("longitude").Value),
                        };
                        bank.Departments.Add(department);
                    }
                    context.Banks.Add(bank);
                }
                context.SaveChanges();

                // add exchange rates
                XDocument exchageRatesDoc = XDocument.Load("http://www.obmennik.by/xml/kurs.xml");
                NumberFormatInfo nfi = new NumberFormatInfo
                {
                    NumberDecimalSeparator = "."
                };
                Random rand = new Random();
                foreach (var b in exchageRatesDoc.Root.Elements("bank-id"))
                {
                    ExchangeRates er = new ExchangeRates()
                    {
                        BankId = Convert.ToInt16(b.Element("idbank").Value),
                        DepId = 0,
                        USDSell = Math.Round(Convert.ToDouble(b.Element("usd").Element("sell").Value, nfi), 3),
                        USDBuy = Math.Round(Convert.ToDouble(b.Element("usd").Element("buy").Value, nfi), 3),
                        EURSell = Math.Round(Convert.ToDouble(b.Element("eur").Element("sell").Value, nfi), 3),
                        EURBuy = Math.Round(Convert.ToDouble(b.Element("eur").Element("buy").Value, nfi), 3),
                        RURSell = Math.Round(Convert.ToDouble(b.Element("rur").Element("sell").Value, nfi), 3),
                        RURBuy = Math.Round(Convert.ToDouble(b.Element("rur").Element("buy").Value, nfi), 3)
                    };
                    var bank = context.Banks.Find(er.BankId);
                    if (bank != null)
                    {
                        bank.ExchangeRates = er;
                        foreach (var dep in bank.Departments)
                        {
                            // exchange rates pseudo-random generation
                            dep.ExchangeRates = new ExchangeRates()
                            {
                                BankId = er.BankId,
                                DepId = dep.Id,
                                USDSell = Math.Round(er.USDSell.Value + rand.NextDouble() * 0.01 * (rand.Next(1) == 1 ? 1 : -1), 3),
                                USDBuy = Math.Round(er.USDBuy.Value + rand.NextDouble() * 0.01 * (rand.Next(1) == 1 ? 1 : -1), 3),
                                EURSell = Math.Round(er.EURSell.Value + rand.NextDouble() * 0.01 * (rand.Next(1) == 1 ? 1 : -1), 3),
                                EURBuy = Math.Round(er.EURBuy.Value + rand.NextDouble() * 0.01 * (rand.Next(1) == 1 ? 1 : -1), 3),
                                RURSell = Math.Round(er.RURSell.Value + rand.NextDouble() * 0.02 * (rand.Next(1) == 1 ? 1 : -1), 3),
                                RURBuy = Math.Round(er.RURBuy.Value + rand.NextDouble() * 0.02 * (rand.Next(1) == 1 ? 1 : -1), 3)
                            };
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
