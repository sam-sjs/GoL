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
            Location location = new Location(1, 2);

            world.SetLivingCellAt(location);
            Cell lastCellAdded = world.LivingCells.Last();
            
            Assert.True(lastCellAdded.IsAlive);
        }

        [Fact]
        public void SetLivingCellAt_GivenLocation_CreatesCellWithLocation()
        {
            World world = new World();
            Location expected = new Location(2, 2);
            
            world.SetLivingCellAt(expected);
            Cell lastCellAdded = world.LivingCells.Last();
            Location actual = lastCellAdded.Location;
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsCellAliveAt_GivenLocation_ReturnsTrueWhenCellAtLocationIsAlive()
        {
            World world = new World();
            Location location = new Location(3, 3);
            world.SetLivingCellAt(location);

            bool cellIsAlive = world.IsCellAliveAt(location);
            
            Assert.True(cellIsAlive);
        }
    }
}