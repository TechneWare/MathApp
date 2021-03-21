using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Data
{
    interface IDataContext
    {
        List<IShape> GetAllShapes();
    }
}
