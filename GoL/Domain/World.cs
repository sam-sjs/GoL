using System.Collections.Generic;
using System.Linq;
using GoL.Game.GoLCell;
using GoL.Game.GoLDisplay;
using GoL.Game.GoLGeneration;
using GoL.Game.GoLRules;
using GoL.Output;

namespace GoL.Game.GoLWorld
{
    public class World : IHabitable
    {
        private readonly Generation _generation;
        public World(int columns, int rows)
        {
            IRenewable rules = new Rules();
            _generation = new Generation(rules);
            Columns = columns;
            Rows = rows;
            CellFormation = new Cell[Columns, Rows];
            FillWorldWithCells();
            AssociateCellsWithNeighbours();
        }

        public readonly Cell[,] CellFormation;
        public int Columns { get; }
        public int Rows { get; }

        public void SetLivingCellAtLocation(Location location)
        {
            CellFormation[location.Column, location.Row].IsAlive = true;
        }

        public void DisplayInFormation(IOutput output)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (CellFormation[column, row].IsAlive)
                    {
                        output.WriteLivingCell();
                    }
                    else
                    {
                        output.WriteDeadCell();
                    }
                }
                if(row < Rows - 1) output.WriteLine();
            }
        }

        public void AdvanceToNextGeneration()
        {
            List<Cell> currentGeneration = CellFormation.Cast<Cell>().ToList();
            List<Cell> newGeneration = _generation.BuildNextGeneration(currentGeneration);
            SetNewCellFormation(newGeneration);
        }

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
                    List<Cell> neighbours = new List<Cell>
                    {
                        CellFormation[left, top], CellFormation[column, top], CellFormation[right, top],
                        CellFormation[left, row], CellFormation[right, row], CellFormation[left, bottom],
                        CellFormation[column, bottom], CellFormation[right, bottom]
                    };
                    CellFormation[column, row].Neighbours.AddRange(neighbours);
                }
            }
        }

        private void SetNewCellFormation(List<Cell> cellFormation)
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
    }
}