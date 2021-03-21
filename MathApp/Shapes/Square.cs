using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Shapes
{
    public class Square : Quadrilateral
    {
        public Square(string Name, double Width) 
            : base(Name, new double[] { Width, Width, Width, Width })
        { }
    }
}
