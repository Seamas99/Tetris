using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Grid
    {
        private readonly int[,] grid;

        public int Rows { get; }
        public int Columns { get; }
        public int this[int rows, int columns]
        {
            get { return grid[rows, columns]; }
            set { grid[rows, columns] = value; }
        }

        public Grid(int rows, int columns) 
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int row, int column)
        {
            return ((row >= 0 && row < Rows) && (column >= 0 && column < Columns));
        }

        public bool IsEmpty(int row, int column)
        {
            return IsInside(row, column) && grid[row, column] == 0;
        }

        public bool IsRowFull(int row)
        {
            for (int column = 0; column < Columns; column++) 
            { 
                if (grid[row, column] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int row)
        {
            for (int column = 0; row < Columns; column++)
            {
                if (grid[row, column] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRowUtil(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                grid[row, column] = 0;
            }
        }

        private void MoveRowsUtil(int row, int numRowsCleared)
        {
            for (int column = 0; column< Columns; column++)
            {
                grid[row + numRowsCleared, column] = grid[row, column];
                grid[row, column] = 0;
            }
        }

        public int ClearRows()
        {
            int clearedRows = 0;
            for (int row = Rows-1; row >= 0; row--)
            {
                if(IsRowFull(row))
                {
                    ClearRowUtil(row);
                    clearedRows++;
                }
                else if(clearedRows > 0)
                {
                    MoveRowsUtil(row, clearedRows);
                }
            }
            return clearedRows;
        }
    }
}
