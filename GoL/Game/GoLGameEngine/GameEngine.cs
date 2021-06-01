using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using GoL.Game.GoLCell;
using GoL.Game.GoLDisplay;
using GoL.Game.GoLGeneration;
using GoL.Game.GoLRules;
using GoL.Game.GoLWorld;
using GoL.Input;

namespace GoL.Game.GoLGameEngine
{
    public class GameEngine
    {
        private const int RefreshWorldDelay = 1000;
        private readonly Display _display;
        private readonly IInput _input;
        private readonly Generation _generation;
        private IInhabitable _world;

        private readonly Key[] _arrowKeys = new Key[] {Key.Right, Key.Left, Key.Up, Key.Down};


        public GameEngine(Display display, IInput input)
        {
            _display = display;
            _input = input;
            IRenewable rules = new Rules();
            _generation = new Generation(rules);
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
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
            Key input;
            do
            {
                input = _input.ReadKey();
                if (_arrowKeys.Contains(input))
                {
                    ProcessDisplayNavigationalInput(input);
                }

                if (input == Key.Space)
                {
                    SetLivingCell();
                }
            } while (input != Key.Enter);
        }

        private void ProcessDisplayNavigationalInput(Key input)
        {
            Location cursorPosition = _display.GetCursorPosition();
            switch (input)
            {
                case Key.Up:
                    MoveCursorUp(cursorPosition);
                    break;
                case Key.Down:
                    MoveCursorDown(cursorPosition);
                    break;
                case Key.Left:
                    MoveCursorLeft(cursorPosition);
                    break;
                case Key.Right:
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
                _display.SetCursorPosition(_world.Columns - 2, cursorPosition.Row);
            }
            else
            {
                _display.SetCursorPosition(cursorPosition.Column - 2, cursorPosition.Row);
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
                _display.SetCursorPosition(cursorPosition.Column + 2, cursorPosition.Row); // The movement offsets can be in Display (via output?)
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
            } while (_input.ReadKey() != Key.Quit);
        }
    }
}