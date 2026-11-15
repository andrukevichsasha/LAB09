using LAB09;

Cart c1 = new Cart(5);
Cart c2 = new Cart(7);

Meat m1 = new Meat("Говядина", 50, 4, 14, "вырезка");
Meat m2 = new Meat("Курица", 10, 3, 4, "филе");

Beans b1 = new Beans("Фасоль", 7, 0.5, "красная", true);
Beans b2 = new Beans("Горох", 5, 1.2, "колотый", true);

Apple a1 = new Apple("Яблоки", 3, 4, "белый налив", "Беларусь");
Apple a2 = new Apple("Яблоки", 4, 6.8, "малиновка", "Беларусь");

c1.AddToCart(m1);
c1.AddToCart(m2);
c1.AddToCart(b1);
c1.AddToCart(b2);
c1.AddToCart(a1);
c1.AddToCart(a2);

c1.DeleteFromCart(b1);

c2.AddToCart(m1);
c2.AddToCart(b1);
c2.AddToCart(a2);

c1.PrintCart();
c2.PrintCart();

Console.WriteLine(c1 == c2);
Console.WriteLine(c1 != c2);
