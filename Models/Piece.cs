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
        private TypeOfLocation typeOfPiece;
        private string section; 
        

        public TypeOfLocation TypeOfLocation { get; set; }
        public string Section { get; set; }

        public Piece(TypeOfLocation typeOfPiece, string section)
        { 
            TypeOfLocation = typeOfPiece;
            Section = section;
        }
    }
}
