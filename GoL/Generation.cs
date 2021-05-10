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
                bool cellIsAlive = IsCellAliveInNextGeneration(cell); 
                _nextGeneration.Add(new Cell(cellIsAlive));
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