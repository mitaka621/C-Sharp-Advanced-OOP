using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        AstronautRepository astronauts;
        PlanetRepository planets;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository(); 
        }
        public string AddAstronaut(string type, string astronautName)
        {
            if (type == "Biologist")
            {
                astronauts.Add(new Biologist(astronautName));
                return $"Successfully added {type}: {astronautName}!";
            }
            else if (type == "Geodesist")
            {
                astronauts.Add(new Geodesist(astronautName));
                return $"Successfully added {type}: {astronautName}!";
            }
            else if (type == "Meteorologist")
            {
                astronauts.Add(new Meteorologist(astronautName));
                return $"Successfully added {type}: {astronautName}!";
            }
            else
                throw new InvalidOperationException("Astronaut type doesn't exists!");
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            planets.Add(new Planet(planetName));
            foreach (var item in items)
            {
                planets.FindByName(planetName).Items.Add(item);
            }
            return $"Successfully added Planet: {planetName}!";
        }
        private int exploredPlanetsCount = 0;
        public string ExplorePlanet(string planetName)
        {
            if (!astronauts.Models.Where(x => x.Oxygen > 60).Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }
            Mission mis1 = new Mission();
            mis1.Explore(planets.FindByName(planetName), astronauts.Models.Where(x => x.Oxygen > 60).ToList());

            exploredPlanetsCount++;
            return $"Planet: {planetName} was explored! Exploration finished with {mis1.astronauts.Where(x => !x.CanBreath).ToList().Count} dead astronauts!";

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var item in astronauts.Models)
            {
                sb.AppendLine($"Name: {item.Name}");
                sb.AppendLine($"Oxygen: {item.Oxygen}");
                sb.Append($"Bag items: ");
                if (item.Bag.Items.Any())
                {
                    sb.AppendLine(String.Join(", ", item.Bag.Items));
                }
                else
                    sb.AppendLine($"none");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (astronauts.FindByName(astronautName)==null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astronauts.Remove(astronauts.FindByName(astronautName));
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
