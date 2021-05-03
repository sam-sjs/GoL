using System;

namespace GoL
{
    public class Location
    {
        private readonly int _xPosition;
        private readonly int _yPosition;

        public Location(int x, int y)
        {
            _xPosition = x;
            _yPosition = y;
        }

        protected bool Equals(Location other)
        {
            return _xPosition == other._xPosition && _yPosition == other._yPosition;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_xPosition, _yPosition);
        }
    }
}