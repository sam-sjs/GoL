using System;

namespace GoL
{
    public class ConsoleOutput : IOutput
    {
        public int CursorLeft { get; set; } = Console.CursorLeft;
        public int CursorTop { get; set; } = Console.CursorTop;

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}