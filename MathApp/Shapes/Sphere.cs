using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Shapes
{
    public class Sphere : Circle
    {
        public override double Area => 4 * Math.PI * Math.Pow(this.Radius, 2);
        public Sphere(string name, double Radius) : base(name, Radius)
        {
            this.SubType = CircleType.Sphere.ToString();
        }
    }
}
