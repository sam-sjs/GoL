using System.Collections.Generic;

namespace GoL
{
    public class GameOfLife
    {
        private readonly World _world;
        private readonly Rules _rules;
        private readonly List<Cell> _nextGeneration = new List<Cell>();

        public GameOfLife(World world, Rules rules)
        {
            _world = world;
            _rules = rules;
        }

        public void SetInitialWorldState(List<Cell> initialState)
        {
            _world.CurrentGeneration = initialState;
        }

        public void AdvanceToNextGeneration()
        {
            BuildNewGeneration();
            SetNewGeneration();
        }

        // Maybe Build isn't the best Domain name?
        private void BuildNewGeneration()
        {
            foreach (Cell cell in _world.CurrentGeneration)
            {
                cell.IsAlive = IsCellAliveInNextGeneration(cell); 
                _nextGeneration.Add(cell);
            }
        }

        private bool IsCellAliveInNextGeneration(Cell cell)
        {
            return cell.IsAlive ?
                _rules.DoesCellStayAlive(_world.GetAliveNeighboursCount(cell)) :
                _rules.DoesCellComeToLife(_world.GetAliveNeighboursCount(cell));
        }

        // This should potentially be on World
        private void SetNewGeneration()
        {
            _world.CurrentGeneration = _nextGeneration;
        }
    }
}