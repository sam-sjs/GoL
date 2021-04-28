
using System.Collections.Generic;

namespace GoL
{
    public class World
    {
        private readonly List<Cell> _livingCells = new List<Cell>();
        public bool IsWorldEmpty()
        {
            return true;
        }

        public void SetLivingCellAt(Location location)
        {
            _livingCells.Add(new Cell(location));
        }

        public bool IsCellAliveAt(Location location)
        {
            Cell cellAtLocation = _livingCells.Find(cell => cell.Location == location);
            return cellAtLocation is {IsAlive: true}; // is C# 7.0 pattern matching syntax ok, rider make me do it...
        }
    }
}