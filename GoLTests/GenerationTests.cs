using System.Collections.Generic;
using System.Linq;
using GoL;
using Xunit;

namespace GoLTests
{
    public class GenerationTests
    {
        [Theory]
        [ClassData(typeof(TestFixtures))]
        public void BuildNextGeneration_CreatesExpectedPattern(List<Cell> input, List<bool> expected)
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            
            List<bool> actual = generation.BuildNextGeneration(input).Select(cell => cell.IsAlive).ToList();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BuildNextGeneration_ShouldNotCreateNewInstanceOfCells()
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            List<Cell> expected = new List<Cell> {new Cell(true), new Cell(false), new Cell(true)};
            
            List<Cell> actual = generation.BuildNextGeneration(expected);
            
            Assert.Equal(expected, actual);
        }
    }
}