using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Shapes
{
    public class Circle : Shape
    {
        public override double Perimeter => 2 * Math.PI * Radius;
        public override double Area => Math.PI * Math.Pow(Radius, 2);
        public double Radius => Sides[0];

        public Circle(string name, double Radius) : base(name: name, new double[] { Radius }, ShapeType.Circle, "")
        {
            this.SubType = CircleType.Flat.ToString();
        }
    
        [JsonConstructor]
        public Circle(string name, double[] Sides) : base(name: name, Sides, ShapeType.Circle, "") { }
    }
}
