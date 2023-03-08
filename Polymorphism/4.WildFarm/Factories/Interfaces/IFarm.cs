using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace Raiding.Factories.Interfaces
{
    public interface IFarm
    {
        IAnimal CreateAnimal(string[] args);
        IFood CreateFood(string[] args);
    }
}
