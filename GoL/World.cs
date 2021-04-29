
using System.Collections.Generic;

namespace GoL
{
    public class World
    {
        private readonly List<LivingCell> _livingCells = new List<LivingCell>();
        public bool IsWorldEmpty()
        {
            return _livingCells.Count == 0;
        }

        public void SetLivingCell(LivingCell livingCell)
        {
            _livingCells.Add(livingCell);
        }

        public bool IsCellAlive(LivingCell livingCell)
        {
            return _livingCells.Contains(livingCell);
        }
    }
}