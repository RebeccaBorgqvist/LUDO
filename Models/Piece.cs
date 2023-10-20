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
        private int[] _coordinates;
        public int[] Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }
        public Piece(int[] coordinates)
        {
            _coordinates = coordinates;
        }
        public (int[], int[]) SimulatePieceMove()
        {
            return PieceMove(false);
        }
        public (int[], int[]) PieceMove(bool move = true)
        {
            int[] startCoordinates = { 10, 10 };
            int[] endCoordinates = { 40, 40 };
            return (startCoordinates, endCoordinates);
        }
    }
}
