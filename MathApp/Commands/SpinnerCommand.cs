using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class SpinnerCommand : ICommand, ICommandFactory
    {
        public string CommandName => "Spinner";

        public string CommandArgs => "[on | off]";

        public string[] CommandAlternates => new string[] { };

        public string Description => "Turns Spinner Prompt On/Off";
        private bool SpinnerOn;

        public void Execute()
        {
            Settings.EnableSpinner = SpinnerOn;
        }
        public SpinnerCommand()
        { }
        public SpinnerCommand(string[] args)
        {
            this.SpinnerOn = Settings.EnableSpinner;
            if (args.Length > 1)
            {
                switch (args[1].ToLower())
                {
                    case "on":
                        this.SpinnerOn = true;
                        break;
                    case "off":
                        this.SpinnerOn = false;
                        break;
                    default:
                        Console.WriteLine($"Unknown spinner switch {args[1]}");
                        break;
                }
            }
            else
                Console.WriteLine("Required Argument [on | off] missing");
        }
        public ICommand MakeCommand(string[] args)
        {
            return new SpinnerCommand(args);
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            return MakeCommand(args);
        }
    }
}
