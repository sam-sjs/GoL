
namespace GoL.Output
{
    public interface IOutput
    {
        public int CursorLeft { get; set; }
        public int CursorTop { get; set; }
        public bool CursorVisible { get; set; }
        public int CellWriteWidth { get; }
        public void WriteLine();
        public void WriteLine(string message);
        public void WriteLivingCell();
        public void WriteDeadCell();
        public void SetCursorPosition(int left, int top);
        public void Clear();
    }
}