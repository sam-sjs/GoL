using System;

namespace GoL.Output
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
            CursorLeft = Console.CursorLeft;
            CursorTop = Console.CursorTop;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}