using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Shapes
{
    public abstract class Quadrilateral : Polygon
    {
        private enum QuadrilateralType
        {
            Unknown,
            Square,
            Rectangle
        }
        public override double Perimeter => Sides.Sum();

        public override double Area => Sides[0] * Sides[1];

        public Quadrilateral(string Name, double[] Sides) : base(Name, Sides, ShapeType.Quadrilateral)
        {
            var distinctLengths = Sides.Distinct().Count();
            switch (distinctLengths)
            {
                case 1:
                    this.SubType = QuadrilateralType.Square.ToString();
                    break;
                case 2:
                    this.SubType = QuadrilateralType.Rectangle.ToString();
                    break;
                default:
                    this.SubType = QuadrilateralType.Unknown.ToString();
                    break;
            }
        }
    }
}
