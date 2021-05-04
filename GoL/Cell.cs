using System;

namespace GoL
{
    public class Cell
    {

        public Cell(Location location, bool isAlive)
        {
            Location = location;
            IsAlive = isAlive;
        }

        public Location Location { get; }
        public bool IsAlive { get; }

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
            return HashCode.Combine(Location, IsAlive);
        }

        public static bool operator ==(Cell left, Cell right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Cell left, Cell right)
        {
            return !Equals(left, right);
        }
    }
}