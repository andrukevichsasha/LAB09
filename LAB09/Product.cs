using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB09
{
    internal class Product
    {
        public Cart Cart { get; set; }
        public string Name { get; }
        private double pricePerKg;
        public double PricePerKg
        {
            get
            {
                return pricePerKg;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Цена не может быть меньше 0");
                }
                else
                {
                    pricePerKg = value;
                }
            }
        }
        private double quantityKg;
        public double QuantityKg 
        {
            get
            {
                return quantityKg;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Количество не может быть меньше 0");
                }
                else
                {
                    quantityKg = value;
                }
            }
        }
        public bool IsVegetarian { get; set; }
        public Product(string name, double pricePerKg, double quantityKg, bool isVegetarian)
        {
            Name = name;    
            PricePerKg = pricePerKg;
            QuantityKg = quantityKg;
            IsVegetarian = isVegetarian;
        }
        public double GetCost()
        {
            return pricePerKg * quantityKg;
        }
        public override string ToString()
        {
            return $"Товар: {Name}, Цена за кг: {pricePerKg} руб., Количество: {quantityKg} кг";
        }
    }
}
