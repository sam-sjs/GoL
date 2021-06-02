using GoL.Game.GoLWorld;
using GoL.Output;

namespace GoL.Game.GoLDisplay
{
    public class Display
    {
        private readonly IOutput _output;

        public Display(IOutput output)
        {
            _output = output;
        }

        public void WelcomeMessage()
        {
            _output.WriteLine(Messages.Welcome);
        }

        public void EnterHeight()
        {
            _output.WriteLine(Messages.EnterHeight);
        }

        public void EnterWidth()
        {
            _output.WriteLine(Messages.EnterWidth);
        }

        public void SetInitialState()
        {
            _output.WriteLine(Messages.SetInitialState);
        }

        public void World(IInhabitable world)
        {
            bool[,] worldState = world.GetCurrentWorldState();
            int rows = worldState.GetLength(1); // Check correct dimensions
            int columns = worldState.GetLength(0);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (worldState[column, row])
                    {
                        _output.WriteLivingCell();
                    }
                    else
                    {
                        _output.WriteDeadCell();
                    }
                }

                if (row < rows - 1) _output.WriteLine();
            }
        }

        public void InvalidInput()
        {
            _output.WriteLine(Messages.InvalidInput);
        }

        public void Clear()
        {
            _output.Clear();
        }

        public void SetCursorPosition(int left, int top)
        {
            _output.SetCursorPosition(left * _output.CellWriteWidth, top);
        }

        public void ResetCursorPosition()
        {
            _output.SetCursorPosition(0, 0);
        }

        public Location GetCursorPosition()
        {
            return new Location(_output.CursorLeft / _output.CellWriteWidth, _output.CursorTop);
        }

        public void RefreshWorld(IInhabitable world)
        {
            int cursorLeft = _output.CursorLeft;
            int cursorTop = _output.CursorTop;
            Clear();
            World(world);
            _output.SetCursorPosition(cursorLeft, cursorTop);
        }
    }
}