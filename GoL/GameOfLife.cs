using System.Collections.Generic;

namespace GoL
{
    public class GameOfLife
    {
        private readonly World _world;
        public GameOfLife(World world)
        {
            _world = world;
        }
        public void SetInitialWorldState(List<Cell> initialState)
        {
            _world.CurrentGeneration = initialState;
        }
    }
}