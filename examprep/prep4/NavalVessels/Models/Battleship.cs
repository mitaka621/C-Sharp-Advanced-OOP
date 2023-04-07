using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
        }

        public bool SonarMode { get; private set; } = false;
        

        public override void RepairVessel()
        {
            if (ArmorThickness<300)
            {
                ArmorThickness = 300;
            }
            
        }

        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            string str= " *Sonar mode: ";
            if (SonarMode)
            {
                str += "ON";
            }
            else
                str += "OFF";
            return base.ToString()+ Environment.NewLine+ str;
        }
    }
}
