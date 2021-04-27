using System.Linq;
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
        public void SetLivingCell_ShouldAddALivingCellToWorld()
        {
            World world = new World();

            world.SetLivingCell();
            Cell lastCellAdded = world.LivingCells.Last();
            
            Assert.True(lastCellAdded.IsAlive);
        }
    }
}