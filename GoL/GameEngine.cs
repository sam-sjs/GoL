using System;

namespace GoL
{
    public class GameEngine
    {
        private readonly Display _display;
        private readonly IInput _input;
        private readonly Generation _generation;
        private World _world;

        public GameEngine(Display display, IInput input, Generation generation)
        {
            _display = display;
            _input = input;
            _generation = generation;
        }

        public void Start()
        {
            _display.Welcome();
            _display.EnterHeight();
            int height = GetValidDimension();
            _display.EnterWidth();
            int width = GetValidDimension();
            Console.Clear();
            _world = new World(height, width);
            _world.Populate();
            _display.World(_world);
            Console.SetCursorPosition(0, 0);
            NavigateConsole();
        }

        private int GetValidDimension()
        {
            int dimension;
            while (!Int32.TryParse(_input.ReadLine(), out dimension))
            {
                _display.InvalidInput();
            }

            return dimension;
        }

        private void NavigateConsole()
        {
            ConsoleKey input;
            do
            {
                input = Console.ReadKey(true).Key;
                int xPosition = Console.CursorLeft;
                int yPosition = Console.CursorTop;
                if (input == ConsoleKey.UpArrow) Console.SetCursorPosition(xPosition, yPosition - 1);
                if (input == ConsoleKey.DownArrow) Console.SetCursorPosition(xPosition, yPosition + 1);
                if (input == ConsoleKey.LeftArrow) Console.SetCursorPosition(xPosition - 1, yPosition);
                if (input == ConsoleKey.RightArrow) Console.SetCursorPosition(xPosition + 1, yPosition);
            } while (input != ConsoleKey.Q);
        }
    }
}