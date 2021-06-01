using System.Collections.Generic;
using System.Linq;

namespace GoL.Game.GoLCell
{
    public class Cell
    {
        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public bool IsAlive { get; set; }
        public readonly List<Cell> Neighbours = new List<Cell>();

        public int GetLivingNeighboursCount()
        {
            return Neighbours.Count(cell => cell.IsAlive);
        }

        public override string ToString() // This should maybe be handled in the console output
        {
            return IsAlive ? "██" : "..";
        }
    }
}