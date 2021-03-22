using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class DeleteShapeCommand : ICommand, ICommandFactory
    {
        private IDataContext dbContext;

        public string CommandName => "Delete";

        public string CommandArgs => "[name]";

        public string[] CommandAlternates => new string[] { };

        public string Description => "Deletes a shape from the database";
        public string TargetName { get; set; }
        public void Execute()
        {
            if (!string.IsNullOrEmpty(TargetName))
            {
                if (dbContext.DeleteShape(TargetName))
                    Console.WriteLine($"Shape {TargetName} was deleted");
                else
                    Console.WriteLine($"Shape {TargetName} was not found");
            }
            else
                Console.WriteLine("You must provide the name of a shape to delete");
        }

        public DeleteShapeCommand()
        {        }
        public DeleteShapeCommand(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICommand MakeCommand(string[] args)
        {
            var cmd = new DeleteShapeCommand(dbContext);
            if (args.Length > 1)
                cmd.TargetName = args[1];
            else
                Console.WriteLine("Usage: Delete Name - where name is the name of the shape");
            return cmd;
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            this.dbContext = dbContext;
            return MakeCommand(args);
        }
    }
}
