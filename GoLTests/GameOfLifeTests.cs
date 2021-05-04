using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class GameOfLifeTests
    {
        [Fact]
        public void SetInitialWorldState_GivenAListOfCells_ShouldUpdatedTheCurrentWorld()
        {
            World world = new World();
            GameOfLife game = new GameOfLife(world);
            Location location1 = new Location(2, 2);
            Location location2 = new Location(4, 5);
            Location location3 = new Location(1, 2);
            List<Cell> initialState = new List<Cell>
            {
                new Cell(location1, true), new Cell(location2, false), new Cell(location3, true)
            };

            game.SetInitialWorldState(initialState);
            
            Assert.Equal(initialState, world.CurrentGeneration);
        }
    }
}