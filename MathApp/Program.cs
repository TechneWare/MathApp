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
            var availableCommands = GetAvailableCommands();
            var parser = new CommandParser(availableCommands, new InMemoryDataContext());

            string[] startupCommands =
            {
                "Get",
                "Get area",
                "Get parimiter",
                "JsonDemo",
                "Stats"
            };

            foreach (var cmd in startupCommands)
            {
                var c = parser.ParseCommand(cmd.Split(' '));
                if (c != null)
                    c.Execute();
            }

            Console.WriteLine("\n\n=== Welcome to the coding demo ===");
            Console.WriteLine("== Startup Complete: Press ENTER for usage or Q to to quit ==");
            var lastCommand = "";
            do
            {
                Console.Write($"$ ");
                string commandInput = Console.ReadLine();
                args = commandInput.Split(' ');

                if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
                    PrintUsage(availableCommands);
                else
                {

                    var command = parser.ParseCommand(args);

                    if (command != null)
                    {
                        lastCommand = command.GetType().ToString();
                        command.Execute();
                    }
                }
            } while (lastCommand != "MathApp.Commands.QuitCommand");
        }

        static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
            {
                new QuitCommand(),
                new ClearScreenCommand(),
                new GetCommand(),
                new JsonCommand(),
                new StatsCommand()
            };
        }
        private static void PrintUsage(IEnumerable<ICommandFactory> availableCommands)
        {
            Console.WriteLine("\n\nUsage: commandName Arguments");
            Console.WriteLine("Commands:");
            foreach (var command in availableCommands)
            {
                Console.WriteLine($"{command.CommandName} {command.CommandArgs}\t- {command.Description}");
                if (command.CommandAlternates.Any())
                {
                    Console.WriteLine("\tAlternates:");
                    foreach (var altCommand in command.CommandAlternates)
                        Console.WriteLine($"\t  {altCommand}");
                }
            }
            Console.WriteLine("\n\n");
        }
    }
}
