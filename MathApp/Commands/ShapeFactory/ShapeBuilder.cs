using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands.ShapeFactory
{
    public class ShapeBuilder
    {
        private IList<IShapeFactory> factories;

        public ShapeBuilder(IEnumerable<IShapeFactory> availableShapeFactories)
        {
            factories = (IList<IShapeFactory>)availableShapeFactories;
            for (int i = 0; i < factories.Count() - 1; i++)
                factories[i].Next = factories[i + 1];
        }

        public IShape Build(string[] args)
        {
            IShape result = factories?.First().MakeShape(args);
            return result;
        }
    }
}
