using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands.ShapeFactory
{
    public interface IShapeFactory
    {
        IShapeFactory Next { get; set; }
        IShape MakeShape(string[] args);
    }
}
