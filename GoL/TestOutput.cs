using System.Collections.Generic;

namespace GoL
{
    public class TestOutput : IOutput
    {
        public string Message;
        public void WriteLine(string message)
        {
            Message = message;
        }
    }
}