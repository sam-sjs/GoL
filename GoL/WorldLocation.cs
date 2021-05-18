using System;

namespace GoL
{
    public class WorldLocation
    {
        public WorldLocation(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }
        
        public int XPosition { get; }
        public int YPosition { get; }

        protected bool Equals(WorldLocation other)
        {
            return XPosition == other.XPosition && YPosition == other.YPosition;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WorldLocation) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(XPosition, YPosition);
        }
    }
}