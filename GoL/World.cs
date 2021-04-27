
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

        public void SetLivingCell()
        {
            LivingCells.Add(new Cell());
        }
    }
}