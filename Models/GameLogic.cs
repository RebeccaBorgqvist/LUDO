using LUDO.ViewModels;
using LUDO.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Threading;
using Windows.UI.Core;

namespace LUDO.Models
{
    internal class GameLogic
    {
        private int activePlayerIndex;
        private Player activePlayer;
        private List<Player> playerList;
        private int playerToStart;
        private static Color player1Color;
        private static Color player2Color;
        private static Color player3Color;
        private static Color player4Color;

        public GameLogic()
        {
            activePlayerIndex = 0;
            playerList = new List<Player>();
        }

        public void SetPlayerList()
        {
            // Gets participating players from game settings view model.
            foreach (Player player in GameSettingsViewModel.Instance.PlayerList)
            {
                playerList.Add(player);
            }

            // Orders list by color Blue > Red > Green > Yellow.
            // Sets active player randomly.
            playerList = playerList.OrderBy(player => player.Color).ToList();
            activePlayerIndex = new Random().Next(0, playerList.Count());
            activePlayer = playerList[activePlayerIndex];
        }

        public void CreatePlayerPieces()
        {
            foreach (Player player in playerList)
            {
                player.CreatePieces();
            }
        }

        //public void SetPlayerColor()
        //{
        //    if (GameSettingsViewModel.Instance.Red1) player1Color = Color.Red;
        //    if (GameSettingsViewModel.Instance.Green1) player1Color = Color.Green;
        //    if (GameSettingsViewModel.Instance.Yellow1) player1Color = Color.Yellow;
        //    if (GameSettingsViewModel.Instance.Blue1) player1Color = Color.Blue;

        //    if (GameSettingsViewModel.Instance.Red2) player2Color = Color.Red;
        //    if (GameSettingsViewModel.Instance.Green2) player2Color = Color.Green;
        //    if (GameSettingsViewModel.Instance.Yellow2) player2Color = Color.Yellow;
        //    if (GameSettingsViewModel.Instance.Blue2) player2Color = Color.Blue;

        //    if (GameSettingsViewModel.Instance.Red3) player3Color = Color.Red;
        //    if (GameSettingsViewModel.Instance.Green3) player3Color = Color.Green;
        //    if (GameSettingsViewModel.Instance.Yellow3) player3Color = Color.Yellow;
        //    if (GameSettingsViewModel.Instance.Blue3) player3Color = Color.Blue;

        //    if (GameSettingsViewModel.Instance.Red4) player4Color = Color.Red;
        //    if (GameSettingsViewModel.Instance.Green4) player4Color = Color.Green;
        //    if (GameSettingsViewModel.Instance.Yellow4) player4Color = Color.Yellow;
        //    if (GameSettingsViewModel.Instance.Blue4) player4Color = Color.Blue;
        //}
        //public void CreatePlayerOrder()
        //{
        //    if (GameSettingsViewModel.Instance.Players == 3)
        //    {
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player1Name, player1Color));
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player2Name, player2Color));
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player3Name, player3Color));
        //    }
        //    if (GameSettingsViewModel.Instance.Players == 4)
        //    {
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player1Name, player1Color));
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player2Name, player2Color));
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player3Name, player3Color));
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player4Name, player4Color));
        //    }
        //    else
        //    {
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player1Name, player1Color));
        //        players.Add(new Player(GameSettingsViewModel.Instance.Player2Name, player2Color));
        //    }

        //    List<Player> playersSortedByColor = players.OrderBy(player => player.ColorInt).ToList();
        //    playerToStart = new Random().Next(0, GameSettingsViewModel.Instance.Players - 1);
        //    playersSortedByColor[playerToStart].IsTurnToRoll = true;
        //    List<Player> playersBeforeNewStart = playersSortedByColor.Take(playerToStart).ToList();
        //    List<Player> playersAfterNewStart = playersSortedByColor.Skip(playerToStart).ToList();
        //    playersRandomized = playersAfterNewStart.Concat(playersBeforeNewStart).ToList();
        //}

        public void StartGame()
        {
            ShowActivePlayerMessage();

            //bool endTheGame = false; // set TRUE only if all 4 pieces of a player reached the finish
            //while (!endTheGame)
            //{
            //    foreach (Player player in playersRandomized) //loop according to the player order
            //    {

            //        //Pausa och vänta på att spelare klickar på tärningen
            //        int heltal = GameBoardViewModel.Instance.DiceResult;//throw the dice and return the result, say 0
            //        foreach (Piece piece in player.Pieces)
            //        {
            //            int xNuvarande = piece.CoordinateX;
            //            int yNuvarande = piece.CoordinateY;
            //            var (newCoordinateInX, newCoordinateInY) = piece.SimulatePieceMove(heltal);
            //            GameBoardViewModel.Highlighting(xNuvarande, yNuvarande, newCoordinateInX, newCoordinateInY);
            //            //Pause todo
            //        }

            //        // Dice.Instance.DiceRollEvent.Reset();
            //        //show me which options I have
            //        //take decision
            //        endTheGame = true; //for testing 
            //        break; //for testing
            //        //player.Pieces[0].PieceMove(heltal); //move according to decision
            //    }
            //    //check if all players finished and if so change bool
            //}
        }

        public void PlayerTurn()
        {
            /*
             * 
             * < CODE FOR PLAYER TURN >
             * 
            */
            
            SetNextPlayer();
        }

        private void SetNextPlayer()
        {
            // If active player is the last player in list, set active player to first player in list.
            // Else set active player to next player in list.
            if (activePlayer == playerList[playerList.Count - 1])
            {
                activePlayerIndex = 0;
                activePlayer = playerList[activePlayerIndex];
            }
            else
            {
                activePlayerIndex++;
                activePlayer = playerList[activePlayerIndex];
            }

            ShowActivePlayerMessage();
        }

        private void ShowActivePlayerMessage()
        {
            var dialog = new MessageDialog($"▶ {activePlayer.Name}'s Turn!");
            dialog.Title = "PLAYER TURN";
            dialog.Commands.Clear();
            dialog.Commands.Add(new UICommand("OK"));
            Task.Run(() => dialog.ShowAsync()).GetAwaiter();
        }
    }
}
