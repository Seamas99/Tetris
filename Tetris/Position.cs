using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Position
    {
        private int row;
        private int column;
        public int Row 
        { 
            get { return row;  }
            set { Row = value; }
        }
        public int Column
        {
            get { return column; }
            set { Column = value; }
        }
        public Position(int row, int column) 
        {  
            Row = row;
            Column = column; 
        }
    }
}
