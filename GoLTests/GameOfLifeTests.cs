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
            Rules rules = new Rules();
            GameOfLife game = new GameOfLife(world, rules);
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

        [Fact]
        public void AdvanceToNextGeneration_ShouldUpdateTheCurrentWorldToTheNewWorld()
        {
            World world = new World();
            Rules rules = new Rules();
            GameOfLife game = new GameOfLife(world, rules);
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
            game.SetInitialWorldState(initialState);

            game.AdvanceToNextGeneration();

            Assert.Equal(expected, world.CurrentGeneration);
        }
    }
}