using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        private string[] unitTypes = new string[] { "AnonymousImpactUnit", "SpaceForces", "StormTroopers" };
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!unitTypes.Contains(unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            if (planets.Models.First(x => x.Name == planetName).Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            if (unitTypeName == "AnonymousImpactUnit")
            {
                planets.Models.First(x => x.Name == planetName).Spend(new AnonymousImpactUnit().Cost);
                planets.Models.First(x => x.Name == planetName).AddUnit(new AnonymousImpactUnit());
            }
            if (unitTypeName == "SpaceForces")
            {
                planets.Models.First(x => x.Name == planetName).Spend(new SpaceForces().Cost);
                planets.Models.First(x => x.Name == planetName).AddUnit(new SpaceForces());
            }
            if (unitTypeName == "StormTroopers")
            {
                planets.Models.First(x => x.Name == planetName).Spend(new StormTroopers().Cost);
                planets.Models.First(x => x.Name == planetName).AddUnit(new StormTroopers());
            }
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        private string[] weaponTypes = new string[] { "NuclearWeapon", "SpaceMissiles", "BioChemicalWeapon" };
        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (planets.Models.First(x => x.Name == planetName).Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }
            if (!weaponTypes.Contains(weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            if (weaponTypeName == "NuclearWeapon")
            {
                planets.Models.First(x => x.Name == planetName).Spend(new NuclearWeapon(destructionLevel).Price);
                planets.Models.First(x => x.Name == planetName).AddWeapon(new NuclearWeapon(destructionLevel));
               
            }
            if (weaponTypeName == "SpaceMissiles")
            {
                planets.Models.First(x => x.Name == planetName).Spend(new SpaceMissiles(destructionLevel).Price);
                planets.Models.First(x => x.Name == planetName).AddWeapon(new SpaceMissiles(destructionLevel));
              
            }
            if (weaponTypeName == "BioChemicalWeapon")
            {
                planets.Models.First(x => x.Name == planetName).Spend(new BioChemicalWeapon(destructionLevel).Price);
                planets.Models.First(x => x.Name == planetName).AddWeapon(new BioChemicalWeapon(destructionLevel));
                
            }
            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(x => x.Name == name))
            {
                return $"Planet {name} is already added!";
            }

            planets.AddItem(new Planet(name, budget));
            return $"Successfully added Planet: {name}";
        }

        public string ForcesReport()
        {
            var list = planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var item in list)
            {
                sb.AppendLine(item.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planets.Models.First(x => x.Name == planetOne);
            IPlanet planet2 = planets.Models.First(x => x.Name == planetTwo);
            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    planets.Models.First(x => x.Name == planetOne).Spend(planet1.Budget / 2.0);
                    planets.Models.First(x => x.Name == planetOne).Profit(planet2.Budget / 2.0);
                    double forcesCost = 0;
                    foreach (var item in planet2.Army)
                    {
                        forcesCost += item.Cost;

                    }
                    foreach (var item in planet2.Weapons)
                    {
                        forcesCost += item.Price;

                    }
                    planets.Models.First(x => x.Name == planetOne).Profit(forcesCost);
                    planets.RemoveItem(planetTwo);
                    return $"{planetOne} destructed {planetTwo}!";
                }
                else
                    if (planet2.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    planets.Models.First(x => x.Name == planetOne).Spend(planet2.Budget / 2.0);
                    planets.Models.First(x => x.Name == planetOne).Profit(planet1.Budget / 2.0);
                    double forcesCost = 0;
                    foreach (var item in planet1.Army)
                    {
                        forcesCost += item.Cost;

                    }
                    foreach (var item in planet1.Weapons)
                    {
                        forcesCost += item.Price;

                    }
                    planets.Models.First(x => x.Name == planetTwo).Profit(forcesCost);
                    planets.RemoveItem(planetOne);
                    return $"{planetTwo} destructed {planetOne}!";
                }
                else
                {
                    planets.Models.First(x => x.Name == planetOne).Spend(planet1.Budget / 2.0);
                    planets.Models.First(x => x.Name == planetTwo).Spend(planet2.Budget / 2.0);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
            }
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                planets.Models.First(x => x.Name == planetOne).Spend(planet1.Budget / 2.0 );
                planets.Models.First(x => x.Name == planetOne).Profit(planet2.Budget / 2.0);
                double forcesCost = 0;
                foreach (var item in planet2.Army)
                {
                    forcesCost += item.Cost;

                }
                foreach (var item in planet2.Weapons)
                {
                    forcesCost += item.Price;

                }
                planets.Models.First(x => x.Name == planetOne).Profit(forcesCost);
                planets.RemoveItem(planetTwo);
                return $"{planetOne} destructed {planetTwo}!";
            }
            else
            {
                planets.Models.First(x => x.Name == planetOne).Spend(planet2.Budget / 2.0);
                planets.Models.First(x => x.Name == planetOne).Profit(planet1.Budget / 2.0);
                double forcesCost = 0;
                foreach (var item in planet1.Army)
                {
                    forcesCost += item.Cost;

                }
                foreach (var item in planet1.Weapons)
                {
                    forcesCost += item.Price;

                }
                planets.Models.First(x => x.Name == planetTwo).Profit(forcesCost);
                planets.RemoveItem(planetOne);
                return $"{planetTwo} destructed {planetOne}!";
            }

        }

        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!planets.Models.First(x => x.Name == planetName).Army.Any())
            {
                throw new InvalidOperationException($"No units available for upgrade!");
            }
            planets.Models.First(x => x.Name == planetName).TrainArmy();
            planets.Models.First(x => x.Name == planetName).Spend(1.25);
            return $"{planetName} has upgraded its forces!";
        }
    }
}
