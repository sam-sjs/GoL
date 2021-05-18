using System;
using System.Linq;

namespace GoL
{
    public class GameEngine
    {
        private readonly Display _display;
        private readonly IInput _input;
        private readonly Generation _generation;
        private readonly ConsoleKey[] _arrowKeys = new ConsoleKey[]
            {ConsoleKey.RightArrow, ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow}; 
        private World _world;

        public GameEngine(Display display, IInput input)
        {
            _display = display;
            _input = input;
            Rules rules = new Rules();
            _generation = new Generation(rules);
        }

        public void Start()
        {
            _display.WelcomeMessage();
            CreateWorld();
            _world.Populate();
            _display.Clear();
            _display.World(_world);
            _display.ResetCursorPosition();
            SetInitialWorldState();
        }

        private void CreateWorld()
        {
            _display.EnterHeight();
            int worldHeight = GetValidWorldDimension();
            _display.EnterWidth();
            int worldWidth = GetValidWorldDimension();
            _world = new World(worldHeight, worldWidth);
        }

        private int GetValidWorldDimension() // From user?
        {
            int dimension;
            while (!int.TryParse(_input.ReadLine(), out dimension))
            {
                _display.InvalidInput();
            }

            return dimension;
        }

        private void SetInitialWorldState() // Potentially rename this.
        {
            ConsoleKey input;
            do
            {
                input = _input.ReadKey(true).Key;
                if (_arrowKeys.Contains(input)) _display.MoveCursor(input);
                if (input == ConsoleKey.Spacebar)
                {
                    WorldLocation livingCell = _display.GetCursorPosition();
                    _world.SetLivingCellAtLocation(livingCell);
                }
            } while (input != ConsoleKey.Enter);
        }
    }
}