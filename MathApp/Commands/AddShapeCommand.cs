using MathApp.Data;
using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class AddShapeCommand : ICommand, ICommandFactory
    {
        private IDataContext dbContext;
        private IShape newShape { get; set; }
        private bool IsValid { get; set; }
        public string CommandName => "Add Name";

        public string CommandArgs => "[circle|triangle|square|rectangle]";

        public string[] CommandAlternates => new string[] { };

        public string Description => "Usage: add [type] [name] [params] | add [type] to see help on params)";

        public void Execute()
        {
            if (this.IsValid)
            {
                if (dbContext.AddShape(newShape))
                {
                    Console.WriteLine($"New Shape Added");
                    Utils.DisplayShape(newShape);
                }
                else
                    Console.WriteLine("Failed to Add Shape");
            }
            else
                Console.WriteLine("Invalid Parameters: Unable to execute add.");
        }
        public AddShapeCommand()
        { }
        public AddShapeCommand(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICommand MakeCommand(string[] args)
        {
            var cmd = new AddShapeCommand(dbContext);
            this.IsValid = false;
            if (args.Length > 2)
            {
                var type = args[1].ToLower();
                var name = args[2];
                switch (type)
                {
                    case string x when x.ToLower().StartsWith("c"):
                        if (args.Length == 4 && double.TryParse(args[3], out double radius))
                        {
                            cmd.newShape = new Circle(name, radius);
                            cmd.IsValid = true;
                        }
                        else
                            Console.WriteLine("usage: add circle name [radius]");
                        break;
                    case string x when x.ToLower().StartsWith("t"):
                        if (args.Length == 6
                            && double.TryParse(args[3], out double a)
                            && double.TryParse(args[4], out double b)
                            && double.TryParse(args[5], out double c))
                        {
                            cmd.newShape = new Triangle(name, a, b, c);
                            cmd.IsValid = true;
                        }
                        else
                            Console.WriteLine("usage: add name triangle [sideA] [sideB] [sideC]");
                        break;
                    case string x when x.ToLower().StartsWith("s"):
                        if (args.Length == 4 && double.TryParse(args[3], out double width))
                        {
                            cmd.newShape = new Square(name, width);
                            cmd.IsValid = true;
                        }
                        else
                            Console.WriteLine("usage: add name square [width]");
                        break;
                    case string y when y.ToLower().StartsWith("r"):
                        if (args.Length == 5
                            && double.TryParse(args[3], out double w)
                            && double.TryParse(args[4], out double l))
                        {
                            cmd.newShape = new Rectangle(name, w, l);
                            cmd.IsValid = true;
                        }
                        else
                            Console.WriteLine("usage: add name rectangle [width] [length]");
                        break;
                    default:
                        Console.WriteLine($"Invalid Type: {type}");
                        break;
                }
            }
            else
                Console.WriteLine($"{Description}\nValid [type]'s are: {CommandArgs}");

            return cmd;
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            this.dbContext = dbContext;
            return MakeCommand(args);
        }
    }
}
