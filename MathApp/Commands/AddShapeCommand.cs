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
            AddShapeCommand cmd = null;

            var builder = new ShapeFactory.ShapeBuilder(Utils.GetAvailableShapeFactories());
            var newShape = builder.Build(args);
            if (newShape != null)
            {
                cmd = new AddShapeCommand(dbContext)
                {
                    IsValid = true,
                    newShape = newShape
                };
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
