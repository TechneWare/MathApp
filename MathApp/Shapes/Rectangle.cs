using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Shapes
{
    public class Rectangle : Quadrilateral
    {
        public Rectangle(string Name, double Width, double Length) 
            : base(Name, new double[] { Width, Length, Width, Length })
        { }
    }
}
