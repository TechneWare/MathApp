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
    public class DisplayWelcomeCommand : ICommand, ICommandFactory
    {
        public string CommandName => "Welcome";

        public string CommandArgs => "";

        public string[] CommandAlternates => new string[] { };

        public string Description => "Displays the Welcome Message";

        public void Execute()
        {
            Console.WriteAscii("Welcome to", Color.FromArgb(131, 184, 214));
            Console.WriteAscii("Brian's Demo");

            Console.WriteLine("== Press 'ENTER' " +
                              "for usage or 'Q' to to quit, 'sp on' " +
                              "to enable spinner prompt ==\n", Color.Green);
            Console.WriteLine("Type: Run to execute all exercise requirments", Color.White);
        }

        public ICommand MakeCommand(string[] args)
        {
            return new DisplayWelcomeCommand();
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            return MakeCommand(args);
        }
    }
}
