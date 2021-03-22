using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands.ShapeFactory
{
    public class CircleFactory : IShapeFactory
    {
        public IShapeFactory Next { get; set; }

        public IShape MakeShape(string[] args)
        {
            IShape result = null;

            if (args.Length > 1)
            {
                var type = args[1].ToLower();
                if (type.ToLower().StartsWith("c"))
                    if (args.Length == 4 && double.TryParse(args[3], out double radius))
                    {
                        var name = args[2];
                        result = new Circle(name, radius);
                    }
                    else
                        Console.WriteLine("usage: add circle name [radius]");
                else if (Next != null)
                    result = Next.MakeShape(args);
            }

            return result;
        }
    }
}
