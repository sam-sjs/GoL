using GoL;
using Xunit;

namespace GoLTests
{
    public class LocationTests
    {
        [Fact]
        public void TwoLocationsWithSameValue_ShouldEqual()
        {
            Location location1 = new Location(3, 3);
            Location location2 = new Location(3, 3);
            
            Assert.Equal(location1, location2);
        }
    }
}