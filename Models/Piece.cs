using LUDO.Helpers;
using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class Piece
    {
        private int _coordinateX;
        private int _coordinateY;
        private Color _pieceColor;
        public static Piece Instance;

        public bool HighlightValidPiece { get; set; }
        public bool PieceInNest { get; set; }

        public Color PieceColor { get { return _pieceColor; } }
        public int CoordinateX
        {
            get { return _coordinateX; }
            set { _coordinateX = value; }
        }
        public int CoordinateY
        {
            get { return _coordinateY; }
            set { _coordinateY = value; }
        }

        public static bool IsHighlighted { get; internal set; }

        public Piece(Color playerColor)
        {
            _pieceColor = playerColor;
            this.SetStartingCoordinates();
        }

        public Piece()
        {
            Instance = this;
        }

        public void SetStartingCoordinates()
        {
            if (this._pieceColor == Color.Red) 
            {
                this._coordinateX = 400;
                this._coordinateY = 50;
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Red, this._coordinateX, this._coordinateY);
            }
            else if (this._pieceColor == Color.Green) 
            {
                this._coordinateX = 400;
                this._coordinateY = 400;
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Green, this._coordinateX, this._coordinateY);
            }
            else if (this._pieceColor == Color.Yellow)
            {
                this._coordinateX = 50;
                this._coordinateY = 400;
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Yellow, this._coordinateX, this._coordinateY);
            }
            else
            {
                this._coordinateX = 50;
                this._coordinateY = 50;
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Blue, this._coordinateX, this._coordinateY);
            }
        }

        // TBD: this is for highlighting a cell thats possible to move a valid piece to after throwing the dice
        public (int, int) SimulatePieceMove(int diceResult)
        {
            return PieceMove(diceResult, false);
        }

        public (int, int) PieceMove(int diceResult, bool move = true)
        {
            int testMoveInX = new Random().Next(30,200);
            int testMoveInY = new Random().Next(30, 200);
            if (move)
            {
                if (diceResult == 0) //this is only for testing
                {
                    this._coordinateX += testMoveInX;
                    this._coordinateY += testMoveInY;
                    if (this._pieceColor == Color.Red)
                    {
                        GameBoardViewModel.Instance.MovePieceOnBoard(Color.Red, this._coordinateX, this._coordinateY);
                    }
                    else if (this._pieceColor == Color.Green)
                    {
                        GameBoardViewModel.Instance.MovePieceOnBoard(Color.Green, this._coordinateX, this._coordinateY);
                    }
                    else if (this._pieceColor == Color.Yellow)
                    {
                        GameBoardViewModel.Instance.MovePieceOnBoard(Color.Yellow, this._coordinateX, this._coordinateY);
                    }
                    else
                    {
                        GameBoardViewModel.Instance.MovePieceOnBoard(Color.Blue, this._coordinateX, this._coordinateY);
                    }
                }
            }
            return (testMoveInX, testMoveInY);
        }
    }
}
