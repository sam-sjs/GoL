using System.Xml.Xsl;

namespace GoL
{
    public interface IOutput
    {
        public void WriteLine(string message);
        public void SetCursorPosition(int left, int right);
    }
}