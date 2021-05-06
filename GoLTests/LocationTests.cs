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
            Location location1 = new Location(1, 2);
            Location location2 = new Location(1, 2);
            
            Assert.Equal(location1, location2);
        }
        
        [Fact]
        public void GetNeighbouringLocations_ReturnsListOfSurroundingLocations()
        {
            Location location = new Location(5, 5);
            List<Location> expected = new List<Location>
            {
                new Location(4, 4), new Location(5, 4), new Location(6, 4),
                new Location(4, 5), new Location(6, 5), new Location(4, 6),
                new Location(5, 6), new Location(6, 6)
            };

            List<Location> actual = location.GetNeighbouringLocations();

            Assert.Equal(expected, actual);
        }
    }
}