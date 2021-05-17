using System;

namespace GoL
{
    public class ConsoleOutput : IOutput
    {
        public int CursorLeft { get; set; }
        public int CursorTop { get; set; }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            // Next two lines seem kinda silly.
            CursorLeft = Console.CursorLeft;
            CursorTop = Console.CursorTop;
        }
    }
}