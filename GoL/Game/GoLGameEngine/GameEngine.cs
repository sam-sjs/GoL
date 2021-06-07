using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoL.Game.GoLCell;
using GoL.Game.GoLDisplay;
using GoL.Game.GoLGeneration;
using GoL.Game.GoLNavigation;
using GoL.Game.GoLRules;
using GoL.Game.GoLWorld;
using GoL.Input;

namespace GoL.Game.GoLGameEngine
{
    public class GameEngine
    {
        private const int RefreshWorldDelay = 200;
        private readonly Display _display;
        private readonly IInput _input;
        private readonly Generation _generation;
        private readonly Navigation _navigation;
        private IInhabitable _world;

        private readonly Key[] _arrowKeys = new Key[] {Key.Right, Key.Left, Key.Up, Key.Down};


        public GameEngine(Display display, IInput input)
        {
            _display = display;
            _input = input;
            IRenewable rules = new Rules();
            _generation = new Generation(rules);
            _navigation = new Navigation();
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
            GetInitialWorldPatternFromUser();
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

        private void GetInitialWorldPatternFromUser()
        {
            Key input;
            do
            {
                input = _input.ReadKey();
                if (_arrowKeys.Contains(input))
                {
                    UpdateCursorPosition(input);
                }

                if (input == Key.Space)
                {
                    SetLivingCellInWorldAtCursorPosition();
                }
            } while (input != Key.Enter);

            _display.ShowCursor(false);
        }

        private void UpdateCursorPosition(Key input)
        {
            Location cursorPosition = _display.GetCursorPosition();
            WorldBounds bounds = new WorldBounds(_world.Columns, _world.Rows);
            Location newLocation = _navigation.CalculateNewCursorPosition(cursorPosition, bounds, input);
            _display.SetCursorPosition(newLocation);
        }

        private void SetLivingCellInWorldAtCursorPosition()
        {
            Location livingCell = _display.GetCursorPosition();
            _world.SetLivingCellAtLocation(livingCell);
            _display.RefreshWorld(_world);
        }

        private void StartGame()
        {
            do
            {
                while (!_input.KeyAvailable)
                {   // Below line needs method renaming.
                    List<Cell> nextGeneration = _generation.BuildNextGeneration(_world.GetCurrentCellFormation());
                    _world.SetNewCellFormation(nextGeneration);
                    Thread.Sleep(RefreshWorldDelay);
                    _display.RefreshWorld(_world);
                }
            } while (_input.ReadKey() != Key.Quit);

            _display.ShowCursor(true);
        }
    }
}