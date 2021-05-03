using System.Collections.Generic;
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
        public void GetNeighbouringCells_GivenCell_ReturnsListOfSurroundingCells()
        {
            Cell cell = new Cell(5, 5, true);
            List<Cell> expected = new List<Cell>
            {
                new Cell(4, 4, true), new Cell(5, 4, true), new Cell(6, 4, true),
                new Cell(4, 5, true), new Cell(6, 5, true), new Cell(4, 6, true),
                new Cell(5, 6, true), new Cell(6, 6, true)
            };

            List<Cell> actual = cell.GetNeighbouringCells();

            Assert.Equal(expected, actual);
        }
    }
}