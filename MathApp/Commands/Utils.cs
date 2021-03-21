using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public static class Utils
    {
        public static void DisplayShapes(string title, IEnumerable<IShape> shapes)
        {
            const int pdName = 35;
            const int pdData = 10;
            Console.WriteLine($"\n{title.PadLeft(pdName, ' ')}");

            Console.WriteLine($"{"Name".PadRight(pdName)}{"Area".PadRight(pdData)}{"Perimiter".PadRight(pdData)}");
            Console.WriteLine($"{"".PadRight(pdName - 1, '-')} {"".PadRight(pdData - 1, '-')} {"".PadRight(pdData - 1, '-')}");
            foreach (var s in shapes)
                Console.WriteLine(
                    $"{s.FullName.PadRight(pdName)}" +
                    $"{s.Area:f5}".PadLeft(pdData) +
                    $"{s.Perimeter:f5}".PadLeft(pdData));
        }
        public static void DisplayDataStats(string title, IEnumerable<IShape> shapes)
        {
            Console.WriteLine($"\n{title}");
            var totalShapes = shapes.Count();
            var numCircles = shapes.Where(s => s.ShapeType == ShapeType.Circle).Count();
            var numFlat = shapes.Where(s => s.ShapeType == ShapeType.Circle && s.SubType == "Flat").Count();
            var numSpheres = shapes.Where(s => s.ShapeType == ShapeType.Circle && s.SubType == "Sphere").Count();
            var numCyl = shapes.Where(s => s.ShapeType == ShapeType.Circle && s.SubType == "Cylinder").Count();
            var numTriangles = shapes.Where(s => s.ShapeType == ShapeType.Triangle).Count();
            var numIsosceles = shapes.Where(s => s.ShapeType == ShapeType.Triangle && s.SubType == "Isosceles").Count();
            var numEqualateral = shapes.Where(s => s.ShapeType == ShapeType.Triangle && s.SubType == "Equalateral").Count();
            var numScalene = shapes.Where(s => s.ShapeType == ShapeType.Triangle && s.SubType == "Scalene").Count();
            var numQuadrilaterals = shapes.Where(s => s.ShapeType == ShapeType.Quadrilateral).Count();
            var numSquares = shapes.Where(s => s.ShapeType == ShapeType.Quadrilateral && s.SubType == "Square").Count();
            var numRects = shapes.Where(s => s.ShapeType == ShapeType.Quadrilateral && s.SubType == "Rectangle").Count();
            var unkownTypes = shapes.Where(s => s.ShapeType == ShapeType.Unknown || s.SubType == "Unknown").Count();

            Console.WriteLine($"Circles       : {numCircles}\n" +
                              $"--Flat        : {numFlat}\n" +
                              $"--Spheres     : {numSpheres}\n" +
                              $"--Cylinders   : {numCyl}\n\n" +
                              $"Triangles     : {numTriangles}\n" +
                              $"--Isosceles   : {numIsosceles}\n" +
                              $"--Equalateral : {numEqualateral}\n" +
                              $"--Scalene     : {numScalene}\n\n" +
                              $"Quadrilaterals: {numQuadrilaterals}\n" +
                              $"--Squares     : {numSquares}\n" +
                              $"--Rectangles  : {numRects}\n\n" +
                              $"Total Shapes  : {totalShapes}\n" +
                              $"Unknown Shapes: {unkownTypes}");
        }
    }
}
