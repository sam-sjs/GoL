using System.Collections.Generic;

namespace GoL
{
    public interface IInhabitable
    {
        public List<Cell> GetCurrentCellFormation();
        public void SetLivingCellAtLocation(Location location);
        public void SetNewCellFormation(List<Cell> formation);
        public string ToString();
    }
}