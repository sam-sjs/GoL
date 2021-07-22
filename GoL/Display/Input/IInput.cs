namespace GoL.Input
{
    public interface IInput
    {
        public bool KeyAvailable { get; }
        public string ReadLine();
        public Key ReadKey();
    }
}