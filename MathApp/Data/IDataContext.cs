using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Data
{
    public interface IDataContext
    {
        IEnumerable<IShape> GetAllShapes(SortBy sortBy);
    }
}
