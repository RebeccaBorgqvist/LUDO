using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    /// <summary>
    /// The class that just holds the list of the cells. The game board consists of those cells
    /// </summary>
    internal class Board
    {
        
        private List<Cell> _gameCells;        

        public List<Cell> GameCells 
        {
            get { return _gameCells; }
            set { _gameCells = value; } 
        }

        public Board()
        {
            _gameCells = new List<Cell>();
        }
    }
}
