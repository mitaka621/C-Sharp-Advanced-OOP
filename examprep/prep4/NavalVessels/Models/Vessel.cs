using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }
        private string name;

        public string Name
        {
            get { return name; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                name = value;
            }
        }

        private ICaptain captain;

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value==null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                captain = value;
            }
        }


        private double armorThickness;

        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }


        private double mainWeaponCaliber;

        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
           protected set { mainWeaponCaliber = value; }
        }


        private double speed;

        public double Speed
        {
            get { return speed; }
           protected set { speed = value; }
        }



        private ICollection<string> targets;

        public ICollection<string> Targets
        {
            get { return targets; }
            private set { targets = value; }
        }

     

        public void Attack(IVessel target)
        {
            if (target==null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }

            if (target.ArmorThickness- mainWeaponCaliber<0)
            {
                target.ArmorThickness = 0;
            }
            else
            target.ArmorThickness -= mainWeaponCaliber;

            Targets.Add(target.Name);
        }

        public abstract void RepairVessel();
       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {armorThickness}");
            sb.AppendLine($" *Main weapon caliber: {mainWeaponCaliber}");
            sb.AppendLine($" *Speed: {speed} knots");
            sb.Append($" *Targets: ");
            if (targets.Any())
            {
                sb.AppendLine(String.Join(", ",targets));
            }
            else
                sb.AppendLine("None");

            return sb.ToString().TrimEnd();
        }
    }
}
