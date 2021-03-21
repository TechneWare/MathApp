using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp.Commands
{
    public class NotFoundCommand : ICommand
    {
        public string Name { get; set; }
        public void Execute()
        {
            Console.WriteLine($"Command Not Found: {Name}");
        }
    }
}
