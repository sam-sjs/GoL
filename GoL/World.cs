
using System.Collections.Generic;

namespace GoL
{
    public class World
    {
        public List<Cell> LivingCells = new List<Cell>();
        public bool IsWorldEmpty()
        {
            return true;
        }

        public void SetLivingCellAt(Location location)
        {
            LivingCells.Add(new Cell(location));
        }
    }
}