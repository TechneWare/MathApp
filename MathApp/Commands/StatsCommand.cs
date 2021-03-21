using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class StatsCommand : ICommand, ICommandFactory
    {
        private IDataContext dbContext;

        public string CommandName => "Stats";

        public string CommandArgs => "";

        public string[] CommandAlternates => new string[] { };

        public string Description => "Shows Data Stats";

        public void Execute()
        {
            Utils.DisplayDataStats("=== Shape Data Stats ===", dbContext.GetAllShapes(SortBy.None));
        }
        public StatsCommand()
        { }
        public StatsCommand(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICommand MakeCommand(string[] args)
        {
            return new StatsCommand();
        }

        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            this.dbContext = dbContext;
            return new StatsCommand(dbContext);
        }
    }
}
