﻿using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                name = value;
            }
        }

        private int durability;

        public int Durability
        {
            get { return durability; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durability = value;
            }
        }   

        public int DoDamage()
        {
            if (this.GetType().Name == "Mace")
            {
                
                if (Durability>0)
                {
                    Durability -= 1;
                }
                return 25;
            }
            else
            {
                if (Durability > 0)
                {
                    Durability -= 1;
                }
               
                return 20;
            }
        }
    }
}
