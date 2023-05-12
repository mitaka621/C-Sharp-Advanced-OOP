﻿using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException ( "Astronaut name cannot be null or empty.");
                }
                name = value;
            }
        }

        private double oxygen;

        public double Oxygen
        {
            get { return oxygen; }
           protected set 
            {
                if (value<0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value;
            }
        }


      

        public bool CanBreath => oxygen>0;

        public IBag Bag { get; private set; }
     

        public virtual void Breath()
        {
            if (Oxygen-10<0)
            {
                Oxygen = 0;
            }
            else
            Oxygen -= 10;
        }
    }
}
