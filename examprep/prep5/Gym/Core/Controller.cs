using Gym.Core.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        EquipmentRepository equipment;
        ICollection<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();

        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType == "Boxer")
            {
                if (gyms.First(x=>x.Name==gymName).GetType().Name!= "BoxingGym")
                {
                    return "The gym is not appropriate.";
                }
                gyms.First(x => x.Name == gymName).AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
                return $"Successfully added {athleteType} to {gymName}.";
            }
            else if (athleteType == "Weightlifter")
            {
                if (gyms.First(x => x.Name == gymName).GetType().Name != "WeightliftingGym")
                {
                    return "The gym is not appropriate.";
                }
                gyms.First(x => x.Name == gymName).AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
                return $"Successfully added {athleteType} to {gymName}.";
            }
            else
                throw new InvalidOperationException("Invalid athlete type.");
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                equipment.Add(new BoxingGloves());
                return $"Successfully added {equipmentType}.";
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment.Add(new Kettlebell());
                return $"Successfully added {equipmentType}.";
            }
            else
                throw new InvalidOperationException("Invalid equipment type.");
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
                return $"Successfully added {gymType}.";
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));
                return $"Successfully added {gymType}.";
            }
            else
                throw new InvalidOperationException("Invalid gym type.");
        }

        public string EquipmentWeight(string gymName)
        {
            return $"The total weight of the equipment in the gym {gymName} is {gyms.First(x => x.Name == gymName).EquipmentWeight:F2} grams.";
            ;
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (equipment.FindByType(equipmentType)==null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            gyms.First(x => x.Name == gymName).AddEquipment(equipment.FindByType(equipmentType));
            equipment.Remove(equipment.FindByType(equipmentType));
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in gyms)
            {
                sb.AppendLine(item.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            gyms.First(x => x.Name == gymName).Exercise();
            return $"Exercise athletes: {gyms.First(x => x.Name == gymName).Athletes.Count}.";
        }
    }
}
