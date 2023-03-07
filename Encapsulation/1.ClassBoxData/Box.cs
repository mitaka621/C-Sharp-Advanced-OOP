using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        double length,width,height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
           
        }

        private double Length { get=>length; set { if (value <= 0) throw new ArgumentException("Length cannot be zero or negative."); else length = value; } }
        private double  Width { get => width; set { if (value <= 0) throw new ArgumentException("Width cannot be zero or negative."); else width = value; } }
        private double Height { get => height; set { if (value <= 0) throw new ArgumentException("Height cannot be zero or negative."); else height = value; } }

        public double SurfaceArea()
        {
            return 2 * length * width + 2 * length * height + 2 * height * width;
        }
        public double LateralSurfaceArea()
        {
            return 2 * height*(length + width);
        }

        public double Volume()
        {
            return length * width * height;
        }
    }
}
