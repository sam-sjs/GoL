using System.Collections.Generic;
using System.Linq;
using GoL;
using Xunit;

namespace GoLTests
{
    public class GenerationTests
    {
        [Theory]
        [ClassData(typeof(TestPatterns))]
        public void BuildNextGeneration_CreatesExpectedPattern(List<Cell> input, List<bool> expected)
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            
            generation.BuildNextGeneration(input);
            List<bool> actual = generation.NextGeneration.Select(cell => cell.IsAlive).ToList();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BuildNextGeneration_ShouldNotCreateNewInstanceOfCells()
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            List<Cell> input = new List<Cell> {new Cell(true), new Cell(false), new Cell(true)};
            
            generation.BuildNextGeneration(input);
            
            Assert.Equal(input, generation.NextGeneration);
        }
    }
}