﻿using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        List<IVessel> models;
        public IReadOnlyCollection<IVessel> Models => models;
        public VesselRepository()
        {
            models=new List<IVessel>();
        }

        public void Add(IVessel model)
        {
           models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
           return models.Remove(model);
        }
    }
}
