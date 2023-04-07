using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public Weapon(int destructionLevel, double price)
        {
            DestructionLevel = destructionLevel;
            Price = price;
        }
        private double price;

        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        private int destructionLevel;

        public int DestructionLevel
        {
            get { return destructionLevel; }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                if (value>10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }
                destructionLevel = value;
            }
        }

       
    }
}
