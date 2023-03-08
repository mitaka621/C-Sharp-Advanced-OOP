using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double modifier = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> foods { get; } = new HashSet<Type>() { typeof(Meat) };

        public override double WeightMultiplyer => modifier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
