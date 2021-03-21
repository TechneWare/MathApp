using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Shapes
{
    public class Cylinder : Circle
    {
        public override double Area => 2 * Math.PI * Radius * Height;

        public double Height => Sides[1];

        public Cylinder(string name, double Radius, double Height) : base(name, new double[] { Radius, Height })
        {
            this.SubType = CircleType.Cylinder.ToString();
        }
    }
}
