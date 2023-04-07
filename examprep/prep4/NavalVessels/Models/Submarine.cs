using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {
        }

        public bool SubmergeMode { get; private set; } = false;
        

        public override void RepairVessel()
        {
            if (ArmorThickness<200)
            {
                ArmorThickness = 200;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (!SubmergeMode)
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override string ToString()
        {
            string str= " *Submerge mode: ";
            if (SubmergeMode)
            {
                str+= "ON";
            }
            else
                str += "OFF";
            return base.ToString() + Environment.NewLine+ str;
        }
    }
}
