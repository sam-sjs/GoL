using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class GenerationTests
    {
        [Theory]
        [ClassData(typeof(TestPatterns))]
        public void BuildNextGeneration_CreatesExpectedPattern(List<Cell> input, bool expected)
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            
            generation.BuildNextGeneration(input);
            bool actual = generation.NextGeneration[0].IsAlive;
            
            Assert.Equal(expected, actual);
        }
    }
}