using Raiding.Factories;
using Raiding.Factories.Interfaces;
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
        public Engine(IHeroFactory factory)
        {
            heroes=new List<IBaseHero>();
            CreateHero= factory;
        }
        public void Run()
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string name = Console.ReadLine();

                string type = Console.ReadLine();

                heroes.Add(CreateHero.Create(type, name));
            }

            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility()); 
            }
            int bossPower = int.Parse(Console.ReadLine());

            if (heroes.Sum(x=>x.Power)>= bossPower)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
    }
}
