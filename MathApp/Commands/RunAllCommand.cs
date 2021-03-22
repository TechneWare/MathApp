using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class RunAllCommand : ICommand, ICommandFactory
    {
        private IDataContext dbContext;
        private bool ShowWelcome { get; set; } = false;

        public string CommandName => "RunAll";

        public string CommandArgs => "";

        public string[] CommandAlternates => new string[] { };

        public string Description => "Runs all demo commands";

        public void Execute()
        {
            var availableCommands = Utils.GetAvailableCommands();
            var parser = new CommandParser(availableCommands, new InMemoryDataContext());

            var allCommands = new List<string>()
            {
                "Get",
                "Get area",
                "Get parimiter",
                "JsonDemo",
                "Stats"
            };

            if (ShowWelcome)
            {
                allCommands.Add("Clear");
                allCommands.Add("Welcome");
            }

            foreach (var cmd in allCommands)
            {
                var c = parser.ParseCommand(cmd.Split(' '));
                if (c != null)
                    c.Execute();
            }
        }
        public RunAllCommand()
        { }
        public RunAllCommand(string[] args, IDataContext dbContext)
        {
            if (args.Length > 1 && args[1] == "Welcome")
                this.ShowWelcome = true;

            this.dbContext = dbContext;
        }
        public ICommand MakeCommand(string[] args)
        {
            return new RunAllCommand();
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            return new RunAllCommand(args, dbContext);
        }
    }
}
