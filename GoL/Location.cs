using System;

namespace GoL
{
    public class Location
    {
        public Location(int column, int row)
        {
            Column = column;
            Row = row;
        }
        
        public int Column { get; }
        public int Row { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            Location other = (Location) obj;
            return Column == other.Column && Row == other.Row;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Column, Row);
        }
    }
}