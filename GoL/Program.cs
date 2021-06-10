using GoL.Game.GoLCursorNavigation;
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
            IOutput output = new ConsoleOutput();
            IInput input = new ConsoleInput();
            Display display = new Display(output);
            CursorNavigation cursorNav = new CursorNavigation();
            GameEngine gameEngine = new GameEngine(display, input, cursorNav);
            gameEngine.Run();
        }
    }
}