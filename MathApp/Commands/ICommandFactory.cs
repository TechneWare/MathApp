using MathApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public interface ICommandFactory
    {
        string CommandName { get; }
        string CommandArgs { get; }
        string[] CommandAlternates { get; }
        string Description { get; }

        ICommand MakeCommand(string[] args);
        ICommand MakeCommand(string[] args, IDataContext dbContext);
    }
}
