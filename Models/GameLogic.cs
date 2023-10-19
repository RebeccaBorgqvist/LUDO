using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class GameLogic
    {
        private List<Player> _players;
        public GameLogic() { _players = new List<Player>(); }

        public void HighlightMovablePieceAndCells(Piece piece, int diceNumber) //Becca
        {
            // Highlight the Piece if it's on the board and able to move
            if (piece.IsOnBoard && piece.CanMove)
            {
                piece.HighlightPiece();

                // Get the target cells that are 'diceNumber' steps away
                List<Cell> targetCells = GetTargetCells(piece.CurrentCell, diceNumber);

                // Highlight each target cell
                foreach (Cell cell in targetCells)
                {
                    cell.HighlightCell();
                }
            }
        }
        private List<Cell> GetTargetCells(Cell currentCell, int diceNumber) //Becca
        {
            List<Cell> targetCells = new List<Cell>();
            // Logic to find the cells that are 'diceNumber' steps away from the current cell
            // Populate the targetCells list

            return targetCells;
        }
        public void StartGame()
        {
            Debug.WriteLine($"Players playing: {GameSettingsViewModel.Instance.Players}");

            Random rd = new Random();
            int playerToStart = rd.Next(0, GameSettingsViewModel.Instance.Players);

            //the players are to be added to the List 
            for (int player = 0; player < GameSettingsViewModel.Instance.Players; player++)
            {
                Player newPlayer = new Player("");

                if (player == 0) { newPlayer.Name = GameSettingsViewModel.Instance.Player1Name; }
                if (player == 1) { newPlayer.Name = GameSettingsViewModel.Instance.Player2Name; }
                if (player == 2) { newPlayer.Name = GameSettingsViewModel.Instance.Player3Name; }
                else if (player == 3) { newPlayer.Name = GameSettingsViewModel.Instance.Player4Name; }

                if (player == playerToStart) { newPlayer.IsTurnToRoll = true; }
                _players.Add(newPlayer);
            }
            bool endTheGame = false; // set TRUE only if all 4 pieces of a player reached the finish

            // MAIN GAME LOOP====================================================================================================================
            while (!endTheGame)
            {
                //A TEST LOOP JUST TO SEE HOW THE PLAYER´S TURN TO ROLL DICE IS CHANGING. later on - endTheGame once the finish is reached.
                for (int throww = 0; throww < 3; throww++)
                {
                    for (int playerOnTurn = 0; playerOnTurn < GameSettingsViewModel.Instance.Players; playerOnTurn++)
                    {
                        //TBD: do some magic stuff with pieces...
                        if (_players[playerOnTurn].IsTurnToRoll)
                        {
                            Debug.WriteLine($"{_players[playerOnTurn].Name}, your turn to roll dice!");
                            _players[playerOnTurn].IsTurnToRoll = false;

                            if (playerToStart + 1 < GameSettingsViewModel.Instance.Players) playerToStart++;
                            else if (playerToStart + 1 == GameSettingsViewModel.Instance.Players) playerToStart = 0;

                            _players[playerToStart].IsTurnToRoll = true;
                        }
                    }
                }
                endTheGame = true;
            }
            Debug.WriteLine("game over ladies and gentlemen");
        }
    }
}
