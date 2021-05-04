using GoL;
using Xunit;

namespace GoLTests
{
    public class RulesTests
    {
        // Can maybe mock the fake world
        // [Fact]
        // private void IsCellAliveInNextGeneration_ShouldReturnTrueIfCellWillBeAliveInNextGeneration()
        // {
        //     Cell livingCell1 = new Cell(1, 1, true);
        //     Cell livingCell2 = new Cell(1, 2, true);
        //     Cell cellToTest = new Cell(2, 2, true);
        //     World world = new World();
        //     world.SetLivingCell(livingCell1);
        //     world.SetLivingCell(livingCell2);
        //     world.SetLivingCell(cellToTest);
        //     Rules rules = new Rules(world);
        //
        //     bool cellComesToLife = rules.IsCellAliveInNextGeneration(cellToTest);
        //
        //     Assert.True(cellComesToLife);
        // }

        // [Fact]
        // private void IsCellAliveInNextGeneration_ShouldReturnFalseIfCellWillBeDeadInNextGeneration()
        // {
        //     Cell cellToTest = new Cell(2, 2, true);
        //     World world = new World();
        //     world.SetLivingCell(cellToTest);
        //     Rules rules = new Rules(world);
        //
        //     bool cellComesToLife = rules.IsCellAliveInNextGeneration(cellToTest);
        //     
        //     Assert.False(cellComesToLife);
        // }
    }
}