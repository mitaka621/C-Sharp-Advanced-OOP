using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            ICollection<IHero> knights = players.Where(x => x.GetType().Name == "Knight"&&x.IsAlive&&x.Weapon!=null&&x.Weapon.Durability>0).ToList();
            ICollection<IHero> barbarians = players.Where(x => x.GetType().Name == "Barbarian" && x.IsAlive && x.Weapon != null && x.Weapon.Durability > 0).ToList();
            while (knights.Sum(x => x.Health) != 0 && barbarians.Sum(x => x.Health) != 0)
            {
                foreach (var knight in knights.Where(x => x.IsAlive && x.Weapon.Durability > 0))
                {
                    foreach (var barbarian in barbarians.Where(x => x.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarians.Where(x => x.IsAlive && x.Weapon.Durability > 0))
                {
                    foreach (var knight in knights.Where(x => x.IsAlive))
                    {

                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            if (knights.Sum(x => x.Health) == 0)
            {
                return $"The barbarians took {barbarians.Count(x => x.IsAlive == false)} casualties but won the battle.";
            }
            else
                return $"The knights took {knights.Count(x => x.IsAlive == false)} casualties but won the battle.";
        }
    }
}
