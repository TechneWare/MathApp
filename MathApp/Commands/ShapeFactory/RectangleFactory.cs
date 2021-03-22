using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands.ShapeFactory
{
    public class RectangleFactory : IShapeFactory
    {
        public IShapeFactory Next { get; set; }

        public IShape MakeShape(string[] args)
        {
            IShape result = null;

            if (args.Length > 1)
            {
                var type = args[1].ToLower();
                if (type.ToLower().StartsWith("r"))
                    if (args.Length == 5
                        && double.TryParse(args[3], out double w)
                        && double.TryParse(args[4], out double l))
                    {
                        var name = args[2];
                        result = new Rectangle(name, w, l);
                    }
                    else
                        Console.WriteLine("usage: add rectangle name [width] [length]");
                else if (Next != null)
                    result = Next.MakeShape(args);
            }

            return result;
        }
    }
}
