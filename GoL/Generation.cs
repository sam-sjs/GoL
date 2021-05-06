using System.Collections.Generic;

namespace GoL
{
    public class Generation
    {
        private readonly Rules _rules;
        private readonly List<Cell> _nextGeneration = new List<Cell>();

        public Generation(Rules rules)
        {
            _rules = rules;
        }
        
        public void BuildNewGeneration(List<Cell> currentGeneration)
        {
            foreach (Cell cell in currentGeneration)
            {
                cell.SetNeighbours(currentGeneration); // Is this the best place to be setting cells neighbours?
                cell.IsAlive = IsCellAliveInNextGeneration(cell); 
                _nextGeneration.Add(cell);
            }
        }

        public List<Cell> GetNewGeneration()
        {
            return _nextGeneration;
        }

        private bool IsCellAliveInNextGeneration(Cell cell)
        {
            return cell.IsAlive ?
                _rules.DoesCellStayAlive(cell) :
                _rules.DoesCellComeToLife(cell);
        }
    }
}