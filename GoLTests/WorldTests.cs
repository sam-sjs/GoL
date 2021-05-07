using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class WorldTests
    {
        private readonly World _world;
        public WorldTests()
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules); 
            _world = new World(generation);
        }
        
        [Fact]
        public void ANewWorld_ShouldBeEmpty()
        {
            bool worldIsEmpty = _world.IsWorldEmpty();

            Assert.True(worldIsEmpty);
        }

        [Fact]
        public void BuildWorld_ReturnsNull()
        {
            Assert.Null(_world.BuildWorld());
        }

        [Fact]
        public void ANewWorld_ShouldNoLongerBeEmptyAfterAddingACell()
        {
            Location location = new Location(2, 2);
            List<Cell> initialGeneration = new List<Cell> {new Cell(location, true)};
            _world.SetInitialWorldState(initialGeneration);

            bool worldIsEmpty = _world.IsWorldEmpty();

            Assert.False(worldIsEmpty);
        }
        
        [Fact]
        public void SetInitialWorldState_GivenAListOfCells_ShouldUpdatedTheCurrentWorld()
        {
            Location location1 = new Location(2, 2);
            Location location2 = new Location(4, 5);
            Location location3 = new Location(1, 2);
            List<Cell> initialState = new List<Cell>
            {
                new Cell(location1, true), new Cell(location2, false), new Cell(location3, true)
            };

            _world.SetInitialWorldState(initialState);
            
            Assert.Equal(initialState, _world.CurrentGeneration);
        }
        
        
        
        [Fact]
        public void AdvanceToNextGeneration_ShouldUpdateTheCurrentWorldToTheNewWorld()
        {
            Location location1 = new Location(1, 1);
            Location location2 = new Location(1, 2);
            Location location3 = new Location(1, 3);
            Location location4 = new Location(2, 1);
            Location location5 = new Location(2, 2);
            Location location6 = new Location(2, 3);
            Location location7 = new Location(3, 1);
            Location location8 = new Location(3, 2);
            Location location9 = new Location(3, 3);
            List<Cell> initialState = new List<Cell>
            {
                new Cell(location1, true), new Cell(location2, true), new Cell(location3, false),
                new Cell(location4, false), new Cell(location5, true), new Cell(location6, false),
                new Cell(location7, false), new Cell(location8, false), new Cell(location9, false)
            };
            List<Cell> expected = new List<Cell>
            {
                new Cell(location1, true), new Cell(location2, true), new Cell(location3, false),
                new Cell(location4, true), new Cell(location5, true), new Cell(location6, false),
                new Cell(location7, false), new Cell(location8, false), new Cell(location9, false)
            };
            _world.SetInitialWorldState(initialState);

            _world.AdvanceToNextGeneration();

            Assert.Equal(expected, _world.CurrentGeneration);
        }
    }
}