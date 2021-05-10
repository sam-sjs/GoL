using System;
using System.Collections.Generic;

namespace GoL
{
    public class World
    {
        private readonly Generation _generation;

        public World(Generation generation)
        {
            _generation = generation;
        }
        public List<Cell> CurrentGeneration { get; private set; } = new List<Cell>();

        public bool IsWorldEmpty()
        {
            return CurrentGeneration.Count == 0;
        }

        public Cell[,] BuildWorld(int rows, int columns)
        {
            Cell[,] newWorld = CreateNewEmptyWorld(rows, columns);
            AssociateCellsWithNeighbours(newWorld);
            
            return newWorld;
        }

        private Cell[,] CreateNewEmptyWorld(int columns, int rows) // If world has dead cells, not really "empty"
        {
            Cell[,] newWorld = new Cell[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    newWorld[i, j] = new Cell(false);
                }
            }

            return newWorld;
        }

        private void AssociateCellsWithNeighbours(Cell[,] newWorld)
        {
            int columns = newWorld.GetLength(0);
            int rows = newWorld.GetLength(1);
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    int left = i > 0 ? i - 1 : columns - 1;
                    int right = i < columns - 1 ? i + 1 : 0;
                    int top = j > 0 ? j - 1 : rows - 1;
                    int bottom = j < rows - 1 ? j + 1 : 0;
                    newWorld[i, j].Neighbours.Add(newWorld[left, top]);
                    newWorld[i, j].Neighbours.Add(newWorld[i, top]);
                    newWorld[i, j].Neighbours.Add(newWorld[right, top]);
                    newWorld[i, j].Neighbours.Add(newWorld[left, j]);
                    newWorld[i, j].Neighbours.Add(newWorld[right, j]);
                    newWorld[i, j].Neighbours.Add(newWorld[left, bottom]);
                    newWorld[i, j].Neighbours.Add(newWorld[i, bottom]);
                    newWorld[i, j].Neighbours.Add(newWorld[right, bottom]);
                }
            }
        }
        
        public void SetInitialWorldState(List<Cell> initialState)
        {
            CurrentGeneration = initialState;
        }
        
        public void AdvanceToNextGeneration()
        {
            _generation.BuildNewGeneration(CurrentGeneration);
            CurrentGeneration = _generation.GetNewGeneration();
        }
    }
}