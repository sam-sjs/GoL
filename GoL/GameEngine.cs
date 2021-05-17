using System;
using System.Linq;

namespace GoL
{
    public class GameEngine
    {
        private readonly Display _display;
        private readonly IInput _input;
        private readonly Generation _generation;
        private World _world;
        private readonly ConsoleKey[] _arrowKeys = new ConsoleKey[]
            {ConsoleKey.RightArrow, ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow}; 

        public GameEngine(Display display, IInput input, Generation generation)
        {
            _display = display;
            _input = input;
            _generation = generation;
        }

        public void Start()
        {
            _display.Welcome();
            CreateWorld();
            Console.Clear();
            _world.Populate();
            _display.World(_world);
            Console.SetCursorPosition(0, 0);
            SetInitialWorldState();
        }

        private void CreateWorld()
        {
            _display.EnterHeight();
            int height = GetValidDimension();
            _display.EnterWidth();
            int width = GetValidDimension();
            _world = new World(height, width);
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

        private void SetInitialWorldState()
        {
            ConsoleKey input;
            do
            {
                input = _input.ReadKey(true).Key;
                if (_arrowKeys.Contains(input)) _display.MoveCursor(input);
            } while (input != ConsoleKey.Q);
        }
    }
}