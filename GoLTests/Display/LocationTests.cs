using GoL.Game.GoLDisplay;
using Xunit;

namespace GoLTests.Game.GoLDisplay
{
    public class WorldLocationTests
    {
        [Fact]
        public void TwoWorldLocations_WithSameCoordinates_ShouldEqual()
        {
            Location location1 = new Location(3, 2); 
            Location location2 = new Location(3, 2);
            
            Assert.Equal(location1, location2);
        }
    }
}