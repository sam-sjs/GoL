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
        public void SetLivingCellAt_ShouldAddALivingCellToWorld()
        {
            World world = new World();

            world.SetLivingCellAt(1, 1);
            Cell lastCellAdded = world.LivingCells.Last();
            
            Assert.True(lastCellAdded.IsAlive);
        }

        [Fact]
        public void SetLivingCellAt_ShouldCreateACellWithGivenCoords()
        {
            World world = new World();
            int expectedX = 1;
            int expectedY = 2;
            
            world.SetLivingCellAt(1, 2);
            Cell lastCellAdded = world.LivingCells.Last();
            int actualX = lastCellAdded.Xpos;
            int actualY = lastCellAdded.Ypos;
            
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }
    }
}