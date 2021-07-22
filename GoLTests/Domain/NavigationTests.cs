using System.Collections.Generic;
using GoL.Game.GoLCursorNavigation;
using GoL.Game.GoLDisplay;
using GoL.Input;
using Xunit;

namespace GoLTests.Game.GoLCursorNavigation
{
    public class NavigationTests
    {
        public static IEnumerable<object[]> GetNavigationalInputs()
        {
            yield return new object[] {new Location(5, 5), Key.Down, new Location(5, 6)};
            yield return new object[] {new Location(5, 9), Key.Down, new Location(5, 0)};
            yield return new object[] {new Location(5, 5), Key.Up, new Location(5, 4)};
            yield return new object[] {new Location(5, 0), Key.Up, new Location(5, 9)};
            yield return new object[] {new Location(5, 5), Key.Left, new Location(4, 5)};
            yield return new object[] {new Location(0, 5), Key.Left, new Location(19, 5)};
            yield return new object[] {new Location(5, 5), Key.Right, new Location(6, 5)};
            yield return new object[] {new Location(19, 5), Key.Right, new Location(0, 5)};
        }

        [Theory]
        [MemberData(nameof(GetNavigationalInputs))]
        private void CalculateNewCursorPosition_ReturnsCorrectLocation(Location currentPosition, Key key, Location expected)
        {
            CursorNavigation cursorNavigation = new CursorNavigation();
            WorldBounds bounds = new WorldBounds(20, 10);

            Location actual =
                cursorNavigation.CalculateNewCursorPosition(currentPosition, bounds, key);

            Assert.Equal(expected, actual);
        }
    }
}