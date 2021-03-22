using MathApp.Data;
using MathApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class GetCommand : ICommand, ICommandFactory
    {
        private IDataContext dbContext;

        public string CommandName => "Get";

        public string CommandArgs => "[area | parimiter]";

        public string[] CommandAlternates => new string[] { "G" };

        public string Description => "Gets All Shapes, optionally sort by area or parimiter";

        public SortBy SortBy { get; set; }
        public void Execute()
        {
            switch (SortBy)
            {
                case SortBy.Area:
                    Utils.DisplayShapes("=== Shapes By Area ===", dbContext.GetAllShapes(SortBy));
                    break;
                case SortBy.Parimiter:
                    Utils.DisplayShapes("=== Shapes By Parimiter ===", dbContext.GetAllShapes(SortBy));
                    break;
                case SortBy.None:
                default:
                    Utils.DisplayShapes("=== Shapes Unsorted ===", dbContext.GetAllShapes(SortBy));
                    break;
            }
        }

        public GetCommand()
        {  }
        public GetCommand(IDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICommand MakeCommand(string[] args)
        {
            var cmd = new GetCommand(dbContext) { SortBy = SortBy.None };

            if (args.Length > 1)
            {
                string arg = args[1];
                switch (arg)
                {
                    case string x when x.ToLower().StartsWith("a"):
                        cmd.SortBy = SortBy.Area;
                        break;
                    case string x when x.ToLower().StartsWith("p"):
                        cmd.SortBy = SortBy.Parimiter;
                        break;
                    default:
                        cmd.SortBy = SortBy.None;
                        break;
                }
            }

            return cmd;
        }
        public ICommand MakeCommand(string[] args, IDataContext dbContext)
        {
            this.dbContext = dbContext;
            return MakeCommand(args);
        }
    }
}
