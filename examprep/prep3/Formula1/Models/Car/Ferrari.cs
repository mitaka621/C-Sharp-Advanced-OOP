﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Car
{
    public class Ferrari : FormulaOneCar
    {
        public Ferrari(string model, int horsepower, double engineDisplacement) : base(model, horsepower, engineDisplacement)
        {
        }
    }
}
