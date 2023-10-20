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
        private int[,] _coordinates;
        private Helpers.Color _pieceColor;
        public Helpers.Color PieceColor { get { return _pieceColor; } }
        public int[,] Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }

        public Piece(Helpers.Color playerColor)
        {
            _pieceColor = playerColor;
            this.SetStartingCoordinates();
        }

        public void SetStartingCoordinates()
        {
            if (this._pieceColor == Color.Red) 
            {
                this._coordinates = new int[10,10];
            }
            else if (this._pieceColor == Color.Green) 
            {
                this._coordinates = new int[30, 30];
            }
            else if (this._pieceColor == Color.Yellow)
            {
                this._coordinates = new int[50, 50];
            }
            else
            {
                this._coordinates = new int[70, 70];
            }
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
