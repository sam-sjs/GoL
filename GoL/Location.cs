using System;

namespace GoL
{
    public class Location
    {
        public Location(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }
        public int XPosition { get; }
        public int YPosition { get; }

        protected bool Equals(Location other)
        {
            return XPosition == other.XPosition && YPosition == other.YPosition;
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
            return HashCode.Combine(XPosition, YPosition);
        }
    }
}