using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB09
{
    internal class Beans : Product, IDiscountable
    {
        private string BeanType {  get; }
        private bool Organic { get; set; }

        public Beans (string name, double pricePerKg, double quantityKg, string beanType, bool organic) 
            :base (name, pricePerKg, quantityKg, true)
        {
            BeanType = beanType;
            Organic = organic;
        }
        public double GetDiscountable()
        {
            if (Organic)
            {
                if (QuantityKg < 3)
                {
                    return 0.05;
                }
                else 
                    return 0.10;
            }
            else
            {
                if (QuantityKg < 3)
                {
                    return 0.10;
                }
                else 
                    return 0.15;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Тип бобовых: {BeanType}, Органические: {Organic}";
        }
    }
}
