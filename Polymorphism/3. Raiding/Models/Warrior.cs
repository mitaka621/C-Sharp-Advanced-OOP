using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Warrior:BaseHero
    {
        private const int CurrentPower = 100;
        public Warrior(string name) : base(name)
        {
        }

        public override int Power => CurrentPower;
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} " + $"hit for {Power} damage";
        }
    }
}
