using System.Linq;
using System.Threading;
using GoL.Game.GoLCursorNavigation;
using GoL.Game.GoLDisplay;
using GoL.Game.GoLWorld;
using GoL.Input;

namespace GoL.Game.GoLGameEngine
{
    public class GameEngine
    {
        private const int RefreshWorldDelay = 200;
        private readonly Display _display;
        private readonly IInput _input;
        private readonly CursorNavigation _cursorNav;
        private IHabitable _world;

        private readonly Key[] _arrowKeys = new Key[] {Key.Right, Key.Left, Key.Up, Key.Down};


        public GameEngine(Display display, IInput input, CursorNavigation cursorNav)
        {
            _display = display;
            _input = input;
            _cursorNav = cursorNav;
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
            Location newLocation = _cursorNav.CalculateNewCursorPosition(cursorPosition, bounds, input);
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
                { 
                    _world.AdvanceToNextGeneration();
                    _display.RefreshWorld(_world);
                    Thread.Sleep(RefreshWorldDelay);
                }
            } while (_input.ReadKey() != Key.Quit);

            _display.ShowCursor(true);
        }
    }
}