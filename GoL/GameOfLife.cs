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
            foreach (Cell cell  in _world.CurrentGeneration)
            {
                if (cell.IsAlive)
                {
                    cell.IsAlive = _rules.DoesCellStayAlive(_world.GetAliveNeighboursCount(cell));
                }
                else
                {
                    cell.IsAlive = _rules.DoesCellComeToLife(_world.GetAliveNeighboursCount(cell));
                }
                _nextGeneration.Add(cell);
            }

            _world.CurrentGeneration = _nextGeneration;
        }
    }
}