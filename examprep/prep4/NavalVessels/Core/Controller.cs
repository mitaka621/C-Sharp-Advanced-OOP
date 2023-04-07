using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        VesselRepository vessels;
        ICollection<ICaptain> captains ;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.Any(x=>x.FullName==selectedCaptainName))
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            if (vessels.FindByName(selectedVesselName)==null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if (vessels.FindByName(selectedVesselName).Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            vessels.FindByName(selectedVesselName).Captain = captains.First(x => x.FullName == selectedCaptainName);
            captains.First(x => x.FullName == selectedCaptainName).AddVessel(vessels.FindByName(selectedVesselName));
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            if (vessels.FindByName(attackingVesselName)==null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (vessels.FindByName(defendingVesselName) == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (vessels.FindByName(attackingVesselName).ArmorThickness==0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (vessels.FindByName(defendingVesselName).ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            vessels.FindByName(attackingVesselName).Attack(vessels.FindByName(defendingVesselName));
            captains.First(x => x.FullName == vessels.FindByName(attackingVesselName).Captain.FullName).IncreaseCombatExperience();

            captains.First(x => x.FullName == vessels.FindByName(defendingVesselName).Captain.FullName).IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {vessels.FindByName(defendingVesselName).ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            return captains.First(x => x.FullName == captainFullName).Report();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(x=>x.FullName==fullName))
            {
                return $"Captain {fullName} is already hired.";
            }
            captains.Add(new Captain(fullName));
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name)!=null)
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }
            if (vesselType == "Submarine")
            {
                vessels.Add(new Submarine(name, mainWeaponCaliber, speed));
                return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
            }
            else if (vesselType == "Battleship")
            {
                vessels.Add(new Battleship(name, mainWeaponCaliber, speed));
                return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
            }
            else
            {
                return "Invalid vessel type.";
            }
        }

        public string ServiceVessel(string vesselName)
        {
            if (vessels.FindByName(vesselName)==null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            vessels.FindByName(vesselName).RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            if (vessels.FindByName(vesselName)==null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            if (vessels.FindByName(vesselName).GetType().Name == "Battleship")
            {
                (vessels.FindByName(vesselName) as Battleship).ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                (vessels.FindByName(vesselName) as Submarine).ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
        } 

        public string VesselReport(string vesselName)
        {
            return vessels.FindByName(vesselName).ToString();
        }
    }
}
