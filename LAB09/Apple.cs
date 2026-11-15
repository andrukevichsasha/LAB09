using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB09
{
    internal class Apple : Product, IDiscountable
    {
        public string Variety { get; set; }
        public string Country { get; set; }

        public Apple (string name, double pricePerKg, double quantityKg, string variety, string country)
            : base(name, pricePerKg, quantityKg, true)
        {
            Variety = variety;
            Country = country;
        }
        public double GetDiscountable()
        {
            if (QuantityKg >= 3)
            {
                return 0.20;
            }
            else if (QuantityKg >= 2)
            {
                return 0.10;
            }
            else
            {
                return 0.05;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Сорт: {Variety}, Страна: {Country}";
        }
    }
}
