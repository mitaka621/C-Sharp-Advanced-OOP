using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(string name, double fuelQuantity, double fuelConsumption,double capacity) : base(name, fuelQuantity,fuelConsumption+=0.9,capacity)
        {
        }

       
    }
}
