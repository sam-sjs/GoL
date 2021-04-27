namespace GoL
{
    public class Cell
    {
        public Cell(Location location)
        {
            Location = location;
        }
        public Location Location { get; }
        public bool IsAlive { get; set; } = true;
    }
}