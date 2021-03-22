using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands.ShapeFactory
{
    public class TriangleFactory : IShapeFactory
    {
        public IShapeFactory Next { get; set; }

        public IShape MakeShape(string[] args)
        {
            IShape result = null;

            if (args.Length > 1)
            {
                var type = args[1].ToLower();
                if (type.ToLower().StartsWith("t"))
                    if (args.Length == 6
                    && double.TryParse(args[3], out double a)
                    && double.TryParse(args[4], out double b)
                    && double.TryParse(args[5], out double c))
                    {
                        var name = args[2];
                        result = new Triangle(name, a, b, c);
                    }
                    else
                        Console.WriteLine("usage: add triangle name [sideA] [sideB] [sideC]");
                else if (Next != null)
                    result = Next.MakeShape(args);
            }

            return result;
        }
    }
}
