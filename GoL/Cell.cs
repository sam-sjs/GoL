using System.Collections.Generic;
using System.Linq;

namespace GoL
{
    public class Cell
    {
        private List<Cell> _neighbours = new List<Cell>();

        public Cell(Location location, bool isAlive)
        {
            Location = location;
            IsAlive = isAlive; // Consider if this needs to be set in constructor
        }

        public Location Location { get; }
        public bool IsAlive { get; set; }

        public void SetNeighbours(List<Cell> generationOfCells) // Parameter name not great.
        {
            List<Location> neighbours = Location.GetNeighbouringLocations(); // "neighbours" might be confusing
            _neighbours = generationOfCells.Where(cell => neighbours.Contains(cell.Location)).ToList();
        }

        public int GetLivingNeighboursCount()
        {
            return _neighbours.Count(cell => cell.IsAlive);
        }

        protected bool Equals(Cell other)
        {
            return Equals(Location, other.Location) && IsAlive == other.IsAlive;
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
            return (Location != null ? Location.GetHashCode() : 0);
        }
    }
}