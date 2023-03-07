using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    internal class HeroFactory : IHeroFactory
    {
        public IBaseHero Create(string type, string name)
        {
            IBaseHero baseHero = null;
            switch (type)
            {
                case "Druid":
                    baseHero = new Druid(name);
                    break;
                case "Paladin":
                    baseHero = new Paladin(name);
                    break;
                case "Rogue":
                    baseHero = new Rogue(name);
                    break;
                case "Warrior":
                    baseHero = new Warrior(name);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");

                    
            }
            return baseHero;
        }
    }
}
