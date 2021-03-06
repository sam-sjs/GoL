using GoL.Game.GoLCursorNavigation;
using Xunit;

namespace GoLTests.Game.GoLCursorNavigation
{
    public class WorldBoundsTests
    {
        [Fact]
        private void TwoWorldBounds_WithTheSameValue_ShouldEqual()
        {
            WorldBounds bounds1 = new WorldBounds(20, 30);
            WorldBounds bounds2 = new WorldBounds(20, 30);

            Assert.Equal(bounds1, bounds2);
        }
    }
}