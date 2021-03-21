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

        public string CommandName => "RunAll";

        public string CommandArgs => "";

        public string[] CommandAlternates => new string[] { };

        public string Description => "Runs all demo commands";

        public void Execute()
        {
            var availableCommands = Utils.GetAvailableCommands();
            var parser = new CommandParser(availableCommands, new InMemoryDataContext());

            string[] allCommands =
            {
                "Get",
                "Get area",
                "Get parimiter",
                "JsonDemo",
                "Stats"
            };

            foreach (var cmd in allCommands)
            {
                var c = parser.ParseCommand(cmd.Split(' '));
                if (c != null)
                    c.Execute();
            }
        }
        public RunAllCommand()
        {        }
        public RunAllCommand(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICommand MakeCommand(string[] args)
        {
            return new RunAllCommand();
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            return new RunAllCommand(dbContext);
        }
    }
}
