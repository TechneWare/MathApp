using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class ClearScreenCommand : ICommand, ICommandFactory
    {
        private readonly IDataContext dbContext;

        public string CommandName => "Clear";

        public string CommandArgs => "";

        public string Description => "Clears the Screen";

        public string[] CommandAlternates => new string[] { "CLS" };

        public void Execute()
        {
            Console.Clear();
        }

        public ClearScreenCommand()
        { }
        public ClearScreenCommand(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICommand MakeCommand(string[] args)
        {
            return new ClearScreenCommand();
        }
        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            return MakeCommand(args);
        }
    }
}
