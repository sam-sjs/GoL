using System;

namespace GoL
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

        public void World(World world)
        {
            _output.WriteLine(world.ToString());
        }
        
        public void InvalidInput()
        {
            _output.WriteLine(Messages.InvalidInput);
        }

        public void Clear()
        {
            _output.Clear();
        }

        public void ResetCursorPosition()
        {
            _output.SetCursorPosition(0, 0);
        }

        public void MoveCursor(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    _output.SetCursorPosition(_output.CursorLeft, _output.CursorTop - 1);
                    break;
                case ConsoleKey.DownArrow:
                    _output.SetCursorPosition(_output.CursorLeft, _output.CursorTop + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    _output.SetCursorPosition(_output.CursorLeft - 1, _output.CursorTop);
                    break;
                case ConsoleKey.RightArrow:
                    _output.SetCursorPosition(_output.CursorLeft + 1, _output.CursorTop);
                    break;
            }
        }
    }
}