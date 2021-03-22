using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands.ShapeFactory
{
    public class SquareFactory : IShapeFactory
    {
        public IShapeFactory Next { get; set; }

        public IShape MakeShape(string[] args)
        {
            IShape result = null;

            if (args.Length > 1)
            {
                var type = args[1].ToLower();
                if (type.ToLower().StartsWith("s"))
                    if (args.Length == 4 && double.TryParse(args[3], out double width))
                    {
                        var name = args[2];
                        result = new Square(name, width);
                    }
                    else
                        Console.WriteLine("usage: add square name [width]");
                else if (Next != null)
                    result = Next.MakeShape(args);
            }

            return result;
        }
    }
}
