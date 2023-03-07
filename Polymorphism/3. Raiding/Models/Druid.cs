using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Druid:BaseHero
    {
        private const int CurrentPower = 80;

        public Druid(string name) : base(name)
        {
        }

        public override int Power => CurrentPower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} " + $"healed for {Power}";
        }
    }
}
