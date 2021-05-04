
using GoL;
using Xunit;

namespace GoLTests
{
    public class RulesTests
    {
        [Theory]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(1, false)]
        [InlineData(5, false)]
        public void DoesCellStayAlive_ReturnsExpected(int livingNeighbours, bool expected)
        {
            Rules rules = new Rules();

            bool actual = rules.DoesCellStayAlive(livingNeighbours);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(2, false)]
        [InlineData(6, false)]
        public void DoesCellComeToLife_ReturnsExpected(int livingNeighbours, bool expected)
        {
            Rules rules = new Rules();

            bool actual = rules.DoesCellComeToLife(livingNeighbours);

            Assert.Equal(expected, actual);
        }
    }
}