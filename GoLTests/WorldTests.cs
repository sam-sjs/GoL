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
            Cell cell = new Cell(1, 2, true);

            world.SetLivingCell(cell);
            bool cellIsAlive = world.IsCellAlive(cell);

            Assert.True(cellIsAlive);
        }

        [Fact]
        public void IsCellAlive_GivenCell_ReturnsTrueWhenCellAtIsAlive()
        {
            World world = new World();
            Cell cell = new Cell(3, 3, true);
            world.SetLivingCell(cell);

            bool cellIsAlive = world.IsCellAlive(cell);

            Assert.True(cellIsAlive);
        }

        [Fact]
        public void NewWorld_ShouldNoLongerBeEmptyAfterAddingALivingCell()
        {
            World world = new World();
            Cell cell = new Cell(1, 1, true);
            world.SetLivingCell(cell);

            bool worldIsEmpty = world.IsWorldEmpty();

            Assert.False(worldIsEmpty);
        }
    }
}