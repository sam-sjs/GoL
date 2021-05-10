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
        public void BuildWorld_GivenHeightAndWidth_Returns2dArrayOfCells()
        {
            int rows = 3;
            int columns = 3;
            Cell[,] expected = new Cell[3, 3]
            {
                { new Cell(false), new Cell(false), new Cell(false) },
                { new Cell(false), new Cell(false), new Cell(false) },
                { new Cell(false), new Cell(false), new Cell(false) }
            };

            Cell[,] actual = _world.BuildWorld(rows, columns);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BuildWorld_ShouldAssociateEachCellWith8Neighbours() // Can check correct positioning in another test by testing cell positions in the "world" grid to the list of neighbours.
        {
            int rows = 5;
            int columns = 5;
            int expected = 8;

            Cell[,] cells = _world.BuildWorld(rows, columns);
            
            Assert.Equal(expected, cells[2, 2].Neighbours.Count);
        }

        [Fact]
        public void ANewWorld_ShouldNoLongerBeEmptyAfterAddingACell()
        {
            Location location = new Location(2, 2);
            List<Cell> initialGeneration = new List<Cell> {new Cell(true)};
            _world.SetInitialWorldState(initialGeneration);

            bool worldIsEmpty = _world.IsWorldEmpty();

            Assert.False(worldIsEmpty);
        }
        
        [Fact]
        public void SetInitialWorldState_GivenAListOfCells_ShouldUpdatedTheCurrentWorld()
        {
            List<Cell> initialState = new List<Cell>
            {
                new Cell(true), new Cell(false), new Cell(true)
            };

            _world.SetInitialWorldState(initialState);
            
            Assert.Equal(initialState, _world.CurrentGeneration);
        }
        
        // [Fact]
        // public void AdvanceToNextGeneration_ShouldUpdateTheCurrentWorldToTheNewWorld()
        // {
        //     Location location1 = new Location();
        //     Location location2 = new Location();
        //     Location location3 = new Location();
        //     Location location4 = new Location();
        //     Location location5 = new Location();
        //     Location location6 = new Location();
        //     Location location7 = new Location();
        //     Location location8 = new Location();
        //     Location location9 = new Location();
        //     List<Cell> initialState = new List<Cell>
        //     {
        //         new Cell(location1, true), new Cell(location2, true), new Cell(location3, false),
        //         new Cell(location4, false), new Cell(location5, true), new Cell(location6, false),
        //         new Cell(location7, false), new Cell(location8, false), new Cell(location9, false)
        //     };
        //     List<Cell> expected = new List<Cell>
        //     {
        //         new Cell(location1, true), new Cell(location2, true), new Cell(location3, false),
        //         new Cell(location4, true), new Cell(location5, true), new Cell(location6, false),
        //         new Cell(location7, false), new Cell(location8, false), new Cell(location9, false)
        //     };
        //     _world.SetInitialWorldState(initialState);
        //
        //     _world.AdvanceToNextGeneration();
        //
        //     Assert.Equal(expected, _world.CurrentGeneration);
        // }
    }
}