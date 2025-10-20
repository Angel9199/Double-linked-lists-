using Double_Linkedlist.Logic;

Console.WriteLine("***Double linked lists");
var fruits = new DoubleList<Fruit>();
fruits.Add(new Fruit { Name = "Naranja", Price = 5000 });
fruits.Add(new Fruit { Name = "Pera", Price = 4000 });
fruits.Add(new Fruit { Name = "Kiwy", Price = 6000 });
fruits.Add(new Fruit { Name = "Aguacate", Price = 4500 });
fruits.Add(new Fruit { Name = "Limón", Price = 1500 });
Console.WriteLine(fruits);