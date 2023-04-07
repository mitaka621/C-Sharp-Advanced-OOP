using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        public Captain(string fullName)
        {
            FullName = fullName;
            vessels = new List<IVessel>();
        }
        private string fullName;

        public string FullName
        {
            get { return fullName; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                fullName = value;
            }
        }

        public int CombatExperience { get; private set; } = 0;

        private ICollection<IVessel> vessels;

        public ICollection<IVessel> Vessels
        {
            get { return vessels; }
           private set { vessels = value; }
        }

     

        public void AddVessel(IVessel vessel)
        {
            if (vessels == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            if (vessels.Any())
            {
                foreach (var item in vessels)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
