using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int CurrentPower = 80;
        public Rogue(string name) : base(name)
        {
        }

        public override int Power => CurrentPower;
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} " + $"hit for {Power} damage";
        }
    }
}
