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

        public Piece(Color playerColor, int id, int colorInt)
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
                        GameBoardViewModel.Instance.BoardModel.GameCells[0].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[0].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[0];
                        break;
                    case 2:
                        GameBoardViewModel.Instance.BoardModel.GameCells[1].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[1].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[1];
                        break;
                    case 3:
                        GameBoardViewModel.Instance.BoardModel.GameCells[2].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[2].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[2];
                        break;
                    case 4:
                        GameBoardViewModel.Instance.BoardModel.GameCells[3].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[3].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[3];
                        break;
                }
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Red, true, this.Id, this.Coordinates);
            }
            else if (this.PieceColor == Color.Green) 
            {
                switch (this.Id)
                {
                    case 1:
                        GameBoardViewModel.Instance.BoardModel.GameCells[4].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[4].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[4];
                        break;
                    case 2:
                        GameBoardViewModel.Instance.BoardModel.GameCells[5].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[5].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[5];
                        break;
                    case 3:
                        GameBoardViewModel.Instance.BoardModel.GameCells[6].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[6].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[6];
                        break;
                    case 4:
                        GameBoardViewModel.Instance.BoardModel.GameCells[7].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[7].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[7];
                        break;
                }
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Green, true, this.Id, this.Coordinates);
            }
            else if (this.PieceColor == Color.Yellow)
            {
                switch (this.Id)
                {
                    case 1:
                        GameBoardViewModel.Instance.BoardModel.GameCells[8].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[8].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[8];
                        break;
                    case 2:
                        GameBoardViewModel.Instance.BoardModel.GameCells[9].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[9].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[9];
                        break;
                    case 3:
                        GameBoardViewModel.Instance.BoardModel.GameCells[10].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[10].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[10];
                        break;
                    case 4:
                        GameBoardViewModel.Instance.BoardModel.GameCells[11].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[11].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[11];
                        break;
                }
                GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Yellow, true, this.Id, this.Coordinates);
            }
            else
            {
                switch (this.Id)
                {
                    case 1:
                        GameBoardViewModel.Instance.BoardModel.GameCells[12].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[12].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[12];
                        break;
                    case 2:
                        GameBoardViewModel.Instance.BoardModel.GameCells[13].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[13].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[13];
                        break;
                    case 3:
                        GameBoardViewModel.Instance.BoardModel.GameCells[14].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[14].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[14];
                        break;
                    case 4:
                        GameBoardViewModel.Instance.BoardModel.GameCells[15].PiecesVisiting.Add(this);
                        this.Coordinates = GameBoardViewModel.Instance.BoardModel.GameCells[15].Coordinates;
                        this.AtCell = GameBoardViewModel.Instance.BoardModel.GameCells[15];
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

            if (this.AtCell.IsFinal && newId > 5) //Finalizing
            {
                newId = 6;
            }
            else if (newId > 7 && this.colorInt == this.AtCell.Section) //Enter final area
            {
                newFinal = true;
                newId = newId - 7;
            }
            else if (newId > 13) //Enter next section
            {
                newId = newId - 13;
                if (this.AtCell.Section > 3) newSection = 0;
                else newSection = this.AtCell.Section + 1;
            }
            else if (this.AtCell.Id < 0 && diceResult == 6) //Move out from nest
            {
                newId = 9;
            }

            bool moveLegit = false;
            foreach (Cell cell in GameBoardViewModel.Instance.BoardModel.GameCells) //Check if move is legit and update piece with new position
            {
                if (cell.Section == newSection && cell.Id == newId && cell.IsFinal == newFinal)
                {
                    if (cell.PiecesVisiting.Count > 0 && cell.PiecesVisiting[0].PieceColor != this.PieceColor)
                    {
                        //Todo. Crash with other pieces of different color
                        moveLegit = true;
                    }
                    else if (cell.PiecesVisiting.Count > 0) 
                    {
                        //Todo. Share cell with own other piece
                        moveLegit = true;
                    }
                    else //not occupied
                    {
                        moveLegit = true;
                    }

                    if (moveLegit && !onlySimulateMove)
                    {
                        this.AtCell = cell;
                        cell.PiecesVisiting.Add(this);
                        GameBoardViewModel.Instance.ShowPieceOnBoard(this.PieceColor, true, this.Id, this.AtCell.Coordinates);
                    }
                    else if (moveLegit && onlySimulateMove)
                    {
                        return cell.Coordinates;
                    }
                }
            }
            if (moveLegit) //If move legit, remove old position.
            {
                foreach (Cell cell in GameBoardViewModel.Instance.BoardModel.GameCells) 
                {
                    if (cell.Section == newSection && cell.Id == newId && cell.IsFinal == newFinal)
                    {
                        cell.PiecesVisiting.RemoveAt(0);
                    }
                }
            }
            return this.Coordinates; //Returns the original coordinates if move not legit (for the simulation)
        }
    }
}
