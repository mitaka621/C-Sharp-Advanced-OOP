using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
       

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract IReadOnlyCollection<Type> foods { get; }

        public abstract double WeightMultiplyer { get; }

        public void Eat(IFood food)
        {
            if (foods.Any(x => x.Name == food.GetType().Name))
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * WeightMultiplyer;
            }
            else
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        public abstract string ProduceSound();
    }
}
