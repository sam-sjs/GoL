using System.Collections.Generic;

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
            int aliveNeighbours = 0;
            List<Location> neighbours = location.GetNeighbouringLocations();
            foreach (Location neighbour in neighbours)
            {
                if (_world.IsCellAliveAt(neighbour)) aliveNeighbours++;
            }

            return aliveNeighbours;
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