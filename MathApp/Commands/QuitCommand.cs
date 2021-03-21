using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class QuitCommand : ICommand, ICommandFactory
    {
        public string CommandName => "Quit";

        public string CommandArgs => "";

        public string[] CommandAlternates => new string[] { "exit" };

        public string Description => "Ends the program";

        public void Execute()
        {
            Console.WriteLine("Thank you for running this program, have a nice day!!");
        }

        public ICommand MakeCommand(string[] args)
        {
            return new QuitCommand();
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            return MakeCommand(args);
        }
    }
}
