using Raiding.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace Raiding.Factories
{
    internal class FarmFactory : IFarm
    {
        public IAnimal CreateAnimal(string[] args)
        {
            IAnimal animal = null;
            if (args.Length == 5)
            {
                IFeline feline = null;
                if (args[0] == "Cat")
                    feline = new Cat(args[1], double.Parse(args[2]), args[3], args[4]);
                else
                    feline = new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);

                animal = (IAnimal)feline;
            }
            else
            {
                switch (args[0])
                {
                    case "Owl":
                        animal = new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
                        break;
                    case "Hen":
                        animal = new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
                        break ;
                    case "Mouse":
                        animal = new Mouse(args[1], double.Parse(args[2]), args[3]);
                        break;
                    case "Dog":
                        animal = new Dog(args[1], double.Parse(args[2]), args[3]);
                        break;
                    default:
                        throw new ArgumentException("Invalid animal!");

                }
                    

            }
            return animal;
        }

        public IFood CreateFood(string[] args)
        {
            IFood food = null;
            switch (args[0])
            {
                case "Vegetable":
                    food = new Vegetable(int.Parse(args[1]));
                    break;
                case "Fruit":
                    food = new Fruit(int.Parse(args[1]));
                    break;
                case "Meat":
                    food = new Meat(int.Parse(args[1]));
                    break;
                case "Seeds":
                    food = new Seeds(int.Parse(args[1]));
                    break;
                default:
                    throw new ArgumentException("Invalid food");
                   
            }
            return food;
        }
    }
}
