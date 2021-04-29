using GoL;
using Xunit;

namespace GoLTests
{
    public class WorldTests
    {
        [Fact]
        public void NewWorld_ShouldBeEmpty()
        {
            World world = new World();
            
            bool worldIsEmpty = world.IsWorldEmpty();
            
            Assert.True(worldIsEmpty);
        }

        [Fact]
        public void SetLivingCellAt_ShouldAddALivingCellToWorld()
        {
            World world = new World();
            LivingCell livingCell = new LivingCell(1, 2);

            world.SetLivingCell(livingCell);
            bool cellIsAlive = world.IsCellAlive(livingCell);
            
            Assert.True(cellIsAlive);
        }

        [Fact]
        public void IsCellAliveAt_GivenLocation_ReturnsTrueWhenCellAtLocationIsAlive()
        {
            World world = new World();
            LivingCell livingCell = new LivingCell(3, 3);
            world.SetLivingCell(livingCell);

            bool cellIsAlive = world.IsCellAlive(livingCell);
            
            Assert.True(cellIsAlive);
        }

        [Fact]
        public void NewWorld_ShouldNoLongerBeEmptyAfterAddingACell()
        {
            World world = new World();
            LivingCell livingCell = new LivingCell(1, 1);
            world.SetLivingCell(livingCell);
            
            bool worldIsEmpty = world.IsWorldEmpty();
            
            Assert.False(worldIsEmpty);
        }
    }
}