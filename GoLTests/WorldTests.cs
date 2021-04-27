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
    }
}