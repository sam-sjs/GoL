using System;

namespace GoL
{
    public interface IInput
    {
        public string ReadLine();
        public ConsoleKeyInfo ReadKey();
    }
}