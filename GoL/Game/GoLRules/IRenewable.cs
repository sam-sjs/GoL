using GoL.Game.GoLCell;

namespace GoL.Game.GoLRules
{
    public interface IRenewable
    {
        public bool DoesCellHaveEnoughNeighboursToStayAlive(Cell cell);
        public bool DoesCellHaveEnoughNeighboursToComeToLife(Cell cell);
    }
}