using MathApp.Commands;
using MathApp.Data;
using MathApp.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var availableCommands = Utils.GetAvailableCommands();
            var parser = new CommandParser(availableCommands, new InMemoryDataContext());

            //Run Startup - demo all commands
            parser.ParseCommand(new string[] { "RunAll" }).Execute();

            Console.WriteLine("\n\n=== Welcome to the coding demo ===");
            Console.WriteLine("== Startup Complete: Press ENTER for usage or Q to to quit ==");

            ICommand lastCommand = null;
            do
            {
                Console.Write($"$ ");
                string commandInput = Console.ReadLine();
                args = commandInput.Split(' ');

                if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
                    Utils.PrintUsage(availableCommands);
                else
                {
                    var command = parser.ParseCommand(args);
                    if (command != null)
                    {
                        lastCommand = command;
                        command.Execute();
                    }
                }
            } while (lastCommand == null || lastCommand.GetType() != typeof(QuitCommand));
        }
    }
}
