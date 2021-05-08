
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
            _cellToTest = new Cell(new Location(2, 2), true);
        }
        
        // public static IEnumerable<object[]> StayAliveData()
        // {
        //     Location loc1 = new Location();
        //     Location loc2 = new Location();
        //     Location loc3 = new Location();
        //     Location loc4 = new Location();
        //     yield return new object[] {new List<Cell> {new(loc1, true), new(loc2, true), new(loc3, false) }, true};
        //     yield return new object[] {new List<Cell> {new(loc1, true), new(loc2, true), new(loc3, true) }, true};
        //     yield return new object[] {new List<Cell> {new(loc1, true), new(loc2, false), new(loc3, false) }, false};
        //     yield return new object[] {new List<Cell> {new(loc1, true), new(loc2, true), new(loc3, true), new(loc4, true) }, false};
        // }
        //
        // [Theory]
        // [MemberData(nameof(StayAliveData))]
        // public void DoesCellStayAlive_ReturnsExpected(List<Cell> neighbours, bool expected)
        // {
        //     // _cellToTest.SetNeighbours(neighbours);
        //     
        //     bool actual = _rules.DoesCellStayAlive(_cellToTest);
        //
        //     Assert.Equal(expected, actual);
        // }
        //
        // public static IEnumerable<object[]> ComeToLifeData()
        // {
        //     Location loc1 = new Location();
        //     Location loc2 = new Location();
        //     Location loc3 = new Location();
        //     Location loc4 = new Location();
        //     yield return new object[] {new List<Cell> {new(loc1, true), new(loc2, false)}, false};
        //     yield return new object[] {new List<Cell> {new(loc1, true), new(loc2, true), new(loc3, true), new(loc4, false)}, true};
        //     yield return new object[] {new List<Cell> {new(loc1, true), new(loc2, true), new(loc3, true), new(loc4, true)}, false};
        // }
        //
        // [Theory]
        // [MemberData(nameof(ComeToLifeData))]
        // public void DoesCellComeToLife_ReturnsExpected(List<Cell> neighbours, bool expected)
        // {
        //     // _cellToTest.SetNeighbours(neighbours);
        //     
        //     bool actual = _rules.DoesCellComeToLife(_cellToTest);
        //
        //     Assert.Equal(expected, actual);
        // }
    }
}