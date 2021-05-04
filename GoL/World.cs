using System.Collections.Generic;

namespace GoL
{
    public class World
    {
        public List<Cell> CurrentGeneration { get; private set; } = new List<Cell>();

        public bool IsWorldEmpty()
        {
            return CurrentGeneration.Count == 0;
        }

        public void UpdateCurrentGeneration(List<Cell> newGeneration)
        {
            CurrentGeneration = newGeneration;
        }
        
        // public int GetAliveNeighboursCount()
    }
}