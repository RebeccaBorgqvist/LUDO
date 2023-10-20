using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class Board
    {
        private List<Cell> _gameCells;        

        public List<Cell> GameCells { get; set; }

        public Board()
        {
            _gameCells = new List<Cell>();
        }
    }
}
