using System.Threading;

namespace GoL
{
    public class GameEngine
    {
        private readonly Display _display;
        private readonly IInput _input;
        private readonly Generation _generation;
        private readonly World _world;

        public GameEngine(Display display, IInput input, Generation generation)
        {
            _display = display;
            _input = input;
            _generation = generation;
        }

        public void Start()
        {
            _display.Welcome();
        }
    }
}