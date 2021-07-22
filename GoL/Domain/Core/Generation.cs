using System.Collections.Generic;
using GoL.Game.GoLCell;
using GoL.Game.GoLRules;

namespace GoL.Game.GoLGeneration
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