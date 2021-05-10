
namespace GoL
{
    public class World
    {
        private readonly int _columns;
        private readonly int _rows;
        public World(int columns, int rows)
        {
            _columns = columns;
            _rows = rows;
            CellFormation = new Cell[_columns, _rows];
        }

        public readonly Cell[,] CellFormation;

        public void Populate() // Consider putting this in the constructor once decided how to handle initial world setup.
        {
            FillWorldWithCells();
            AssociateCellsWithNeighbours();

        }

        private void FillWorldWithCells()
        {
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    CellFormation[i, j] = new Cell(false);
                }
            }
        }

        private void AssociateCellsWithNeighbours()
        {
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    int left = i > 0 ? i - 1 : _columns - 1;
                    int right = i < _columns - 1 ? i + 1 : 0;
                    int top = j > 0 ? j - 1 : _rows - 1;
                    int bottom = j < _rows - 1 ? j + 1 : 0;
                    CellFormation[i, j].Neighbours.Add(CellFormation[left, top]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[i, top]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[right, top]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[left, j]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[right, j]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[left, bottom]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[i, bottom]);
                    CellFormation[i, j].Neighbours.Add(CellFormation[right, bottom]);
                }
            }
        }
    }
}