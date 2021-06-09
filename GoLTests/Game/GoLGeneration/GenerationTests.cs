using System.Collections.Generic;
using System.Linq;
using GoL.Game.GoLRules;
using GoL.Game.GoLGeneration;
using GoL.Game.GoLCell;
using Moq;
using Xunit;

namespace GoLTests.Game.GoLGeneration
{
    public class GenerationTests
    {
        [Theory]
        [ClassData(typeof(GenerationTestData))]
        public void BuildNextGeneration_CreatesExpectedPattern(List<Cell> input, List<bool> expected)
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            
            List<bool> actual = generation.BuildNextGeneration(input).Select(cell => cell.IsAlive).ToList();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DoesCellHaveEnoughNeighboursToStayAlive_IsCalledOnEveryLivingCell()
        {
            Mock<IRenewable> mockRules = new Mock<IRenewable>();
            Generation generation = new Generation(mockRules.Object);
            List<Cell> input = new List<Cell> {new (true), new (true), new (false), new (true)};
            int expectedCalls = 3;

            generation.BuildNextGeneration(input);

            mockRules.Verify(rules => rules.DoesCellHaveEnoughNeighboursToStayAlive(It.IsAny<Cell>()),
                Times.Exactly(expectedCalls));
        }
        
        [Fact]
        public void DoesCellHaveEnoughNeighboursToComeToLife_IsCalledOnEveryDeadCell()
        {
            Mock<IRenewable> mockRules = new Mock<IRenewable>();
            Generation generation = new Generation(mockRules.Object);
            List<Cell> input = new List<Cell> {new (true), new (true), new (false), new (true)};
            int expectedCalls = 1;

            generation.BuildNextGeneration(input);

            mockRules.Verify(rules => rules.DoesCellHaveEnoughNeighboursToComeToLife(It.IsAny<Cell>()),
                Times.Exactly(expectedCalls));
        }

        [Fact]
        public void BuildNextGeneration_ShouldCreateNewInstanceOfCells()
        {
            Rules rules = new Rules();
            Generation generation = new Generation(rules);
            List<Cell> input = new List<Cell> {new (true), new (false), new (true)};
            
            List<Cell> output = generation.BuildNextGeneration(input);
            
            Assert.NotEqual(input, output);
        }
    }
}