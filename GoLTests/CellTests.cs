using GoL;
using Xunit;

namespace GoLTests
{
    public class CellTests
    {
        [Fact]
        public void TwoCellsWithSameValue_ShouldEqual()
        {
            Location location1 = new Location(3, 3);
            Location location2 = new Location(3, 3);
            Cell cell1 = new Cell(location1, true);
            Cell cell2 = new Cell(location2, true);

            Assert.Equal(cell1, cell2);
        }
    }
}