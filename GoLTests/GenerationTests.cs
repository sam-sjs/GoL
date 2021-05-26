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
        public void BuildNextGeneration_ShouldCreateNewInstanceOfCells()
        // This test is kind of stupid now, think of something better.
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            List<Cell> input = new List<Cell> {new Cell(true), new Cell(false), new Cell(true)};
            
            List<Cell> output = generation.BuildNextGeneration(input);
            
            Assert.NotEqual(input, output);
        }
    }
}