using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Shapes
{
    public abstract class Polygon : Shape
    {
        protected Polygon(string Name, double[] Sides, ShapeType shapeType) : base(Name, Sides, shapeType, "")
        { }
    }
}
