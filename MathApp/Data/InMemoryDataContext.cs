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
        private IList<IShape> shapes;
        public IEnumerable<IShape> GetAllShapes(SortBy sortBy = SortBy.None)
        {
            IEnumerable<IShape> result = null;

            switch (sortBy)
            {
                case SortBy.Area:
                    result = shapes.OrderBy(s => s.Area);
                    break;
                case SortBy.Parimiter:
                    result = shapes.OrderBy(s => s.Perimeter);
                    break;
                case SortBy.None:
                default:
                    result = shapes;
                    break;
            }

            return result;
        }

        public bool AddShape(IShape shape)
        {
            shapes.Add(shape);
            return true;
        }
        public bool ClearShapes()
        {
            shapes.Clear();
            return true;
        }
        public bool DeleteShape(string shapeName)
        {
            var result = false;
            
            var s = shapes.Where(sh => sh.Name.ToLower() == shapeName.ToLower()).FirstOrDefault();
            if (s != null)
            {
                shapes.Remove(s);
                result = true;
            }

            return result;
        }
        
        public InMemoryDataContext()
        {
            shapes = new List<IShape>()
            {
                new Circle("C1", 1),
                new Circle("C2", 2),
                new Circle("C3", 3),
                new Sphere("SPH1", 1),
                new Sphere("SPH2", 10),
                new Sphere("SPH3", 5),
                new Cylinder("CYL1", 1, 10),
                new Cylinder("CYL2", 2, 15),
                new Cylinder("CYL3", 10, 40),
                new Triangle("T1",1,1,1),
                new Triangle("T2",13,4.8,10),
                new Triangle("T3",5.3,6,11.1),
                new Triangle("T4",10,10,12),
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
