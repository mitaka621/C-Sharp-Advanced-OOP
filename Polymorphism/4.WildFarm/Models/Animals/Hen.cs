using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double modifier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> foods { get; } = new HashSet<Type>() { typeof(Meat),typeof(Fruit),typeof(Seeds),typeof(Vegetable) };

        public override double WeightMultiplyer => modifier;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
