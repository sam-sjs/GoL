using GoL.Game.GoLDisplay;
using GoL.Game.GoLGameEngine;
using GoL.Input;
using GoL.Output;

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
            gameEngine.Run();
        }
    }
}