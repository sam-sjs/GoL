using GoL.Game.GoLDisplay;
using GoL.Input;

namespace GoL.Game.GoLCursorNavigation
{
    public class CursorNavigation
    {
        public Location CalculateNewCursorPosition(Location cursorPosition, WorldBounds bounds, Key input)
        {
            int newColumnPosition = CalculateNewColumnPosition(cursorPosition, bounds, input);
            int newRowPosition = CalculateNewRowPosition(cursorPosition, bounds, input);
            return new Location(newColumnPosition, newRowPosition);
        }

        private int CalculateNewColumnPosition(Location currentPosition, WorldBounds bounds, Key key)
        {
            switch (key)
            {
                case Key.Left:
                    return currentPosition.Column == 0 ? bounds.MaxCol - 1 : currentPosition.Column - 1;
                case Key.Right:
                    return currentPosition.Column == bounds.MaxCol - 1 ? 0 : currentPosition.Column + 1;
                default:
                    return currentPosition.Column;
            }
        }

        private int CalculateNewRowPosition(Location currentPosition, WorldBounds bounds, Key key)
        {
            switch (key)
            {
                case Key.Up:
                    return currentPosition.Row == 0 ? bounds.MaxRow - 1 : currentPosition.Row - 1;
                case Key.Down:
                    return currentPosition.Row == bounds.MaxRow - 1 ? 0 : currentPosition.Row + 1;
                default:
                    return currentPosition.Row;
            }
        }
    }
}