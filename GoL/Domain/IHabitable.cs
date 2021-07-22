using GoL.Game.GoLDisplay;
using GoL.Output;

namespace GoL.Game.GoLWorld
{
    public interface IHabitable
    {
        public int Rows { get; }
        public int Columns { get; }
        public void SetLivingCellAtLocation(Location location);
        public void DisplayInFormation(IOutput output);
        public void AdvanceToNextGeneration();
    }
}