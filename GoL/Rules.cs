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
        public bool IsCellGoingToComeToLifeAt(Location location)
        {
            int aliveNeighbours = GetAliveNeighboursCount(location);
            if (_world.IsCellAliveAt(location))
            {
                return DoesCellStayAlive(aliveNeighbours);
            }

            return DoesCellComeToLife(aliveNeighbours);
        }

        private int GetAliveNeighboursCount(Location location)
        {
            List<Location> neighbours = location.GetNeighbouringLocations();

            return neighbours.Count(neighbour => _world.IsCellAliveAt(neighbour));
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