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
        public static GameLogic Instance { get; set; }

        private int activePlayerIndex;
        public Player activePlayer;
        public List<Player> playerList;

        public GameLogic()
        {
            Instance = this;
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

        public void StartGame()
        {
            ShowActivePlayerMessage();
            MoveDice(activePlayer);
        }

        public void PlayerTurn()
        {
            /*
             * 
             * < CODE FOR PLAYER TURN >
             * 
            */

            int diceResult = GameBoardViewModel.Instance.DiceResult;
            activePlayer.Pieces[0].PieceMove(diceResult);

            SetNextPlayer();
        }

        public void SetNextPlayer()
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
            MoveDice(activePlayer);
            GameBoardViewModel.Instance.ResetDiceImage();
        }

        private void ShowActivePlayerMessage()
        {
            var dialog = new MessageDialog($"▶ {activePlayer.Color} {activePlayer.Name}'s Turn!");
            dialog.Title = "PLAYER TURN";
            dialog.Commands.Clear();
            dialog.Commands.Add(new UICommand("OK"));
            Task.Run(() => dialog.ShowAsync()).GetAwaiter();
        }

        private void SetDiceVisibility(bool red, bool blue, bool green, bool yellow)
        {
            GameBoardViewModel.Instance.DiceVisibilityRed = red;
            GameBoardViewModel.Instance.DiceVisibilityBlue = blue;
            GameBoardViewModel.Instance.DiceVisibilityGreen = green;
            GameBoardViewModel.Instance.DiceVisibilityYellow = yellow;
        }

        public void MoveDice(Player player)
        {
            if (player.Color == Color.Red)
            {
                SetDiceVisibility(true, false, false, false);
            }
            else if (player.Color == Color.Blue)
            {
                SetDiceVisibility(false, true, false, false);
            }
            else if (player.Color == Color.Green)
            {
                SetDiceVisibility(false, false, true, false);
            }
            else if (player.Color == Color.Yellow)
            {
                SetDiceVisibility(false, false, false, true);
            }
            else
            {
                throw new InvalidOperationException($"Invalid player color: {player.Color}");
            }
        }
    }
}
