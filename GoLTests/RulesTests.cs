using GoL;
using Xunit;

namespace GoLTests
{
    public class RulesTests
    {
        // Can maybe mock the fake world
        [Fact]
        private void IsCellGoingToComeToLifeAt_ShouldReturnTrueIfLocationWillContainLivingCell()
        {
            Cell livingCell1 = new Cell(1, 1);
            Cell livingCell2 = new Cell(1, 2);
            Cell cellToTest = new Cell(2, 2);
            World world = new World();
            world.SetLivingCell(livingCell1);
            world.SetLivingCell(livingCell2);
            world.SetLivingCell(cellToTest);
            Rules rules = new Rules(world);

            bool cellComesToLife = rules.IsCellGoingToComeToLifeAt(cellToTest);
            
            Assert.True(cellComesToLife);
        }
        
        [Fact]
        private void IsCellGoingToComeToLifeAt_ShouldReturnFalseIfLocationWillContainDeadCell()
        {
            Cell cellToTest = new Cell(2, 2);
            World world = new World();
            world.SetLivingCell(cellToTest);
            Rules rules = new Rules(world);

            bool cellComesToLife = rules.IsCellGoingToComeToLifeAt(cellToTest);
            
            Assert.False(cellComesToLife);
        }
    }
}