using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType, bakedType;
        double weight;
        public Dough(string flourType, string bakedType,double weight)
        {
            FlourType = flourType;
            BakedType = bakedType;
            Weight = weight;
        }

        private string FlourType
        {
            get => flourType;
            set
            {
                if (isFlourTypeValid(value)) flourType = value;
                else throw new ArgumentException("Invalid type of dough.");
            }
        }
        private string BakedType
        {
            get => bakedType;
            set
            {
                if (isBakedTypeValid(value)) bakedType = value;
                else throw new ArgumentException("Invalid type of dough.");
            }
        }

        private double Weight
        {
            get => weight; set
            {
                if (value < 1 || value > 200) throw new ArgumentException("Dough weight should be in the range [1..200].");
                else
                    weight = value;
            }
        }

        public double CaloriesPerGram { get => GetCaloriesPerGram(FlourType, BakedType,Weight); }

        private double GetCaloriesPerGram(string flourType, string bakedType,double weight)
        {
            double caloriesTotal = 2 * weight;
            double modifier1 = 1;
            if (flourType.ToLower() == "white")
            {
                modifier1 = 1.5;
            }

            double modifier2 = 0.9;

            if (bakedType.ToLower() == "chewy")
            {
                modifier2 = 1.1;
            }
            if (bakedType.ToLower() == "homemade")
            {
                modifier2 = 1.0;
            }
            return caloriesTotal * modifier1 * modifier2;
        }

        private bool isBakedTypeValid(string flourType)
        {
            switch (flourType.ToLower())
            {
                case "crispy":
                case "chewy":
                case "homemade":
                    return true;
                default:
                    return false;
            }
        }

        private bool isFlourTypeValid(string flourType)
        {
            switch (flourType.ToLower())
            {
                case "white":
                case "wholegrain":
                    return true;
                default:
                    return false;
            }
        }
    }
}
