using GoL.Game.GoLCell;

namespace GoL.Game.GoLRules
{
    public class Rules : IRenewable
    {
        private const int CellSurvivesLowerCount = 2;
        private const int CellSurvivesUpperCount = 3;
        private const int CellComesToLifeCount = 3;

        public bool DoesCellHaveEnoughNeighboursToStayAlive(Cell cell)
        {
            return cell.GetLivingNeighboursCount() == CellSurvivesLowerCount ||
                   cell.GetLivingNeighboursCount() == CellSurvivesUpperCount;
        }

        public bool DoesCellHaveEnoughNeighboursToComeToLife(Cell cell)
        {
            return cell.GetLivingNeighboursCount() == CellComesToLifeCount;
        }
    }
}