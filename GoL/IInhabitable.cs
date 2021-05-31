using System.Collections.Generic;

namespace GoL
{
    public interface IInhabitable
    {
        public int Rows { get; }
        public int Columns { get; }
        public List<Cell> GetCurrentCellFormation();
        public void SetLivingCellAtLocation(Location location);
        public void SetNewCellFormation(List<Cell> formation);
    }
}