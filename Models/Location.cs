using LUDO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class Location
    {
        private List<Piece> _piecesVisiting;
        private TypeOfLocation _typeOfLocation;
        private bool[] _locationRules;

        public List<Piece> PiecesVisiting 
        {  
            get { return _piecesVisiting; }
            set { _piecesVisiting = value; }
        }
        public TypeOfLocation TypeOfLocation
        {
            get { return _typeOfLocation; }
            set { _typeOfLocation = value; }
        }
        public bool[] LocationRules
        {
            get { return _locationRules; }
            set { _locationRules = value; }
        }

        public Location(List<Piece> pieces, TypeOfLocation type)
        {
            _piecesVisiting = pieces;
            _typeOfLocation = type;
        }
    }
}
