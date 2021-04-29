using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class LocationTests
    {
        [Fact]
        public void TwoLocationsWithSameValue_ShouldEqual()
        {
            LivingCell location1 = new LivingCell(3, 3);
            LivingCell location2 = new LivingCell(3, 3);
            
            Assert.Equal(location1, location2);
        }

        [Fact]
        public void GetNeighbours_GivenLocation_ReturnsListOfSurroundingLocations()
        {
            LivingCell livingCell = new LivingCell(5, 5);
            List<LivingCell> expected = new List<LivingCell>
            {
                new LivingCell(4, 4), new LivingCell(5, 4), new LivingCell(6, 4),
                new LivingCell(4, 5), new LivingCell(6, 5), new LivingCell(4, 6),
                new LivingCell(5, 6), new LivingCell(6, 6)
            };

            List<LivingCell> actual = livingCell.GetNeighbouringLocations();

            Assert.Equal(expected, actual);
        }
    }
}