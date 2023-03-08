using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace Raiding.Core.Engine
{
    public class Engine : IEngine
    {
        private readonly ICollection<IAnimal> animals;
        IFarm factory;
        IReader reader;
        IWriter writer;
        public Engine(IFarm factory, IWriter writer, IReader reader)
        {
            animals = new List<IAnimal>();
            this.factory = factory;
            this.writer = writer;
            this.reader = reader;
        }
        public void Run()
        {

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                IAnimal temp=null;
                try
                {
                    
                    temp = factory.CreateAnimal(input.Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    Console.WriteLine(temp.ProduceSound());
                   

                    input = Console.ReadLine();
                    IFood food = factory.CreateFood(input.Split(" ", StringSplitOptions.RemoveEmptyEntries));

                    temp.Eat(food);
                    
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                 
                }

                animals.Add(temp);
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }



        }
    }
}
