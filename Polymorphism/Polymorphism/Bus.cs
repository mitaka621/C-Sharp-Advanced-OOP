using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(string name, double fuelQuantity, double fuelConsumption, double tankCapacity) : base(name, fuelQuantity, fuelConsumption+=1.4, tankCapacity)
        {
        }
        public string DriveEmpty(double distance)
        {
            FuelConsumption -= 1.4;
           string str= base.Drive(distance);
            FuelConsumption += 1.4;
            return str;
        }
    }
}
