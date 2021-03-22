using MathApp.Commands.ShapeFactory;
using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace MathApp.Commands
{
    public static class Utils
    {
        public static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
            {
                new QuitCommand(),
                new ClearScreenCommand(),
                new GetCommand(),
                new JsonCommand(),
                new StatsCommand(),
                new RunAllCommand(),
                new AddShapeCommand(),
                new ClearShapesCommand(),
                new DeleteShapeCommand(),
                new DisplayWelcomeCommand(),
                new SpinnerCommand()
            };
        }
        public static IEnumerable<IShapeFactory> GetAvailableShapeFactories()
        {
            return new IShapeFactory[]
            {
                new CircleFactory(),
                new TriangleFactory(),
                new SquareFactory(),
                new RectangleFactory()
            };
        }
        public static void PrintUsage(IEnumerable<ICommandFactory> availableCommands)
        {
            Console.WriteLine("\nUsage: commandName Arguments", Color.Green);
            Console.WriteLine("Commands:", Color.Green);
            foreach (var command in availableCommands)
            {
                string alts = "";
                if (command.CommandAlternates.Any())
                    foreach (var altCommand in command.CommandAlternates)
                        alts += $" | {altCommand}";

                Console.Write($"{command.CommandName}{alts} {command.CommandArgs}".PadRight(35));
                Console.WriteLine($"-{ command.Description}");
            }
            Console.WriteLine("==== Examples ===", Color.Green);
            Console.WriteLine("g\tDisplay shape data unsorted");
            Console.WriteLine("g a\tDisplay shape data sorted by area");
            Console.WriteLine("g p\tDisplay shape data by parimter");
            Console.WriteLine("jd\tRun unsorted shape data through a Json serialization and back again.");
            Console.WriteLine("s\tDisplay Stats on shape data");
            Console.WriteLine();
        }
        public static void DisplayShapes(string title, IEnumerable<IShape> shapes)
        {
            const int pdName = 35;
            const int pdData = 10;
            Console.WriteLine($"\n{title.PadLeft(pdName, ' ')}");

            Console.WriteLine($"{"Name".PadRight(pdName)}{"Area".PadRight(pdData)}{"Perimiter".PadRight(pdData)}");
            Console.WriteLine($"{"".PadRight(pdName - 1, '-')} {"".PadRight(pdData - 1, '-')} {"".PadRight(pdData - 1, '-')}");
            foreach (var s in shapes)
                DisplayShape(s);
        }

        public static void DisplayShape(IShape s)
        {
            const int pdName = 35;
            const int pdData = 10;
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
