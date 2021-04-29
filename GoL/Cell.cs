using System;
using System.Collections.Generic;

namespace GoL
{
    public class Cell
    {
        private const int PositiveAdjustment = 1;
        private const int NoAdjustment = 0;
        private const int NegativeAdjustment = -1;
        public Cell(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }
        public int XPosition { get; }
        public int YPosition { get; }
        
        // TODO: Assess whether this is the best way to get surrounding locations.
        public List<Cell> GetNeighbouringCells()
        {
            List<Cell> neighbours = new List<Cell>
            {
                new Cell(XPosition + NegativeAdjustment, YPosition + NegativeAdjustment),
                new Cell(XPosition + NoAdjustment, YPosition + NegativeAdjustment),
                new Cell(XPosition + PositiveAdjustment, YPosition + NegativeAdjustment),
                new Cell(XPosition + NegativeAdjustment, YPosition + NoAdjustment),
                new Cell(XPosition + PositiveAdjustment, YPosition + NoAdjustment),
                new Cell(XPosition + NegativeAdjustment, YPosition + PositiveAdjustment),
                new Cell(XPosition + NoAdjustment, YPosition + PositiveAdjustment),
                new Cell(XPosition + PositiveAdjustment, YPosition + PositiveAdjustment)
            };
            return neighbours;
        }

        protected bool Equals(Cell other)
        {
            return XPosition == other.XPosition && YPosition == other.YPosition;
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
            return HashCode.Combine(XPosition, YPosition);
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