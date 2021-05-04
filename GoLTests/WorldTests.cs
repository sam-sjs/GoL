using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class WorldTests
    {
        [Fact]
        public void ANewWorld_ShouldBeEmpty()
        {
            World world = new World();

            bool worldIsEmpty = world.IsWorldEmpty();

            Assert.True(worldIsEmpty);
        }

        [Fact]
        public void UpdateCurrentGeneration_GivenList_ShouldReplaceTheCurrentGenerationWithTheNewList()
        {
            World world = new World();
            Location location1 = new Location(2, 4);
            Location location2 = new Location(1, 2);
            List<Cell> generationUpdate = new List<Cell> {new(location1, true), new(location2, true)};

            List<Cell> currentGeneration = world.CurrentGeneration;
            world.UpdateCurrentGeneration(generationUpdate);
            List<Cell> newGeneration = world.CurrentGeneration;
            
            Assert.NotEqual(currentGeneration, newGeneration);
        }

        [Fact]
        public void ANewWorld_ShouldNoLongerBeEmptyAfterAddingALivingCell()
        {
            World world = new World();
            Location location = new Location(2, 2);
            List<Cell> initialGeneration = new List<Cell> {new Cell(location, true)};
            world.UpdateCurrentGeneration(initialGeneration);

            bool worldIsEmpty = world.IsWorldEmpty();

            Assert.False(worldIsEmpty);
        }

        // Potential to mock some worlds to clean up test code
        [Fact]
        public void GetAliveNeighboursCount_ReturnsIntOfNumberOfSurroundingCellsInAliveState()
        {
            
        }
    }
}