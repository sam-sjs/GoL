
namespace GoL.Output
{
    public interface IOutput
    {
        public int CursorLeft { get; set; }
        public int CursorTop { get; set; }
        public void WriteLine(string message);
        public void SetCursorPosition(int left, int top);
        public void Clear();
    }
}