using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract int Power { get; }

        public abstract string CastAbility();
        
    }
}
