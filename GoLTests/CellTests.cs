using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class LocationTests
    {
        [Fact]
        public void TwoCellsWithSameValue_ShouldEqual()
        {
            Cell cell1 = new Cell(3, 3);
            Cell cell2 = new Cell(3, 3);
            
            Assert.Equal(cell1, cell2);
        }

        [Fact]
        public void GetNeighbouringCells_GivenCell_ReturnsListOfSurroundingCells()
        {
            Cell cell = new Cell(5, 5);
            List<Cell> expected = new List<Cell>
            {
                new Cell(4, 4), new Cell(5, 4), new Cell(6, 4),
                new Cell(4, 5), new Cell(6, 5), new Cell(4, 6),
                new Cell(5, 6), new Cell(6, 6)
            };

            List<Cell> actual = cell.GetNeighbouringCells();

            Assert.Equal(expected, actual);
        }
    }
}