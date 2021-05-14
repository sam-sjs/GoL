namespace GoL
{
    public class Display
    {
        private readonly IOutput _output;

        public Display(IOutput output)
        {
            _output = output;
        }

        public void Welcome()
        {
            _output.WriteLine(Messages.Welcome);
        }

        public void EnterHeight()
        {
            _output.WriteLine(Messages.EnterHeight);
        }

        public void EnterWidth()
        {
            _output.WriteLine(Messages.EnterWidth);
        }

        public void SetInitialState()
        {
            _output.WriteLine(Messages.SetInitialState);
        }

        public void World(World world)
        {
            _output.WriteLine(world.ToString());
        }
        
        public void InvalidInput()
        {
            _output.WriteLine(Messages.InvalidInput);
        }
    }
}