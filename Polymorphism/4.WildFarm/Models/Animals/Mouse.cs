using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double modifier = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> foods { get; } = new HashSet<Type>() {  typeof(Fruit), typeof(Vegetable) };

        public override double WeightMultiplyer => modifier;

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
