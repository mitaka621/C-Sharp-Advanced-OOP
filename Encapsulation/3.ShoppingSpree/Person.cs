using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        string name;
        double money;
        List<Product> bag;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                    name = value;
            }
        }

        public double Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                    money = value;
            }
        }

        public void Buy(string product, List<Product> products)
        {
            if (money-products.FirstOrDefault(x=>x.Name==product).Cost>=0)
            {
                Console.WriteLine($"{name} bought {product}");
                bag.Add(products.FirstOrDefault(x => x.Name == product));
                money -= products.FirstOrDefault(x => x.Name == product).Cost;
            }
            else
                Console.WriteLine($"{name} can't afford {product}");
        }
        public override string ToString()
        {
            if (bag.Any())
            {
                return name + " - " + String.Join(", ", bag);
            }
            else
                return name + " - " + "Nothing bought";
        }
    }
}
