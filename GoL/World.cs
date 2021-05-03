using System.Collections.Generic;

namespace GoL
{
    public class World
    {
        private readonly List<Cell> _livingCells = new List<Cell>();

        public bool IsWorldEmpty()
        {
            return _livingCells.Count == 0;
        }

        public void SetLivingCell(Cell cell)
        {
            _livingCells.Add(cell);
        }

        public bool IsCellAlive(Cell cell)
        {
            return _livingCells.Contains(cell);
        }
    }
}