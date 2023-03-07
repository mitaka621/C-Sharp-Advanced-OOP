using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        double weight;
        string type;
        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
            
        }
        private string Type
        {
            get => type;
            set
            {
                switch (value.ToLower())
                {
                    case "meat":
                    case "veggies":
                    case "cheese":
                    case "sauce":
                        type = value;
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        private double Weight
        {
            get => weight; set
            {
                if (value<1||value>50)
                {
                    throw new ArgumentException(Type + " weight should be in the range [1..50].");
                }
                else
                    weight = value;
            }
        }
        public double CaloriesPerGram { get => GetCalories(type, weight); }
        private double GetCalories(string type, double weight)
        {
            double totalCalories = 2 * weight;
            double modifier1 = 0;
            switch (type.ToLower())
            {
                case "meat":
                    modifier1 = 1.2;
                    break;
                case "veggies":
                    modifier1 = 0.8;
                    break;
                case "cheese":
                    modifier1 = 1.1;
                    break;
                case "sauce":
                    modifier1 = 0.9;
                    break;

            }
            return totalCalories * modifier1;
        }
    }
}
