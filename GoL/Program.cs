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
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            GameEngine gameEngine = new GameEngine(display, input, generation);
            gameEngine.Start();
        }
    }
}