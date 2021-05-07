using System;
using System.Collections.Generic;

namespace GoL
{
    public class World
    {
        private readonly Generation _generation;

        public World(Generation generation)
        {
            _generation = generation;
        }
        public List<Cell> CurrentGeneration { get; private set; } = new List<Cell>();

        public bool IsWorldEmpty()
        {
            return CurrentGeneration.Count == 0;
        }

        public Location BuildWorld()
        {
            return null;
        }
        
        public void SetInitialWorldState(List<Cell> initialState)
        {
            CurrentGeneration = initialState;
        }
        
        public void AdvanceToNextGeneration()
        {
            _generation.BuildNewGeneration(CurrentGeneration);
            CurrentGeneration = _generation.GetNewGeneration();
        }
    }
}