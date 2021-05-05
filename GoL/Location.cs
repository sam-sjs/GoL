using System;
using System.Collections.Generic;

namespace GoL
{
    public class Location
    {
        private const int PositiveAdjustment = 1;
        private const int NoAdjustment = 0;
        private const int NegativeAdjustment = -1;
        private readonly int _xPosition;
        private readonly int _yPosition;
        

        public Location(int x, int y)
        {
            _xPosition = x;
            _yPosition = y;
        }
        
        public List<Location> GetNeighbouringLocations()  
        {
            List<Location> neighbours = new List<Location>
            {
                new Location(_xPosition + NegativeAdjustment, _yPosition + NegativeAdjustment),
                new Location(_xPosition + NoAdjustment, _yPosition + NegativeAdjustment),
                new Location(_xPosition + PositiveAdjustment, _yPosition + NegativeAdjustment),
                new Location(_xPosition + NegativeAdjustment, _yPosition + NoAdjustment),
                new Location(_xPosition + PositiveAdjustment, _yPosition + NoAdjustment),
                new Location(_xPosition + NegativeAdjustment, _yPosition + PositiveAdjustment),
                new Location(_xPosition + NoAdjustment, _yPosition + PositiveAdjustment),
                new Location(_xPosition + PositiveAdjustment, _yPosition + PositiveAdjustment)
            };
            return neighbours;
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