using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MathApp
{
    public class Spinner : IDisposable
    {
        private const string Sequence = @"/-\|";
        private int counter = 0;
        private readonly int left;
        private readonly int top;
        private readonly int delay;
        private bool active;
        private readonly Thread thread;
        private readonly string prompt;

        public Spinner(string prompt,int left, int top, int delay = 25)
        {
            var curColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"  {prompt}");
            Console.ForegroundColor = curColor;

            this.prompt = prompt;
            this.left = left;
            this.top = top;
            this.delay = delay;
            thread = new Thread(Spin);
        }
        public Spinner(int left, int top, int delay = 100)
        {
            this.left = left;
            this.top = top;
            this.delay = delay;
            thread = new Thread(Spin);
        }

        public void Start()
        {
            active = true;
            if (!thread.IsAlive)
                thread.Start();
        }

        public void Stop()
        {
            active = false;
            Draw(' ');
        }

        private void Spin()
        {
            while (active)
            {
                Turn();
                Thread.Sleep(delay);
            }
        }

        private void Draw(char c)
        {
            int curLeft = Console.CursorLeft;
            int curTop = Console.CursorTop;
            var curColor = Console.ForegroundColor;

            Console.CursorVisible = false;
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(c);
            Console.SetCursorPosition(curLeft, curTop);
            Console.ForegroundColor = curColor;
            Console.CursorVisible = true;
        }

        private void Turn()
        {
            Draw(Sequence[++counter % Sequence.Length]);
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
