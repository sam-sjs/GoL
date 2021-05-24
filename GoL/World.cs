
using System.Collections.Generic;
using System.Linq;

namespace GoL
{
    public class World
    {
        private readonly int _rows;
        private readonly int _columns;
        public World(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            CellFormation = new Cell[_rows, _columns];
        }

        // TODO Double check this array builds around the right way or at least that row/column are identified
        // correctly.  Out of alignment with x/y of display/worldlocation.
        public readonly Cell[,] CellFormation;

        public void Populate() // Consider putting this in the constructor once decided how to handle initial world setup.
        {
            FillWorldWithCells();
            AssociateCellsWithNeighbours();
        }

        public List<Cell> GetCellsInFormation()
        {
            return CellFormation.Cast<Cell>().ToList();
        }

        public void SetLivingCellAtLocation(Location location)
        {
            CellFormation[location.Row, location.Column].IsAlive = true;
        }

        public override string ToString()
        {
            string toDisplay = "";
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    toDisplay += CellFormation[i, j];
                }

                if (i < _columns - 1) toDisplay += "\n";
            }

            return toDisplay;
        }

        private void FillWorldWithCells()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    CellFormation[i, j] = new Cell(false);
                }
            }
        }

        private void AssociateCellsWithNeighbours()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    int top = i > 0 ? i - 1 : _rows - 1;
                    int bottom = i < _rows - 1 ? i + 1 : 0;
                    int left = j > 0 ? j - 1 : _columns - 1;
                    int right = j < _columns - 1 ? j + 1 : 0;
                    CellFormation[i, j].Neighbours.Add(CellFormation[top, left]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[top, j]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[top, right]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[i, left]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[i, right]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[bottom, left]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[bottom, j]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[bottom, right]);
                }
            }
        }
    }
}