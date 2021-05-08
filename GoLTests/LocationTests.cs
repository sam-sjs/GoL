using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class LocationTests
    {
        [Fact]
        public void TwoLocationsWithSameCoordinates_ShouldEqual()
        {
            Location location1 = new Location(2, 2);
            Location location2 = new Location(2, 2);
            
            Assert.Equal(location1, location2);
        }
    }
}