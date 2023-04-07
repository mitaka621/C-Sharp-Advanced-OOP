using Heroes.Core.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Weapons;
using Heroes.Models.Contracts;
using Heroes.Models.Map;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons ;
        public Controller()
        {
            heroes=new HeroRepository();
            weapons=new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (heroes.FindByName(heroName).Weapon!=null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            heroes.FindByName(heroName).AddWeapon(weapons.FindByName(weaponName));
            return $"Hero {heroName} can participate in battle using a {weapons.FindByName(weaponName).GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name)!=null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type == "Barbarian")
            {
                heroes.Add(new Barbarian(name, health, armour));
                return $"Successfully added Barbarian {name} to the collection.";
            }
            else if (type == "Knight")
            {
                heroes.Add(new Knight(name, health, armour));
                return $"Successfully added Sir { name } to the collection.";
            }
            else
                throw new InvalidOperationException("Invalid hero type.");

        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name)!=null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            if (type == "Claymore")
            {
                weapons.Add(new Claymore(name, durability));
                return $"A {type.ToLower()} {name} is added to the collection.";
            }
            else if (type == "Mace")
            {
                weapons.Add(new Mace(name, durability));
                return $"A {type.ToLower()} {name} is added to the collection.";
            }
            else
                throw new InvalidOperationException("Invalid weapon type.");
        }

        public string HeroReport()
        {
            var list = heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name);
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendLine(item.GetType().Name + ": " + item.Name);
                sb.AppendLine($"--Health: {item.Health}");
                sb.AppendLine($"--Armour: {item.Armour}");
                if (item.Weapon==null)
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
                else
                    sb.AppendLine($"--Weapon: {item.Weapon.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            return map.Fight((List<IHero>)heroes.Models);
        }
    }
}
