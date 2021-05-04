using GoL;
using Xunit;

namespace GoLTests
{
    public class CellTests
    {
        [Fact]
        public void TwoCellsWithSameValue_ShouldEqual()
        {
            Cell cell1 = new Cell(3, 3, true);
            Cell cell2 = new Cell(3, 3, true);

            Assert.Equal(cell1, cell2);
        }

        [Fact]
        public void GetAliveNeighboursCount_ShouldReturnIntOfSurroundingLivingNeighbours()
        {
            Cell livingCell1 = new Cell(1, 1, true);
            Cell livingCell2 = new Cell(1, 2, true);
            Cell cellToTest = new Cell(2, 2, true);
            World world = new World();
            world.SetLivingCell(livingCell1);
            world.SetLivingCell(livingCell2);
            world.SetLivingCell(cellToTest);
            int expected = 2;

            int actual = cellToTest.GetAliveNeighboursCount();

            Assert.Equal(expected, actual);
        }
    }
}