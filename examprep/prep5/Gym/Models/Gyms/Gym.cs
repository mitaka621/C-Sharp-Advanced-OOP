using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Equipment = new List<IEquipment>();
            Athletes = new List<IAthlete>();
        }
        private string name;

        public string Name
        {
            get { return name; }
           private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value;
            }
        }


        public int Capacity { get;private set; }
       

        public double EquipmentWeight => Equipment.Sum(x=>x.Weight);

        public ICollection<IEquipment> Equipment { get;private set; }

        public ICollection<IAthlete> Athletes { get; private set; }
        

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count== Capacity)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var item in Athletes)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{name} is a {GetType().Name}:");
            sb.Append($"Athletes: ");
            if (!Athletes.Any())
            {
                sb.AppendLine($"No athletes");
            }
            else
            {
                List<string> names = new List<string>();
                foreach (var item in Athletes)
                {
                    names.Add(item.FullName);
                }
                sb.AppendLine(String.Join(", ", names));
            }
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
