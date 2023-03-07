using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity=0;
        public Vehicle(string name, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Name = name;
            
            
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            if (!isFuelValid(fuelQuantity))
                fuelQuantity = 0;
            else
                FuelQuantity = fuelQuantity;

        }

        public string Name { get; }
        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (isFuelValid(value))

                    fuelQuantity += value;

                else throw new ArgumentException($"Cannot fit {value} fuel in the tank");
            }
        }
        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; private set; }

        bool isFuelValid(double fuel) => fuel <= TankCapacity;

        public virtual string Drive(double distance)
        {
            double fuelRequared = distance * FuelConsumption;
            if (FuelQuantity - fuelRequared >= 0)
            {
                FuelQuantity = -fuelRequared;
                return this.GetType().Name + $" travelled {distance} km";
            }
            else
                return this.GetType().Name + " needs refueling";
        }
        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            FuelQuantity =+ liters;
        }

        public override string ToString()
        {
            return this.GetType().Name + $": {FuelQuantity:f2}";
        }
    }
}
