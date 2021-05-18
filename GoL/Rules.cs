
namespace GoL
{
    public class Rules
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