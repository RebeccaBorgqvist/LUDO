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
        private List<Player> players;
        private List<Player> playersRandomized;
        private int playerToStart;
        private static Helpers.Color player1Color;
        private static Helpers.Color player2Color;
        private static Helpers.Color player3Color;
        private static Helpers.Color player4Color;

        public GameLogic()
        {
            players = new List<Player>();
        }
        public static void SetPlayerColor()
        {
            if (GameSettingsViewModel.Instance.Red1) player1Color = Helpers.Color.Red;
            if (GameSettingsViewModel.Instance.Green1) player1Color = Helpers.Color.Green;
            if (GameSettingsViewModel.Instance.Yellow1) player1Color = Helpers.Color.Yellow;
            if (GameSettingsViewModel.Instance.Blue1) player1Color = Helpers.Color.Blue;

            if (GameSettingsViewModel.Instance.Red2) player2Color = Helpers.Color.Red;
            if (GameSettingsViewModel.Instance.Green2) player2Color = Helpers.Color.Green;
            if (GameSettingsViewModel.Instance.Yellow2) player2Color = Helpers.Color.Yellow;
            if (GameSettingsViewModel.Instance.Blue2) player2Color = Helpers.Color.Blue;

            if (GameSettingsViewModel.Instance.Red3) player3Color = Helpers.Color.Red;
            if (GameSettingsViewModel.Instance.Green3) player3Color = Helpers.Color.Green;
            if (GameSettingsViewModel.Instance.Yellow3) player3Color = Helpers.Color.Yellow;
            if (GameSettingsViewModel.Instance.Blue3) player3Color = Helpers.Color.Blue;

            if (GameSettingsViewModel.Instance.Red4) player4Color = Helpers.Color.Red;
            if (GameSettingsViewModel.Instance.Green4) player4Color = Helpers.Color.Green;
            if (GameSettingsViewModel.Instance.Yellow4) player4Color = Helpers.Color.Yellow;
            if (GameSettingsViewModel.Instance.Blue4) player4Color = Helpers.Color.Blue;
        }
        public void CreatePlayerOrder()
        {
            if (GameSettingsViewModel.Instance.Players == 3)
            {
                players.Add(new Player(GameSettingsViewModel.Instance.Player1Name, player1Color));
                players.Add(new Player(GameSettingsViewModel.Instance.Player2Name, player2Color));
                players.Add(new Player(GameSettingsViewModel.Instance.Player3Name, player3Color));
            }
            if (GameSettingsViewModel.Instance.Players == 4)
            {
                players.Add(new Player(GameSettingsViewModel.Instance.Player1Name, player1Color));
                players.Add(new Player(GameSettingsViewModel.Instance.Player2Name, player2Color));
                players.Add(new Player(GameSettingsViewModel.Instance.Player3Name, player3Color));
                players.Add(new Player(GameSettingsViewModel.Instance.Player4Name, player4Color));
            }
            else
            {
                players.Add(new Player(GameSettingsViewModel.Instance.Player1Name, player1Color));
                players.Add(new Player(GameSettingsViewModel.Instance.Player2Name, player2Color));
            }

            List<Player> playersSortedByColor = players.OrderBy(player => player.ColorInt).ToList();
            playerToStart = new Random().Next(0, GameSettingsViewModel.Instance.Players - 1);
            playersSortedByColor[playerToStart].IsTurnToRoll = true;
            List<Player> playersBeforeNewStart = playersSortedByColor.Take(playerToStart).ToList();
            List<Player> playersAfterNewStart = playersSortedByColor.Skip(playerToStart).ToList();
            playersRandomized = playersAfterNewStart.Concat(playersBeforeNewStart).ToList();
            Debug.WriteLine($"{playersRandomized}");
        }
        public void StartGame()
        {
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

                        if (playersRandomized[playerOnTurn].IsTurnToRoll)
                        {
                            Debug.WriteLine($"{playersRandomized[playerOnTurn].Name}, your turn to roll dice!");
                            playersRandomized[playerOnTurn].IsTurnToRoll = false;

                            if (playerToStart + 1 < GameSettingsViewModel.Instance.Players) playerToStart++;
                            else if (playerToStart + 1 == GameSettingsViewModel.Instance.Players) playerToStart = 0;

                            playersRandomized[playerToStart].IsTurnToRoll = true;
                        }
                    }
                }
                endTheGame = true;
            }
            Debug.WriteLine("game over ladies and gentlemen");
        }
    }
}
