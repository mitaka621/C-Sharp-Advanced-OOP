using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int CurrentPower = 100;
        public Paladin(string name) : base(name)
        {
        }

        public override int Power => CurrentPower;
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} " + $"healed for {Power}";
        }
    }
}
