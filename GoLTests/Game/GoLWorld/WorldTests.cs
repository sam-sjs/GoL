using System.Collections.Generic;
using System.Linq;
using GoL.Game.GoLDisplay;
using GoL.Game.GoLWorld;
using GoL.Game.GoLCell;
using Xunit;

namespace GoLTests.Game.GoLWorld
{
    public class WorldTests
    {
        [Fact]
        public void ANewWorld_ShouldContainTheCorrectNumberOfCells()
        {
            World world = new World(3, 3);
            int expected = 9;

            int actual = world.CellFormation.Length;
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ANewWorld_ShouldContainOnlyDeadCells()
        {
            World world = new World(3, 3);

            List<Cell> cellsAsList = world.CellFormation.Cast<Cell>().ToList();
            bool allDeadCells = cellsAsList.All(cell => cell.IsAlive == false);

            Assert.True(allDeadCells);
        }

        [Fact]
        public void CellsInWorld_ShouldBeAssigned8Neighbours()
        {
            World world = new World(5, 5);
            int expected = 8;

            Cell cellToTest = world.CellFormation[1, 1];
            int actual = cellToTest.Neighbours.Count;
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CellsInWorld_ShouldBeAssociatedWithCorrectNeighbours()
        {
            World world = new World(5, 5);

            Cell cellToTest = world.CellFormation[2, 2];
            List<Cell> expected = new List<Cell>
            {
                world.CellFormation[1, 1], world.CellFormation[2, 1], world.CellFormation[3, 1],
                world.CellFormation[1, 2], world.CellFormation[3, 2],
                world.CellFormation[1, 3], world.CellFormation[2, 3], world.CellFormation[3, 3]
            };
            
            Assert.Equal(expected, cellToTest.Neighbours);
        }

        [Theory]
        [InlineData(false, "..........\n..........\n..........\n..........\n..........")]
        [InlineData(true, "..........\n..........\n..........\n..██......\n..........")]
        public void AWorld_ShouldHaveTheCorrectStringRepresentation(bool cellAlive, string expected)
        {
            World world = new World(5, 5);
            world.CellFormation[1, 3].IsAlive = cellAlive;
            
            string actual = world.ToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetLivingCellAtLocation_ShouldUpdateTheCorrectCellToAlive() // Split to two tests?
        {                                                        // Or add under test that checks all cells start dead
            World world = new World(5, 5);
            Location location = new Location(2, 3);

            bool initialState = world.CellFormation[location.Column, location.Row].IsAlive;
            world.SetLivingCellAtLocation(location);
            bool newState = world.CellFormation[location.Column, location.Row].IsAlive;
            
            Assert.False(initialState);
            Assert.True(newState);
        }

        [Fact]
        public void GetCellsInFormation_ShouldReturnAFlattenedListOfCells()
        {
            World world = new World(3, 3);
            List<Cell> expected = new List<Cell>
            {
                world.CellFormation[0, 0], world.CellFormation[0, 1], world.CellFormation[0, 2],
                world.CellFormation[1, 0], world.CellFormation[1, 1], world.CellFormation[1, 2],
                world.CellFormation[2, 0], world.CellFormation[2, 1], world.CellFormation[2, 2]
            };

            List<Cell> actual = world.GetCurrentCellFormation();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetNewCellFormation_ShouldSetCellsInCorrectPositions()
        {
            World world = new World(3, 3);
            List<Cell> input = new List<Cell>
            {
                new Cell(false), new Cell(true), new Cell(false),
                new Cell(true), new Cell(false), new Cell(true),
                new Cell(false), new Cell(false), new Cell(true)
            };
            Cell[,] expected = new Cell[,]
            {
                {
                    input[0], input[1], input[2]
                },
                {
                    input[3], input[4], input[5]
                },
                {
                    input[6], input[7], input[8]
                }
            };

            world.SetNewCellFormation(input);
            Cell[,] actual = world.CellFormation;

            Assert.Equal(expected, actual);
        }
    }
}