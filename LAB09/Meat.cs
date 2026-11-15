using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB09
{
    internal class Meat : Product, IDiscountable
    {
        public double FatPercent {  get; set; }
        private string MeatType { get; set; }
        public Meat (string name, double pricePerKg, double quantityKg, double fatPercent, string meatType) 
            :base (name, pricePerKg, quantityKg, false)
        {
            FatPercent = fatPercent;
            MeatType = meatType;
        }
        public double GetDiscountable()
        {
            if(QuantityKg >= 3)
            {
                return 0.15;
            }
            else if (QuantityKg >= 2)
            {
                return 0.1;
            }
            else
            {
                return 0.05;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Процент жирности: {FatPercent}%, Тип мяса: {MeatType}";
        }
    }
}
