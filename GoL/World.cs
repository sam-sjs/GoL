
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

        public void SetLivingCellAt(int x, int y)
        {
            LivingCells.Add(new Cell(x, y));
        }
    }
}