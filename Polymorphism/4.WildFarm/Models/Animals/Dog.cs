﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double modifier = 0.4;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> foods { get; } = new HashSet<Type>() { typeof(Meat)};

        public override double WeightMultiplyer => modifier;

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
