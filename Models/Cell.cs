using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class Cell
    {
        private int section;
        private int id;
        private bool isFinal;
        private int[] coordinates;
        private List<Piece> _piecesVisiting;

        public int Section => section;
        public int Id => id;
        public bool IsFinal => isFinal;
        public int[] Coordinates => coordinates;
        public List<Piece> PiecesVisiting
        {
            get { return _piecesVisiting; }
            set { _piecesVisiting = value; }
        }
        public Cell(int section, int id, bool isFinal, int[] coordinates)
        { 
            this.section = section;
            this.id = id;
            this.isFinal = isFinal;
            this.coordinates = coordinates;
            _piecesVisiting = new List<Piece>();
        }
    }
}
