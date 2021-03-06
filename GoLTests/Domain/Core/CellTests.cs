using System.Collections.Generic;
using GoL.Game.GoLCell;
using Xunit;

namespace GoLTests.Game.GoLCell
{
    public class CellTests
    {
        [Fact]
        public void GetLivingNeighboursCount_ReturnsCorrectCount()
        {
            Cell cellToTest = new Cell(true);
            List<Cell> neighbours = new List<Cell> {new Cell (true), new Cell (false), new Cell (true)};
            cellToTest.Neighbours.AddRange(neighbours);
            int expected = 2;

            int actual = cellToTest.GetLivingNeighboursCount();

            Assert.Equal(expected, actual);
        }
    }
}