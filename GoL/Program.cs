using System;

namespace GoL
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleOutput output = new ConsoleOutput();
            ConsoleInput input = new ConsoleInput();
            Display display = new Display(output);
            GameEngine gameEngine = new GameEngine(display, input);
            gameEngine.Start();
        }
    }
}