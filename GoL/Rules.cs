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
        public bool IsCellGoingToComeToLifeAt(LivingCell livingCell)
        {
            int aliveNeighbours = GetAliveNeighboursCount(livingCell);
            if (_world.IsCellAlive(livingCell))
            {
                return DoesCellStayAlive(aliveNeighbours);
            }

            return DoesCellComeToLife(aliveNeighbours);
        }

        private int GetAliveNeighboursCount(LivingCell livingCell)
        {
            List<LivingCell> neighbours = livingCell.GetNeighbouringLocations();

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