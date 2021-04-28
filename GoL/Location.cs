using System;
using System.Collections.Generic;

namespace GoL
{
    public class Location
    {
        private const int PositiveAdjustment = 1;
        private const int NoAdjustment = 0;
        private const int NegativeAdjustment = -1;
        public Location(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }
        public int XPosition { get; }
        public int YPosition { get; }
        
        // TODO: Assess whether this is the best way to get surrounding locations.
        public List<Location> GetNeighbouringLocations()
        {
            List<Location> neighbours = new List<Location>();
            neighbours.Add(new Location(XPosition + NegativeAdjustment, YPosition + NegativeAdjustment));
            neighbours.Add(new Location(XPosition + NoAdjustment, YPosition + NegativeAdjustment));
            neighbours.Add(new Location(XPosition + PositiveAdjustment, YPosition + NegativeAdjustment));
            neighbours.Add(new Location(XPosition + NegativeAdjustment, YPosition + NoAdjustment));
            neighbours.Add(new Location(XPosition + PositiveAdjustment, YPosition + NoAdjustment));
            neighbours.Add(new Location(XPosition + NegativeAdjustment, YPosition + PositiveAdjustment));
            neighbours.Add(new Location(XPosition + NoAdjustment, YPosition + PositiveAdjustment));
            neighbours.Add(new Location(XPosition + PositiveAdjustment, YPosition + PositiveAdjustment));
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