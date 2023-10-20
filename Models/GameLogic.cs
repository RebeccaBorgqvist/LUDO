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
        }
        public void StartGame()
        {
            bool endTheGame = false; // set TRUE only if all 4 pieces of a player reached the finish
            while (!endTheGame)
            {

                foreach (Player player in playersRandomized) //loop according to the player order
                {
                    //Pausa och vänta på att spelare klickar på tärningen
                    int heltal = GameBoardViewModel.Instance.DiceResult;//throw the dice and return the result, say 0
                    foreach (Piece piece in player.Pieces)
                    {
                        int xNuvarande = piece.CoordinateX;
                        int yNuvarande = piece.CoordinateY;
                        var (newCoordinateInX, newCoordinateInY) = piece.SimulatePieceMove(heltal);
                        GameBoardViewModel.Highlighting(xNuvarande, yNuvarande, newCoordinateInX, newCoordinateInY);
                        //Pause todo
                    }
                    //show me which options I have
                    //take decision
                    endTheGame = true; //for testing 
                    break; //for testing
                    //player.Pieces[0].PieceMove(heltal); //move according to decision
                }
                //check if all players finished and if so change bool
            }
        }
    }
}
