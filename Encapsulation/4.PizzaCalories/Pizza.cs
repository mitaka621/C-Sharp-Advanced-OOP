using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        List<Topping> topings;
        string name;
        public Pizza(string name, Dough dough)
        {
            topings = new List<Topping>();
            Name = name;
            Dough = dough;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 1 || value.Length > 15 || value==string.Empty)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                else
                    name = value;
            }
        }
        public Dough Dough { private get; set; }
        public int NumTopings { get => topings.Count; }
        public double TotalCalories { get => GetTotalCalories(); }

        private double GetTotalCalories()
        {
            if (NumTopings>10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            double totalCalories = Dough.CaloriesPerGram;
            foreach (var item in topings)
            {
                totalCalories += item.CaloriesPerGram;
            }
            return totalCalories;
        }
        public void AddTopping(Topping topping)
        {
            topings.Add(topping);
        }
        public override string ToString()
        {
            return $"{name} - {TotalCalories:F2} Calories.";
        }
    }
}
