namespace GoL
{
    public class GameEngine
    {
        private readonly Display _display;
        private readonly Generation _generation;
        private readonly World _world;

        public GameEngine(Display display, Generation generation)
        {
            _display = display;
            _generation = generation;
        }
    }
}