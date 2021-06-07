using System.Collections.Generic;
using GoL.Game.GoLDisplay;
using GoL.Game.GoLNavigation;
using GoL.Input;
using Xunit;

namespace GoLTests.Game.GoLNavigation
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
            Navigation navigation = new Navigation();
            WorldBounds bounds = new WorldBounds(20, 10);

            Location actual =
                navigation.CalculateNewCursorPosition(currentPosition, bounds, key);

            Assert.Equal(expected, actual);
        }
    }
}