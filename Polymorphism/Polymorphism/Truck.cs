using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(string name, double fuelQuantity, double fuelConsumption,double capacity) : base(name, fuelQuantity, fuelConsumption+=1.6,capacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            FuelQuantity -= liters * 0.05;
        }
    }
}
