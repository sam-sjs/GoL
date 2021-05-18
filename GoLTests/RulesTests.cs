
using System.Collections.Generic;
using GoL;
using Xunit;

namespace GoLTests
{
    public class RulesTests
    {
        private readonly Rules _rules;
        private readonly Cell _cellToTest;
        
        public RulesTests()
        {
            _rules = new Rules();
            _cellToTest = new Cell(true);
        }
        
        public static IEnumerable<object[]> StayAliveData()
        {
            yield return new object[] {new List<Cell> {new(true), new(true), new(false) }, true};
            yield return new object[] {new List<Cell> {new(true), new(true), new(true) }, true};
            yield return new object[] {new List<Cell> {new(true), new(false), new(false) }, false};
            yield return new object[] {new List<Cell> {new(true), new(true), new(true), new(true) }, false};
        }
        
        [Theory]
        [MemberData(nameof(StayAliveData))]
        public void DoesCellStayAlive_ReturnsExpected(List<Cell> neighbours, bool expected)
        {
            _cellToTest.Neighbours.AddRange(neighbours);
            
            bool actual = _rules.DoesCellHaveEnoughNeighboursToStayAlive(_cellToTest);
        
            Assert.Equal(expected, actual);
        }
        
        public static IEnumerable<object[]> ComeToLifeData()
        {
            yield return new object[] {new List<Cell> {new(true), new(false)}, false};
            yield return new object[] {new List<Cell> {new(true), new(true), new(true), new(false)}, true};
            yield return new object[] {new List<Cell> {new(true), new(true), new(true), new(true)}, false};
        }
        
        [Theory]
        [MemberData(nameof(ComeToLifeData))]
        public void DoesCellComeToLife_ReturnsExpected(List<Cell> neighbours, bool expected)
        {
            _cellToTest.Neighbours.AddRange(neighbours);
            
            bool actual = _rules.DoesCellHaveEnoughNeighboursToComeToLife(_cellToTest);
        
            Assert.Equal(expected, actual);
        }
    }
}