using System;

namespace GoL.Game.GoLCursorNavigation
{
    public class WorldBounds
    {
        public WorldBounds(int maxCol, int maxRow)
        {
            MaxCol = maxCol;
            MaxRow = maxRow;
        }

        public int MaxCol { get; }
        public int MaxRow { get; }

        private bool Equals(WorldBounds other)
        {
            return MaxCol == other.MaxCol && MaxRow == other.MaxRow;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WorldBounds) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MaxCol, MaxRow);
        }
    }
}