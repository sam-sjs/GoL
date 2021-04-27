namespace GoL
{
    public class Cell
    {
        public Cell(int x, int y)
        {
            Xpos = x;
            Ypos = y;
        }
        public int Xpos { get; }
        public int Ypos { get; }
        public bool IsAlive { get; set; } = true;
    }
}