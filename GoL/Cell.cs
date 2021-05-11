
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoL
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
    }
}