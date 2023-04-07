using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Race
{
    public class Race : IRace
    {
        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            pilots = new List<IPilot>();
        }
        private string raceName;

        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: { value}.");
                }
                raceName = value;
            }
        }
        private int numberOfLaps;

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {

                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                numberOfLaps = value;
            }
        }
        

        public bool TookPlace { get; set; } =false;


        private ICollection<IPilot> pilots;

        public ICollection<IPilot> Pilots
        {
            get { return pilots; }
            private set { pilots = value; }
        }

      

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {raceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {numberOfLaps}");
            if (TookPlace)
            {
                sb.AppendLine($"Took place: Yes");
            }
            else
                sb.AppendLine($"Took place: No");
            return sb.ToString().TrimEnd();

        }
    }
}
