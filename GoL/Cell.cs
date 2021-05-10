
using System.Collections.Generic;

namespace GoL
{
    public class Cell
    {
        public Cell(bool isAlive)
        {
            IsAlive = isAlive; 
        }

        public bool IsAlive { get; }
        public readonly List<Cell> Neighbours = new List<Cell>();

        public int GetLivingNeighboursCount() // TODO: Rebuld this method when have concept of neighbours again
        {
            return 0;
        }
        
        protected bool Equals(Cell other)
        {
            return IsAlive == other.IsAlive;
            
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode()
        {
            return IsAlive.GetHashCode();
        }
    }
}