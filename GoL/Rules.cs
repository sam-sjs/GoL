using System.Collections.Generic;
using System.Linq;

namespace GoL
{
    public class Rules
    {
        private const int CellSurvivesLowerCount = 2;
        private const int CellSurvivesUpperCount = 3;
        private const int CellComesToLifeCount = 3;
        private readonly World _world;
        public Rules(World world)
        {
            _world = world;
        }
        public bool IsCellGoingToComeToLifeAt(Cell cell)
        {
            int aliveNeighbours = GetAliveNeighboursCount(cell);
            if (_world.IsCellAlive(cell))
            {
                return DoesCellStayAlive(aliveNeighbours);
            }

            return DoesCellComeToLife(aliveNeighbours);
        }

        private int GetAliveNeighboursCount(Cell cell)
        {
            List<Cell> neighbours = cell.GetNeighbouringCells();

            return neighbours.Count(neighbour => _world.IsCellAlive(neighbour));
        }

        private bool DoesCellStayAlive(int aliveNeighbours)
        {
            return aliveNeighbours == CellSurvivesLowerCount ||
                   aliveNeighbours == CellSurvivesUpperCount;
        }

        private bool DoesCellComeToLife(int aliveNeighbours)
        {
            return aliveNeighbours == CellComesToLifeCount;
        }
    }
}