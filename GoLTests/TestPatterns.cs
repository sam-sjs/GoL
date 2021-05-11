using System.Collections;
using System.Collections.Generic;
using GoL;

namespace GoLTests
{
    public class TestPatterns : IEnumerable<object[]>
    {
        private static readonly Cell Living1 = new Cell(true);
        private static readonly Cell Living2 = new Cell(true);
        private static readonly Cell Living3 = new Cell(true);
        private static readonly Cell Living4 = new Cell(true);
        private static readonly List<Cell> OneLivingNeighbours = new List<Cell> {Living1}; 
        private static readonly List<Cell> TwoLivingNeighbours = new List<Cell> {Living1, Living2}; 
        private static readonly List<Cell> ThreeLivingNeighbours = new List<Cell> {Living1, Living2, Living3}; 
        private static readonly List<Cell> FourLivingNeighbours = new List<Cell> {Living1, Living2, Living3, Living4}; 
        private readonly Cell _livingCellWithOneLivingNeighbours = new Cell(true);
        private readonly Cell _deadCellWithOneLivingNeighbours = new Cell(true);
        private readonly Cell _livingCellWithTwoLivingNeighbours = new Cell(true);
        private readonly Cell _deadCellWithTwoLivingNeighbours = new Cell(false);
        private readonly Cell _livingCellWithThreeLivingNeighbours = new Cell(true);
        private readonly Cell _deadCellWithThreeLivingNeighbours = new Cell(false);
        private readonly Cell _livingCellWithFourLivingNeighbours = new Cell(true);
        private readonly Cell _deadCellWithFourLivingNeighbours = new Cell(false);

        public TestPatterns()
        {
            _livingCellWithOneLivingNeighbours.Neighbours.AddRange(OneLivingNeighbours);
            _deadCellWithOneLivingNeighbours.Neighbours.AddRange(OneLivingNeighbours);
            _livingCellWithTwoLivingNeighbours.Neighbours.AddRange(TwoLivingNeighbours);
            _deadCellWithTwoLivingNeighbours.Neighbours.AddRange(TwoLivingNeighbours);
            _livingCellWithThreeLivingNeighbours.Neighbours.AddRange(ThreeLivingNeighbours);
            _deadCellWithThreeLivingNeighbours.Neighbours.AddRange(ThreeLivingNeighbours);
            _livingCellWithFourLivingNeighbours.Neighbours.AddRange(FourLivingNeighbours);
            _deadCellWithFourLivingNeighbours.Neighbours.AddRange(FourLivingNeighbours);
        }
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Cell> { _livingCellWithOneLivingNeighbours },
                false
            };
            
            yield return new object[]
            {
                new List<Cell> { _deadCellWithOneLivingNeighbours },
                false
            };
            
            yield return new object[]
            {
                new List<Cell> { _livingCellWithTwoLivingNeighbours },
                true
            };
            
            yield return new object[]
            {
                new List<Cell> { _deadCellWithTwoLivingNeighbours },
                false
            };
            
            yield return new object[]
            {
                new List<Cell> { _livingCellWithThreeLivingNeighbours },
                true
            };
            
            yield return new object[]
            {
                new List<Cell> { _deadCellWithThreeLivingNeighbours },
                true
            };
            
            yield return new object[]
            {
                new List<Cell> { _livingCellWithFourLivingNeighbours },
                false
            };
            
            yield return new object[]
            {
                new List<Cell> { _deadCellWithFourLivingNeighbours },
                false
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}