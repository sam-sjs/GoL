using System;
using System.Collections.Generic;

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

        public List<Location> GetNeighbours(Location location)
        {
            List<Location> neighbours = new List<Location>();
            neighbours.Add(new Location(location.XPosition - 1, location.YPosition - 1));
            neighbours.Add(new Location(location.XPosition - 0, location.YPosition - 1));
            neighbours.Add(new Location(location.XPosition + 1, location.YPosition - 1));
            neighbours.Add(new Location(location.XPosition - 1, location.YPosition - 0));
            neighbours.Add(new Location(location.XPosition + 1, location.YPosition - 0));
            neighbours.Add(new Location(location.XPosition - 1, location.YPosition + 1));
            neighbours.Add(new Location(location.XPosition - 0, location.YPosition + 1));
            neighbours.Add(new Location(location.XPosition + 1, location.YPosition + 1));
            return neighbours;
        }

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

        public static bool operator ==(Location left, Location right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !Equals(left, right);
        }
    }
}