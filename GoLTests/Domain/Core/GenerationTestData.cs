using System.Collections;
using System.Collections.Generic;
using GoL.Game.GoLCell;

namespace GoLTests.Game.GoLGeneration
{
    public class GenerationTestData : IEnumerable<object[]>
    {
        private static readonly Cell Living1 = new (true);
        private static readonly Cell Living2 = new Cell(true);
        private static readonly Cell Living3 = new Cell(true);
        private static readonly Cell Living4 = new Cell(true);
        private static readonly List<Cell> OneLivingNeighbour = new List<Cell> {Living1}; 
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

        public GenerationTestData()
        {
            _livingCellWithOneLivingNeighbours.Neighbours.AddRange(OneLivingNeighbour);
            _deadCellWithOneLivingNeighbours.Neighbours.AddRange(OneLivingNeighbour);
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
                new List<Cell>
                {
                    _livingCellWithOneLivingNeighbours,
                    _deadCellWithTwoLivingNeighbours,
                    _livingCellWithThreeLivingNeighbours,
                    _deadCellWithFourLivingNeighbours
                },
                new List<bool> { false, false, true, false }
            };
            
            yield return new object[]
            {
                new List<Cell>
                {
                    _deadCellWithOneLivingNeighbours,
                    _livingCellWithTwoLivingNeighbours,
                    _deadCellWithThreeLivingNeighbours,
                    _livingCellWithFourLivingNeighbours
                },
                new List<bool> { false, true, true, false }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}