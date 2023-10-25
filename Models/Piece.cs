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
        private int[] _coordinates;
        private Helpers.Color _pieceColor;
        private int _id;
        private Cell _atCell;
        private int colorInt;
        public int[] Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }
        public Helpers.Color PieceColor { get { return _pieceColor; } }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Cell AtCell
        {
            get { return _atCell; }
            set { _atCell = value; }
        }

        public Piece(Color playerColor, int id = 0, int colorInt = 0)
        {
            _pieceColor = playerColor;
            _id = id;
            this.SetStartingCoordinates();
            this.colorInt = colorInt;
        }

        public void SetStartingCoordinates()
        {
            if (this.PieceColor == Color.Red) 
            {
                switch (this.Id)
                {
                    case 1:
                        GameBoardViewModel.Instance.BoardModel.GameCells[19].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[19].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[19];
                        break;
                    case 2:
                        GameBoardViewModel.Instance.BoardModel.GameCells[20].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[20].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[20];
                        break;
                    case 3:
                        GameBoardViewModel.Instance.BoardModel.GameCells[21].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[21].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[21];
                        break;
                    case 4:
                        GameBoardViewModel.Instance.BoardModel.GameCells[22].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[22].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[22];
                        break;
                }
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Red, true, this.Id, this.Coordinates);
            }
            else if (this.PieceColor == Color.Green) 
            {
                switch (this.Id)
                {
                    case 1:
                        GameBoardViewModel.Instance.BoardModel.GameCells[42].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[42].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[42];
                        break;
                    case 2:
                        GameBoardViewModel.Instance.BoardModel.GameCells[43].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[43].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[43];
                        break;
                    case 3:
                        GameBoardViewModel.Instance.BoardModel.GameCells[44].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[44].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[44];
                        break;
                    case 4:
                        GameBoardViewModel.Instance.BoardModel.GameCells[45].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[45].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[45];
                        break;
                }
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Green, true, this.Id, this.Coordinates);
            }
            else if (this.PieceColor == Color.Yellow)
            {
                switch (this.Id)
                {
                    case 1:
                        GameBoardViewModel.Instance.BoardModel.GameCells[65].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[65].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[65];
                        break;
                    case 2:
                        GameBoardViewModel.Instance.BoardModel.GameCells[66].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[66].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[66];
                        break;
                    case 3:
                        GameBoardViewModel.Instance.BoardModel.GameCells[67].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[67].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[67];
                        break;
                    case 4:
                        GameBoardViewModel.Instance.BoardModel.GameCells[68].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[68].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[68];
                        break;
                }
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Yellow, true, this.Id, this.Coordinates);
            }
            else
            {
                switch (this.Id)
                {
                    case 1:
                        GameBoardViewModel.Instance.BoardModel.GameCells[88].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[88].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[88];
                        break;
                    case 2:
                        GameBoardViewModel.Instance.BoardModel.GameCells[89].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[89].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[89];
                        break;
                    case 3:
                        GameBoardViewModel.Instance.BoardModel.GameCells[90].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[90].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[90];
                        break;
                    case 4:
                        GameBoardViewModel.Instance.BoardModel.GameCells[91].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[91].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[91];
                        break;
                }
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Blue, true, this.Id, this.Coordinates);
            }
        }
        public int[] SimulatePieceMove(int diceResult)
        {
            return PieceMove(diceResult, true);
        }
        public int[] PieceMove(int diceResult, bool onlySimulateMove = false)
        {
            int newId = diceResult + this.AtCell.Id;
            int newSection = this.AtCell.Section;
            bool newFinal = this.AtCell.IsFinal;
            bool moveLegit = true;

            if (this.AtCell.IsFinal && newId > 5) //Finalizing
            {
                newId = 6;
            }
            else if (newId > 7 && this.AtCell.Id < 8 && this.colorInt == this.AtCell.Section) //Enter final area
            {
                newFinal = true;
                newId = newId - 7;
            }
            else if (newId > 13) //Enter next section
            {
                newId = newId - 13;
                if (this.AtCell.Section > 2) newSection = 0;
                else newSection = this.AtCell.Section + 1;
            }
            else if (this.AtCell.Id < 0 && diceResult == 6) //Move out from nest
            {
                newId = 9;
            }
            else if (this.AtCell.Id < 0 && diceResult != 6) //Trying to move out from nest
            {
                return this.Coordinates;
            }

            foreach (Cell cell in GameBoardViewModel.Instance.BoardModel.GameCells) //Check if move is legit and update piece with new position
            {
                if (cell.Section == newSection && cell.Id == newId && cell.IsFinal == newFinal)
                {
                    bool shareCell = false;
                    if (cell.PiecesVisiting.Count > 0 && cell.PiecesVisiting[0].PieceColor != this.PieceColor)
                    {
                        this.CrashWithOtherPieces(cell); //Crash with other pieces of different color
                        moveLegit = true;
                    }
                    else if (cell.PiecesVisiting.Count > 0) 
                    {
                        //Share cell with own other piece
                        shareCell = true;
                        moveLegit = true;
                    }
                    else //Not occupied cell
                    {
                        moveLegit = true;
                    }

                    if (moveLegit && !onlySimulateMove)
                    {
                        this.RemoveOldPosition();
                        this.AtCell = cell;
                        cell.PiecesVisiting.Add(this);
                        GameBoardViewModel.Instance.ShowPieceOnBoard(this.PieceColor, true, this.Id, this.AtCell.Coordinates, shareCell);
                    }
                    else if (moveLegit && onlySimulateMove)
                    {
                        return cell.Coordinates;
                    }
                }
            }
            return this.Coordinates; //Returns the original coordinates if move not legit (for the simulation)
        }
        public void RemoveOldPosition()
        {
            foreach (Cell cell in GameBoardViewModel.Instance.BoardModel.GameCells)
            {
                if (cell.Section == this.AtCell.Section && cell.Id == this.AtCell.Id && cell.IsFinal == this.AtCell.IsFinal)
                {
                    cell.PiecesVisiting.RemoveAt(0);
                }
            }
        }
        public void CrashWithOtherPieces(Cell cellAtCrash)
        {
            foreach (Piece knockedPiece in cellAtCrash.PiecesVisiting)
            {
                knockedPiece.SetStartingCoordinates();
            }
            cellAtCrash.PiecesVisiting.Clear();
        }
    }
}
