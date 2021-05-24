using System.Collections.Generic;
using System.Linq;
using GoL;
using Xunit;

namespace GoLTests
{
    public class WorldTests
    {
        [Fact]
        public void ANewWorld_ShouldBeEmptyOfCells()
        {
            World world = new World(1, 1);

            IEnumerable<Cell> cellFormation = world.CellFormation.Cast<Cell>();
            bool noCellsInFormation = cellFormation.All(cell => cell == null);

            Assert.True(noCellsInFormation);
        }

        [Fact]
        public void Populate_ShouldPopulateA2dArrayWithCells()
        {
            World world = new World(3, 3);

            world.Populate();
            
            Assert.NotEmpty(world.CellFormation);
        }

        [Fact]
        public void Populate_ShouldAssociateEachCellWith8Neighbours()
        {
            World world = new World(5, 5);
            int expected = 8;

            world.Populate();
            Cell cellToTest = world.CellFormation[1, 1];
            int actual = cellToTest.Neighbours.Count;
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Populate_ShouldAssociateCellWithCorrectNeighbours()
        {
            World world = new World(5, 5);

            world.Populate();
            Cell cellToTest = world.CellFormation[2, 2];
            List<Cell> expected = new List<Cell>
            {
                world.CellFormation[1, 1], world.CellFormation[1, 2], world.CellFormation[1, 3],
                world.CellFormation[2, 1], world.CellFormation[2, 3],
                world.CellFormation[3, 1], world.CellFormation[3, 2], world.CellFormation[3, 3]
            };
            
            Assert.Equal(expected, cellToTest.Neighbours);
        }

        [Fact]
        public void ANewWorld_ShouldNoLongerBeEmptyAfterAddingACell()
        {
            World world = new World(2, 2);

            world.Populate();

            IEnumerable<Cell> cellFormation = world.CellFormation.Cast<Cell>();
            bool worldIsNotEmpty = cellFormation.All(cell => cell != null);

            Assert.True(worldIsNotEmpty);
        }

        [Fact]
        public void AWorld_ShouldHaveTheCorrectStringRepresentation()
        {   // Think if there is a way to do this without Populate() - also could use a test with living cell
            World world = new World(5, 5);
            world.Populate();
            string expected = ".....\n.....\n.....\n.....\n.....";

            string actual = world.ToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetLivingCellAtLocation_ShouldUpdateTheCorrectCellToAlive()
        {   // As above consider whether there is a way to do this without Populate()
            World world = new World(5, 5);
            Location location = new Location(2, 3);
            world.Populate();

            bool initialState = world.CellFormation[3, 2].IsAlive;
            world.SetLivingCellAtLocation(location);
            bool newState = world.CellFormation[3, 2].IsAlive;
            
            Assert.False(initialState);
            Assert.True(newState);
        }

        [Fact]
        public void GetCellsInFormation_ShouldReturnAFlattenedListOfCells()
        {
            World world = new World(3, 3);
            world.Populate();
            List<Cell> expected = new List<Cell>
            {
                world.CellFormation[0, 0], world.CellFormation[0, 1], world.CellFormation[0, 2],
                world.CellFormation[1, 0], world.CellFormation[1, 1], world.CellFormation[1, 2],
                world.CellFormation[2, 0], world.CellFormation[2, 1], world.CellFormation[2, 2]
            };

            List<Cell> actual = world.GetCellsInFormation();

            Assert.Equal(expected, actual);
        }
    }
}