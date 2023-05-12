using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
       public ICollection<IAstronaut> astronauts = new List<IAstronaut>();
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astr in astronauts.Where(x=>x.CanBreath))
            {
                while (planet.Items.Any())
                {
                    astr.Breath();
                    astr.Bag.Items.Add(planet.Items.ToList()[0]);
                    planet.Items.Remove(planet.Items.ToList()[0]);
                    if (!astr.CanBreath)
                    {
                        break;
                    }
                }
                
            }

            this.astronauts = astronauts;
        }
    }
}
