using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GoL
{
    public class GameEngine
    {
        private const int RefreshWorldDelay = 1000;
        private readonly Display _display;
        private readonly IInput _input;
        private readonly Generation _generation;
        private World _world;

        private readonly ConsoleKey[] _arrowKeys = new ConsoleKey[]
            {ConsoleKey.RightArrow, ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow};


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
            SetupWorld();
            StartGame();
        }

        private void SetupWorld()
        {
            CreateWorld();
            _display.Clear();
            _display.World(_world);
            _display.ResetCursorPosition();
            GetInitialLivingCellsFromUser();
        }

        private void CreateWorld()
        {
            _display.EnterWidth();
            int worldWidth = GetValidWorldDimensionFromUser();
            _display.EnterHeight();
            int worldHeight = GetValidWorldDimensionFromUser();
            _world = new World(worldWidth, worldHeight);
        }

        private int GetValidWorldDimensionFromUser()
        {
            int dimension;
            while (!int.TryParse(_input.ReadLine(), out dimension))
            {
                _display.InvalidInput();
            }

            return dimension;
        }

        private void GetInitialLivingCellsFromUser()
        // Bad name, this processes user display input or something
        {
            ConsoleKey input;
            do
            {
                input = _input.ReadKey().Key;
                if (_arrowKeys.Contains(input))
                {
                    ProcessDisplayNavigationalInput(input);
                }

                if (input == ConsoleKey.Spacebar)
                {
                    SetLivingCell();
                }
            } while (input != ConsoleKey.Enter);
        }

        private void ProcessDisplayNavigationalInput(ConsoleKey input)
        {
            Location cursorPosition = _display.GetCursorPosition();
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    MoveCursorUp(cursorPosition);
                    break;
                case ConsoleKey.DownArrow:
                    MoveCursorDown(cursorPosition);
                    break;
                case ConsoleKey.LeftArrow:
                    MoveCursorLeft(cursorPosition);
                    break;
                case ConsoleKey.RightArrow:
                    MoveCursorRight(cursorPosition);
                    break;
            }
        }

        private void MoveCursorUp(Location cursorPosition)
        {
            if (cursorPosition.Row == 0)
            {
                _display.SetCursorPosition(cursorPosition.Column, _world.Rows - 1);
            }
            else
            {
                _display.SetCursorPosition(cursorPosition.Column, cursorPosition.Row - 1);
            }
        }

        private void MoveCursorDown(Location cursorPosition)
        {
            if (cursorPosition.Row == _world.Rows - 1)
            {
                _display.SetCursorPosition(cursorPosition.Column, 0);
            }
            else
            {
                _display.SetCursorPosition(cursorPosition.Column, cursorPosition.Row + 1);
            }
        }

        private void MoveCursorLeft(Location cursorPosition)
        {
            if (cursorPosition.Column == 0)
            {
                _display.SetCursorPosition(_world.Columns - 1, cursorPosition.Row);
            }
            else
            {
                _display.SetCursorPosition(cursorPosition.Column - 1, cursorPosition.Row);
            }
        }

        private void MoveCursorRight(Location cursorPosition)
        {
            if (cursorPosition.Column == _world.Columns - 1)
            {
                _display.SetCursorPosition(0, cursorPosition.Row);
            }
            else
            {
                _display.SetCursorPosition(cursorPosition.Column + 1, cursorPosition.Row);
            }
        }

        private void SetLivingCell()
        // Rename - this sends the cursor position as a living cell to the world
        {
            Location livingCell = _display.GetCursorPosition();
            _world.SetLivingCellAtLocation(livingCell);
            _display.RefreshWorld(_world); // Second thing the method is doing?
        }

        private void StartGame()
        {
            do
            {
                while (!Console.KeyAvailable)
                {   // Below line needs method renaming.
                    List<Cell> nextGeneration = _generation.BuildNextGeneration(_world.GetCurrentCellFormation());
                    _world.SetNewCellFormation(nextGeneration);
                    Thread.Sleep(RefreshWorldDelay);
                    _display.RefreshWorld(_world);
                }
            } while (_input.ReadKey().Key != ConsoleKey.Q);
        }
    }
}