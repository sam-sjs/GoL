
namespace GoL
{
    public class TestOutput : IOutput
    {
        public string Message;
        public int XPosition;
        public int YPosition;
        public void WriteLine(string message)
        {
            Message = message;
        }

        public void SetCursorPosition(int left, int top)
        {
            XPosition = left;
            YPosition = top;
        }
    }
}