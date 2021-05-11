using System.Collections.Generic;

namespace GoL
{
    public class Generation
    {
        private readonly Rules _rules;

        public Generation(Rules rules)
        {
            _rules = rules;
        }

        public List<Cell> NextGeneration { get; } = new List<Cell>();
        
        public void BuildNextGeneration(List<Cell> currentGeneration)
        {
            NextGeneration.Clear();
            foreach (Cell cell in currentGeneration)
            {
                cell.IsAlive = IsCellAliveInNextGeneration(cell);
                NextGeneration.Add(cell);
            }
        }

        private bool IsCellAliveInNextGeneration(Cell cell)
        {
            return cell.IsAlive ?
                _rules.DoesCellStayAlive(cell) :
                _rules.DoesCellComeToLife(cell);
        }
    }
}