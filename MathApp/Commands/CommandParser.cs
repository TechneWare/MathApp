using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class CommandParser
    {
        private readonly IEnumerable<ICommandFactory> commands;
        private readonly IDataContext dbContext;

        public CommandParser(IEnumerable<ICommandFactory> commands, IDataContext dbContext)
        {
            this.commands = commands;
            this.dbContext = dbContext;
        }

        internal ICommand ParseCommand(string[] args)
        {
            var requestedCommand = args[0];

            var command = FindRequestedCommand(requestedCommand);
            if (command == null)
                return new NotFoundCommand { Name = requestedCommand };

            return command.MakeCommand(args, dbContext);
        }

        private ICommandFactory FindRequestedCommand(string requestedCommand)
        {
            return commands.FirstOrDefault(c =>
                c.CommandName.ToLower().StartsWith(requestedCommand.ToLower())
                || c.CommandAlternates.Any(ca => ca.ToLower() == requestedCommand));
        }
    }
}
