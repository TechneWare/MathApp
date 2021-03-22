using MathApp.Commands;
using MathApp.Data;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace MathApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var availableCommands = Utils.GetAvailableCommands();
            var parser = new CommandParser(availableCommands, new InMemoryDataContext());

            //Run Startup - demo all commands
            parser.ParseCommand(new string[] { "RunAll", "Welcome"}).Execute();

            ICommand lastCommand = null;
            do
            {
                args = GetInput().Split(' ');

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

        static string GetInput()
        {
            Spinner spinner = null;
            if (Settings.EnableSpinner)
            {
                spinner = new Spinner(Settings.Prompt, 0, Console.CursorTop, 10);
                spinner.Start();
            }
            else
                Console.Write(Settings.Prompt, Color.Green);
            string commandInput = Console.ReadLine();
            spinner?.Dispose();

            return commandInput;
        }
    }
}
