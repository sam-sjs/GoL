using System;

namespace GoL
{
    public class WorldLocation // This sounds kind of like the location of the world not the location within the world
    {
        public WorldLocation(int column, int row)
        {
            Column = column;
            Row = row;
        }
        
        public int Column { get; }
        public int Row { get; }

        protected bool Equals(WorldLocation other)
        {
            return Column == other.Column && Row == other.Row;
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
            return HashCode.Combine(Column, Row);
        }
    }
}