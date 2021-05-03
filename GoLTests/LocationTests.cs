using GoL;
using Xunit;

namespace GoLTests
{
    public class LocationTests
    {
        public void TwoLocationsWithSameCoordinates_ShouldEqual()
        {
            Location location1 = new Location(1);
            Location location2 = new Location(1);
            
            Assert.Equal(location1, location2);
        }
    }
}