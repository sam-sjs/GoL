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
            Location aliveCell1 = new Location(1, 1);
            Location aliveCell2 = new Location(1, 2);
            Location locationToTest = new Location(2, 2);
            World world = new World();
            world.SetLivingCellAt(aliveCell1);
            world.SetLivingCellAt(aliveCell2);
            world.SetLivingCellAt(locationToTest);
            Rules rules = new Rules(world);

            bool cellComesToLife = rules.IsCellGoingToComeToLifeAt(locationToTest);
            
            Assert.True(cellComesToLife);
        }
        
        [Fact]
        private void IsCellGoingToComeToLifeAt_ShouldReturnFalseIfLocationWillContainDeadCell()
        {
            Location locationToTest = new Location(2, 2);
            World world = new World();
            world.SetLivingCellAt(locationToTest);
            Rules rules = new Rules(world);

            bool cellComesToLife = rules.IsCellGoingToComeToLifeAt(locationToTest);
            
            Assert.False(cellComesToLife);
        }
    }
}