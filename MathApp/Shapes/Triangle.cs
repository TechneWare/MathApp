using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Shapes
{
    public class Triangle : Polygon
    {
        private enum TriangleType
        {
            Unknown,
            Equalateral,
            Isosceles,
            Scalene
        }

        public override double Perimeter => Sides.Sum();

        public override double Area
        {
            get
            {
                //Heron's Formula given 3 sides
                var p = this.Perimeter / 2;
                return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
            }
        }

        public Triangle(string Name, double SideA, double SideB, double SideC) 
            : base(Name, new double[] { SideA, SideB, SideC }, ShapeType.Triangle)
        {
            var distinctLenths = Sides.Distinct().Count();
            switch (distinctLenths)
            {
                case 1:
                    this.SubType = TriangleType.Isosceles.ToString();
                    break;
                case 2:
                    this.SubType = TriangleType.Equalateral.ToString();
                    break;
                case 3:
                    this.SubType = TriangleType.Scalene.ToString();
                    break;
                default:
                    this.SubType = TriangleType.Unknown.ToString();
                    break;
            }
        }
    }
}
