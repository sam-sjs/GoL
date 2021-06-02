using System;

namespace GoL.Output
{
    public class ConsoleOutput : IOutput
    {
        private const char LiveCellRepresentation = '█';
        private const char DeadCellRepresentation = '.';
        public int CellWriteWidth { get; } = 2;
        public int CursorLeft { get; set; }
        public int CursorTop { get; set; }

        public void WriteLine()
        {
            Console.WriteLine();
        }

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

        public void WriteLivingCell() // Just a name but is it bringing the concept of a cell to output?
        {
            Console.Write(new String(LiveCellRepresentation, CellWriteWidth));
        }
        public void WriteDeadCell()
        {
            Console.Write(new String(DeadCellRepresentation, CellWriteWidth));
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}