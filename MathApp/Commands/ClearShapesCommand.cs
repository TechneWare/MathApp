using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace MathApp.Commands
{
    public class ClearShapesCommand : ICommand, ICommandFactory
    {
        private readonly IDataContext dbContext;

        public string CommandName => "TruncateShapes";

        public string CommandArgs => "";

        public string[] CommandAlternates => new string[] { };

        public string Description => "CAUTION: Removes All Shapes From The Data Store";

        public void Execute()
        {
            Console.WriteLine("!! YOUR ARE ABOUT TO DELETE ALL THE DATA !!", Color.Red);
            Console.Write("Are you Sure?(y/N):", Color.Yellow);
            var confirmation = Console.ReadLine();
            if (confirmation.ToLower() == "y")
            {
                dbContext.ClearShapes();
                Console.WriteLine("!!All Data Has Been Deleted!!", Color.Red);
            }
            else
                Console.WriteLine("No Changes Were Made", Color.Green);
        }
        public ClearShapesCommand()
        { }
        public ClearShapesCommand(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICommand MakeCommand(string[] args)
        {
            return new ClearShapesCommand();
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            return new ClearShapesCommand(dbContext);
        }
    }
}
