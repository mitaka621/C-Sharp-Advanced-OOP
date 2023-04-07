using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository:IRepository<IPlanet>
    {
        public PlanetRepository() 
        {
            planets = new List<IPlanet>();
        }
        private List<IPlanet> planets;
        public IReadOnlyCollection<IPlanet> Models => planets;

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return planets.Remove(planets.FirstOrDefault(x => x.Name == name));
        }
    }
}
