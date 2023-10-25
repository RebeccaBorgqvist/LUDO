using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace LUDO.Models
{
    internal class GameLogic
    {
        private List<Player> _players;

        public GameLogic()
        { 
            _players = new List<Player>();
        }

        public void StartGame()
        {
            Debug.WriteLine($"Players playing: {GameSettingsViewModel.Instance.Players}");

            // Orders list by color Blue > Red > Green > Yellow.
            // Sets active player randomly.
            playerList = playerList.OrderBy(player => player.Color).ToList();
            activePlayerIndex = new Random().Next(0, playerList.Count());
            activePlayer = playerList[activePlayerIndex];



            //front-end; sets labels of the players
            //player1Name.Text = "";

        }


            //the players are to be added to the List 
            for(int player = 0; player < GameSettingsViewModel.Instance.Players; player++) 
            {
                Player newPlayer = new Player("");

                if (player == 0)
                {
                    newPlayer.Name = GameSettingsViewModel.Instance.Player1Name;
                }

                if (player == 1)
                {
                    newPlayer.Name = GameSettingsViewModel.Instance.Player2Name;
                }

                if (player == 2)
                {
                    newPlayer.Name = GameSettingsViewModel.Instance.Player3Name;
                }
                else if (player == 3) 
                {
                    newPlayer.Name = GameSettingsViewModel.Instance.Player4Name;
                }



                if (player == playerToStart)
                {
                    newPlayer.IsTurnToRoll = true;
                } 

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
