using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB09
{
    internal class Cart
    {
        public int MaxAmount { get; set; }
        private List<Product> products;

        public Cart(int maxAmount)
        {
            MaxAmount = maxAmount;
            products = new List<Product>();
        }

        public void AddToCart(Product p)
        {
            foreach (Product pro in products)
            {
                if(pro == p)
                {
                    Console.WriteLine($"Товар {p.Name} уже есть в корзине.");
                    return;
                }
            }
            if (products.Count >= MaxAmount)
            {
                Console.WriteLine($"Ошибка: Корзина заполнена (максимум {MaxAmount} товаров).");
                return;
            }
            else if (p.Cart != null)
            {
                Console.WriteLine($"Товар {p.Name} уже есть в другой корзине!");
                return;
            }
            else
                p.Cart = this;
                products.Add(p);
        }

        public void DeleteFromCart(Product p)
        {
            if (products.Remove(p))
            {
                p.Cart = null;
                Console.WriteLine($"Товар {p.Name} удален из корзины.");
            }
            else
            {
                Console.WriteLine($"Товар {p.Name} не найден в корзине.");
            }
        }

        public double CalculateTotalCost()
        {
            double total = 0;
            foreach (Product p in products)
            {
                total += p.GetCost();
            }
            return total;
        }

        public double CalculateDiscountedCost()
        {
            double total = 0;
            foreach (Product p in products)
            {
                if (p is IDiscountable discount)
                {
                    total += p.GetCost() * (1 - discount.GetDiscountable());
                }
                else
                {
                    total += p.GetCost();
                }
            }
            return total;
        }

        public double CalculateAvgVegetarianCost()
        {
            double total = 0;
            int vegCount = 0;

            foreach (Product p in products)
            {
                if (p.IsVegetarian)
                {
                    total += p.GetCost();
                    vegCount++;
                }
            }
            if (vegCount == 0)
            { 
                return 0; 
            }
            return total / vegCount;
        }

        public static bool operator ==(Cart c1, Cart c2)
        {
            if (ReferenceEquals(c1, c2))
            {
                return true;
            }
            if (c1 is null || c2 is null)
            {
                return false;
            }
            if (c1.CalculateDiscountedCost() == c2.CalculateDiscountedCost()) 
            { 
                return true;
            }
            else
                return false;
        }

        public static bool operator !=(Cart c1, Cart c2)
        {
            return !(c1 == c2);
        }
        public void PrintCart()
        {
            Console.WriteLine($"\nСодержимое корзины (товаров: {products.Count}/{MaxAmount})");
            Console.WriteLine("---------------------------------");
            foreach (Product p in products)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine($"Общая стоимость без скидок: {CalculateTotalCost():F2} руб.");
            Console.WriteLine($"Итоговая стоимость со скидками: {CalculateDiscountedCost():F2} руб.");
            Console.WriteLine($"Средняя стоимость вегетарианских товаров: {CalculateAvgVegetarianCost():F2} руб.");
        }
    }
}
