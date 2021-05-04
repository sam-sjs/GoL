using System;
using System.Collections.Generic;
using System.Linq;

namespace GoL
{
    public class Cell
    {
        private const int PositiveAdjustment = 1;
        private const int NoAdjustment = 0;
        private const int NegativeAdjustment = -1;

        public Cell(int x, int y, bool isAlive)
        {
            XPosition = x;
            YPosition = y;
            IsAlive = isAlive;
        }

        public int XPosition { get; }
        public int YPosition { get; }
        public bool IsAlive { get; } // Should this be in the equality operation?

        public int GetAliveNeighboursCount()
        {
            List<Cell> neighbours = GetNeighbouringCells();
            return neighbours.Count(neighbour => neighbour.IsAlive);
        }
        
        private List<Cell> GetNeighbouringCells()
        {
            List<Cell> neighbours = new List<Cell>
            {
                new Cell(XPosition + NegativeAdjustment, YPosition + NegativeAdjustment, true),
                new Cell(XPosition + NoAdjustment, YPosition + NegativeAdjustment, true),
                new Cell(XPosition + PositiveAdjustment, YPosition + NegativeAdjustment, true),
                new Cell(XPosition + NegativeAdjustment, YPosition + NoAdjustment, true),
                new Cell(XPosition + PositiveAdjustment, YPosition + NoAdjustment, true),
                new Cell(XPosition + NegativeAdjustment, YPosition + PositiveAdjustment, true),
                new Cell(XPosition + NoAdjustment, YPosition + PositiveAdjustment, true),
                new Cell(XPosition + PositiveAdjustment, YPosition + PositiveAdjustment, true)
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