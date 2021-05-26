
using System.Collections.Generic;
using System.Linq;

namespace GoL
{
    public class World
    {
        public World(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            CellFormation = new Cell[Rows, Columns];
        }

        // TODO Double check this array builds around the right way or at least that row/column are identified
        // correctly.  Out of alignment with x/y of display/worldlocation.
        public readonly Cell[,] CellFormation;
        public int Rows { get; }
        public int Columns { get; }

        public void Populate() // Consider putting this in the constructor once decided how to handle initial world setup.
        {
            FillWorldWithCells();
            AssociateCellsWithNeighbours();
        }

        public List<Cell> GetCurrentCellFormation()
        {
            return CellFormation.Cast<Cell>().ToList();
        }

        public void SetNewCellFormation(List<Cell> cellFormation)
        {
            int currentRow = 0;
            int currentCol = 0;
            foreach (Cell cell in cellFormation)
            {
                CellFormation[currentCol, currentRow] = cell; // Not super confident this is the correct way around.
                if (currentRow < Rows - 1)
                {
                    currentRow++;
                }
                else
                {
                    currentCol++;
                    currentRow = 0;
                }
            }
        }

        public void SetLivingCellAtLocation(Location location)
        {
            CellFormation[location.Row, location.Column].IsAlive = true;
        }

        public override string ToString()
        {
            string toDisplay = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    toDisplay += CellFormation[i, j];
                }

                if (i < Columns - 1) toDisplay += "\n";
            }

            return toDisplay;
        }

        private void FillWorldWithCells()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    CellFormation[i, j] = new Cell(false);
                }
            }
        }

        private void AssociateCellsWithNeighbours()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int top = i > 0 ? i - 1 : Rows - 1;
                    int bottom = i < Rows - 1 ? i + 1 : 0;
                    int left = j > 0 ? j - 1 : Columns - 1;
                    int right = j < Columns - 1 ? j + 1 : 0;
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