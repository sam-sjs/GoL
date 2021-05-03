using GoL;
using Xunit;

namespace GoLTests
{
    public class LocationTests
    {
        [Fact]
        public void TwoLocationsWithSameCoordinates_ShouldEqual()
        {
            Location location1 = new Location(1, 2);
            Location location2 = new Location(1, 2);
            
            Assert.Equal(location1, location2);
        }
    }
}