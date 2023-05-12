using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        List<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models => models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }
        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return models.Remove(model);
        }
    }
}
