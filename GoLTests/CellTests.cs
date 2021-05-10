using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class CellTests
    {
        [Fact]
        public void TwoCellsWithTheSameLivingState_ShouldEqual()
        {
            Cell cell1 = new Cell(true);
            Cell cell2 = new Cell(true);
            
            Assert.Equal(cell1, cell2);
        }
    }
}