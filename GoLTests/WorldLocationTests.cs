using GoL;
using Xunit;

namespace GoLTests
{
    public class WorldLocationTests
    {
        [Fact]
        public void TwoWorldLocations_WithSameCoordinates_ShouldEqual()
        {
            WorldLocation location1 = new WorldLocation(3, 2); 
            WorldLocation location2 = new WorldLocation(3, 2);
            
            Assert.Equal(location1, location2);
        }
    }
}