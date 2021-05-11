using System;

namespace GoL
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleOutput output = new ConsoleOutput();
            Display display = new Display(output);
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            GameEngine gameEngine = new GameEngine(display, generation);
            gameEngine.Start();
        }
    }
}