
namespace GoL
{
    public class Rules
    {
        private const int CellSurvivesLowerCount = 2;
        private const int CellSurvivesUpperCount = 3;
        private const int CellComesToLifeCount = 3;

        // public bool IsCellAliveInNextGeneration(Cell cell)
        // {
        //     int aliveNeighbours = cell.GetAliveNeighboursCount();
        //     return _world.IsCellAlive(cell) ? DoesCellStayAlive(aliveNeighbours) : DoesCellComeToLife(aliveNeighbours);
        // }

        public bool DoesCellStayAlive(int aliveNeighbours)
        {
            return aliveNeighbours == CellSurvivesLowerCount ||
                   aliveNeighbours == CellSurvivesUpperCount;
        }

        public bool DoesCellComeToLife(int aliveNeighbours)
        {
            return aliveNeighbours == CellComesToLifeCount;
        }
    }
}