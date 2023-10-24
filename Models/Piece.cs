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

        public Piece(Color playerColor, int id)
        {
            _pieceColor = playerColor;
            _id = id;
            this.SetStartingCoordinates();
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
            return PieceMove(diceResult, false);
        }
        public int[] PieceMove(int diceResult, bool move = true)
        {
            int currentSection = this.AtCell.Section;
            int currentId = this.AtCell.Id;
            bool currentFinal = this.AtCell.IsFinal;
            int newId = diceResult + currentId;
            int newSection = currentSection;
            if (newId > 13)
            {
                newId = newId % 13;
                if (currentSection > 3) newSection = 0;
                else newSection = currentSection + 1;
            }

            foreach(Cell cell in GameBoardViewModel.Instance.BoardModel.GameCells) //update piece- and cell-object correlation according to new move.
            {
                if (cell.Section == newSection && cell.Id == newId)
                {
                    if (cell.PiecesVisiting.Count > 0) 
                    {
                        //Todo. Crash with other piece
                    }
                    else
                    {
                        this.AtCell = cell;
                        cell.PiecesVisiting.Add(this);
                    }
                }
                if (cell.Section == currentSection && cell.Id == currentId)
                {
                    if (cell.PiecesVisiting.Count > 1)
                    {
                        //Todo. remove the correct one
                    }
                    else
                    {
                        cell.PiecesVisiting.Clear();
                    }
                }
            }

            int randomIntCell = new Random().Next(0,15);
            int[] randomCellCoordinate = GameBoardViewModel.Instance.BoardModel.GameCells[randomIntCell].Coordinates;

            if (move)
            {
                if (diceResult == 0) //this is only for testing
                {
                    if (this.PieceColor == Color.Red)
                    {
                        GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Red, true, this.Id ,this.Coordinates);
                    }
                    else if (this.PieceColor == Color.Green)
                    {
                        GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Green, true, this.Id, this.Coordinates);
                    }
                    else if (this.PieceColor == Color.Yellow)
                    {
                        GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Yellow, true, this.Id, this.Coordinates);
                    }
                    else
                    {
                        GameBoardViewModel.Instance.ShowPieceOnBoard(Color.Blue, true, this.Id, this.Coordinates);
                    }
                }
            }
            return randomCellCoordinate;
        }
    }
}
