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
            LivingCell aliveCell1 = new LivingCell(1, 1);
            LivingCell aliveCell2 = new LivingCell(1, 2);
            LivingCell livingCellToTest = new LivingCell(2, 2);
            World world = new World();
            world.SetLivingCell(aliveCell1);
            world.SetLivingCell(aliveCell2);
            world.SetLivingCell(livingCellToTest);
            Rules rules = new Rules(world);

            bool cellComesToLife = rules.IsCellGoingToComeToLifeAt(livingCellToTest);
            
            Assert.True(cellComesToLife);
        }
        
        [Fact]
        private void IsCellGoingToComeToLifeAt_ShouldReturnFalseIfLocationWillContainDeadCell()
        {
            LivingCell livingCellToTest = new LivingCell(2, 2);
            World world = new World();
            world.SetLivingCell(livingCellToTest);
            Rules rules = new Rules(world);

            bool cellComesToLife = rules.IsCellGoingToComeToLifeAt(livingCellToTest);
            
            Assert.False(cellComesToLife);
        }
    }
}