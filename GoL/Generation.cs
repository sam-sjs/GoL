using System.Collections.Generic;

namespace GoL
{
    public class Generation
    {
        private readonly IRenewable _rules;

        public Generation(IRenewable rules)
        {
            _rules = rules;
        }

        public List<Cell> BuildNextGeneration(List<Cell> currentGeneration)
        {
            List<Cell> nextGeneration = new List<Cell>();
            foreach (Cell currentCell in currentGeneration)
            {
                Cell newCell = new Cell(IsCellAliveInNextGeneration(currentCell));
                nextGeneration.Add(newCell);
            }

            return nextGeneration;
        }

        private bool IsCellAliveInNextGeneration(Cell cell)
        {
            return cell.IsAlive
                ? _rules.DoesCellHaveEnoughNeighboursToStayAlive(cell)
                : _rules.DoesCellHaveEnoughNeighboursToComeToLife(cell);
        }
    }
}