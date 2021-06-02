using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoL.Game.GoLCell;
using GoL.Game.GoLDisplay;

namespace GoL.Game.GoLWorld
{
    public class World : IInhabitable
    {
        public World(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            CellFormation = new Cell[Columns, Rows];
            FillWorldWithCells();
            AssociateCellsWithNeighbours();
        }

        public readonly Cell[,] CellFormation;
        public int Columns { get; }
        public int Rows { get; }

        private void FillWorldWithCells()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    CellFormation[column, row] = new Cell(false);
                }
            }
        }

        private void AssociateCellsWithNeighbours()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    int top = row > 0 ? row - 1 : Rows - 1;
                    int bottom = row < Rows - 1 ? row + 1 : 0;
                    int left = column > 0 ? column - 1 : Columns - 1;
                    int right = column < Columns - 1 ? column + 1 : 0;
                    CellFormation[column, row].Neighbours.Add(CellFormation[left, top]);
                    CellFormation[column, row].Neighbours.Add(CellFormation[column, top]);
                    CellFormation[column, row].Neighbours.Add(CellFormation[right, top]);
                    CellFormation[column, row].Neighbours.Add(CellFormation[left, row]);
                    CellFormation[column, row].Neighbours.Add(CellFormation[right, row]);
                    CellFormation[column, row].Neighbours.Add(CellFormation[left, bottom]);
                    CellFormation[column, row].Neighbours.Add(CellFormation[column, bottom]);
                    CellFormation[column, row].Neighbours.Add(CellFormation[right, bottom]);
                }
            }
        }

        public List<Cell> GetCurrentCellFormation()
        {
            return CellFormation.Cast<Cell>().ToList();
        }

        public void SetNewCellFormation(List<Cell> cellFormation)
        {
            int currentCol = 0;
            int currentRow = 0;
            foreach (Cell cell in cellFormation)
            {
                CellFormation[currentCol, currentRow] = cell;
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
            AssociateCellsWithNeighbours();
        }

        public void SetLivingCellAtLocation(Location location)
        {
            CellFormation[location.Column, location.Row].IsAlive = true;
        }

        public bool IsCellAliveAtLocation(Location location)
        {
            return CellFormation[location.Column, location.Row].IsAlive;
        }

        public override string ToString()
        {
            StringBuilder toDisplay = new StringBuilder(Rows * Columns + (Rows - 1));
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    toDisplay.Append(CellFormation[column, row]);
                }

                if (row < Rows - 1) toDisplay.Append('\n');
            }

            return toDisplay.ToString();
        }
    }
}