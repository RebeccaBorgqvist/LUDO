using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class Board
    {
        private List<Piece> gamePieces;


        public List<Piece> GamePieces { get; set; }
        public Board()
        { }

        public void AddPiece(Piece piece)
        { 
            gamePieces.Add(piece);
        }

    }
}
