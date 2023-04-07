using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
     
        UnitRepository units;
        WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units=new UnitRepository();
            weapons=new WeaponRepository();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }
                name = value;
            }
        }

        private double budget;

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }
                budget = value;
            }
        }


        private double militaryPower;

        public double MilitaryPower
        {
            get
            {
                militaryPower = units.Models.Sum(x => x.EnduranceLevel) + weapons.Models.Sum(x => x.DestructionLevel);
                if (units.Models.Any(x=>x.GetType().Name== "AnonymousImpactUnit"))
                {
                    militaryPower += militaryPower * 0.3;
                }
                if (weapons.Models.Any(x=>x.GetType().Name== "NuclearWeapon"))
                {
                    militaryPower += militaryPower * 0.45;
                }
  
                return Math.Round(militaryPower, 3);
            }
            private set { militaryPower = value; }
        }


        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons=>weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }
        public void TrainArmy()
        {
            foreach (var item in units.Models)
            {
                item.IncreaseEndurance();
            }
        }
        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Planet: " + name);
            sb.AppendLine($"--Budget: {budget} billion QUID");
            sb.Append("--Forces: ");
            if (!units.Models.Any())
            {
                sb.AppendLine("No units");
            }
            else
            {
                List<string> names=new List<string>();
                foreach (var item in units.Models)
                {
                    names.Add(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ",names));
            }
            sb.Append("--Combat equipment: ");
            if (!weapons.Models.Any())
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                List<string> names = new List<string>();
                foreach (var item in weapons.Models)
                {
                    names.Add(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", names));
            }
            sb.AppendLine($"--Military Power: {militaryPower}");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            budget+=amount;
        }

        public void Spend(double amount)
        {
            if (budget- amount<0)
            {
                throw new InvalidOperationException("Budget too low!");
            }
            budget-= amount;
        }

       
    }
}
