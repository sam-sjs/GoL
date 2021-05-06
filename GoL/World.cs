using System.Collections.Generic;

namespace GoL
{
    public class World
    {
        private readonly GameOfLife _game;

        public World(GameOfLife game)
        {
            _game = game;
        }
        public List<Cell> CurrentGeneration { get; set; } = new List<Cell>();

        public bool IsWorldEmpty()
        {
            return CurrentGeneration.Count == 0;
        }
        
        public void SetInitialWorldState(List<Cell> initialState)
        {
            CurrentGeneration = initialState;
        }
        
        public void AdvanceToNextGeneration()
        {
            _game.BuildNewGeneration(CurrentGeneration);
            CurrentGeneration = _game.GetNewGeneration();
        }
    }
}