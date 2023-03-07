using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core.Engine
{
    public class Engine : IEngine
    {
        private readonly ICollection<IBaseHero> heroes;
        IHeroFactory CreateHero;
        IReader reader;
        IWriter writer;
        public Engine(IHeroFactory factory, IWriter writer,IReader reader)
        {
            heroes = new List<IBaseHero>();
            CreateHero = factory;
            this.writer = writer;
            this.reader = reader;
        }
        public void Run()
        {

            int n = int.Parse(reader.ReadLine());

            while(n>0)
            { 
                try
                {
                    string name = reader.ReadLine();

                    string type = reader.ReadLine();

                    heroes.Add(CreateHero.Create(type, name));
                    n--;
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {

                    throw;
                }
               
            }

            foreach (var item in heroes)
            {
                writer.WriteLine(item.CastAbility()); 
            }
            int bossPower = int.Parse(reader.ReadLine());

            if (heroes.Sum(x=>x.Power)>= bossPower)
                writer.WriteLine("Victory!");
            else
                writer.WriteLine("Defeat...");
        }
    }
}
