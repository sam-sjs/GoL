using System.Collections.Generic;
using GoL.Game.GoLCell;
using GoL.Game.GoLDisplay;

namespace GoL.Game.GoLWorld
{
    public interface IInhabitable
    {
        public int Rows { get; }
        public int Columns { get; }
        public List<Cell> GetCurrentCellFormation();
        public bool[,] GetCurrentWorldState();
        public void SetLivingCellAtLocation(Location location);
        public void SetNewCellFormation(List<Cell> formation);
    }
}