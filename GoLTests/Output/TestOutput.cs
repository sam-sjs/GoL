using GoL.Output;

namespace GoLTests.Output
{
    public class TestOutput : IOutput
    {
        public string Message;
        public int CursorLeft { get; set; }
        public int CursorTop { get; set; }
        public void WriteLine(string message)
        {
            Message = message;
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