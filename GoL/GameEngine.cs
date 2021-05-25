using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

        public void Run()
        {
            _display.WelcomeMessage();
            CreateWorld();
            _world.Populate();
            _display.Clear();
            _display.World(_world);
            _display.ResetCursorPosition();
            SetInitialWorldState();
            StartGame();
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
                input = _input.ReadKey().Key;
                if (_arrowKeys.Contains(input))
                {
                    _display.MoveCursor(input);
                }
                if (input == ConsoleKey.Spacebar)
                {
                    SetLivingCell();
                }
            } while (input != ConsoleKey.Enter);
        }

        private void SetLivingCell() // Name is very similar to World method.
        {
            Location livingCell = _display.GetCursorPosition();
            _world.SetLivingCellAtLocation(livingCell);
            _display.RefreshWorld(_world);
        }

        private void StartGame()
        {
            ConsoleKey input;
            do
            {
                // input = _input.ReadKey().Key;
                List<Cell> nextGeneration = _generation.BuildNextGeneration(_world.GetCurrentCellFormation());
                _world.SetNewCellFormation(nextGeneration);
                _display.RefreshWorld(_world);
                Thread.Sleep(1000);
            } while (true);
        }
    }
}