using GoL.Output;

namespace GoLTests.Output
{
    public class TestOutput : IOutput
    {
        public string Message;
        public int CursorLeft { get; set; }
        public int CursorTop { get; set; }
        public int CellWriteWidth { get; } = 1;

        public void WriteLine()
        {
            Message += "";
        }
        public void WriteLine(string message)
        {
            Message += message;
        }

        public void WriteLivingCell()
        {
            Message += "██";
        }

        public void WriteDeadCell()
        {
            Message += "..";
        }

        public void SetCursorPosition(int left, int top)
        {
            CursorLeft = left;
            CursorTop = top;
        }

        public void Clear()
        {
            Message = "";
        }
    }
}