using MathApp.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializerOpts = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var db = new Data.InMemoryDataContext();
            var shapesUnsorted = db.GetAllShapes();
            var shapesByArea = db.GetAllShapes().OrderBy(s => s.Area);
            var shapesByParimiter = db.GetAllShapes().OrderBy(s => s.Perimeter);

            DisplayShapes("=== Shapes Unsorted ===", shapesUnsorted);
            DisplayShapes("=== Shapes By Area ===", shapesByArea);
            DisplayShapes("=== Shapes By Parimiter ===", shapesByParimiter);

            string json = JsonConvert.SerializeObject(shapesUnsorted, serializerOpts);
            Console.WriteLine($"\n=== Json Serialized ===\n{json}");
            var deserializedShapes = JsonConvert.DeserializeObject<List<IShape>>(json, serializerOpts);
            DisplayShapes("=== Deserialized Shapes ===", deserializedShapes);

            Console.WriteLine("\n=== Shape Data Stats ===");
            var totalShapes = deserializedShapes.Count();
            var numCircles = deserializedShapes.Where(s => s.ShapeType == ShapeType.Circle).Count();
            var numTriangles = deserializedShapes.Where(s => s.ShapeType == ShapeType.Triangle).Count();
            var numIsosceles = deserializedShapes.Where(s => s.ShapeType == ShapeType.Triangle && s.SubType == "Isosceles").Count();
            var numEqualateral = deserializedShapes.Where(s => s.ShapeType == ShapeType.Triangle && s.SubType == "Equalateral").Count();
            var numScalene = deserializedShapes.Where(s => s.ShapeType == ShapeType.Triangle && s.SubType == "Scalene").Count();
            var numQuadrilaterals = deserializedShapes.Where(s => s.ShapeType == ShapeType.Quadrilateral).Count();
            var numSquares = deserializedShapes.Where(s => s.ShapeType == ShapeType.Quadrilateral && s.SubType == "Square").Count();
            var numRects = deserializedShapes.Where(s => s.ShapeType == ShapeType.Quadrilateral && s.SubType == "Rectangle").Count();
            var unkownTypes = deserializedShapes.Where(s => s.ShapeType == ShapeType.Unknown || s.SubType == "Unknown").Count();

            Console.WriteLine($"Circles       : {numCircles}\n\n" +
                              $"Triangles     : {numTriangles}\n" +
                              $"--Isosceles   : {numIsosceles}\n" +
                              $"--Equalateral : {numEqualateral}\n" +
                              $"--Scalene     : {numScalene}\n\n" +
                              $"Quadrilaterals: {numQuadrilaterals}\n" +
                              $"--Squares     : {numSquares}\n" +
                              $"--Rectangles  : {numRects}\n\n" +
                              $"Total Shapes  : {totalShapes}\n" +
                              $"Unknown Shapes: {unkownTypes}");

            Console.ReadLine();

        }

        static void DisplayShapes(string title, IEnumerable<IShape> shapes)
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
    }
}
