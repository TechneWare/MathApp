using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Data
{
    public class InMemoryDataContext : IDataContext
    {
        private List<IShape> shapes;
        public List<IShape> GetAllShapes()
        {
            return shapes;
        }

        public InMemoryDataContext()
        {
            shapes = new List<IShape>()
            {
                new Circle("C1", 1),
                new Circle("C2", 2),
                new Circle("C3", 3),
                new Triangle("T1",1,1,1),
                new Triangle("T2",1,1,2),
                new Triangle("T3",1,2,3),
                new Square("SQ1", 1),
                new Square("SQ2", 2),
                new Square("SQ3", 3),
                new Rectangle("Rect1",1,2),
                new Rectangle("Rect2",2,3),
                new Rectangle("Rect3",3,4),
            };
        }
    }
}
