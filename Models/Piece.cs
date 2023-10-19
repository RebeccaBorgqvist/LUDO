using LUDO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class Piece
    {
        public bool IsOnBoard { get; set; }
        public bool CanMove { get; set; }
        public Cell CurrentCell { get; set; }

        public void HighlightPiece()
        {
            
        }
    }
}
