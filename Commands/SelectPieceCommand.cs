using LUDO.Models;
using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace LUDO.Commands
{
    /// <summary>
    /// The command-class that is to select a piece (for its further moving)
    /// </summary>
    internal class SelectPieceCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            if (parameter is string piece)
            {
                // FÅ TAG PÅ RÄTT SPELARE -> LETA VIA FÄRG eller TA ACTIVE PLAYER
                // SÄTT RÄTT PJÄS ENLIGT PARAMETERN
                // SIMULERA PJÄS VAL

                int pieceID = int.Parse(piece.Substring(piece.Length - 1, 1)) - 1;

                GameBoardViewModel.Instance.IsSimulateMoveButtonVisible = true;
                GameLogic.Instance.activePlayer.SelectedPiece = GameLogic.Instance.activePlayer.Pieces[pieceID];
                GameLogic.Instance.activePlayer.SelectedPiece.SimulatePieceMove(GameBoardViewModel.Instance.DiceResult);
            }
        }

        //private Player FindPlayer(string color)
        //{
        //    string pieceColor = color.Substring(0, color.Length - 1);

        //    Enum.TryParse(pieceColor, out Helpers.Color selectedColor);

        //    foreach (Player player in GameLogic.Instance.playerList)
        //    {
        //        if (player.Color == selectedColor)
        //        {
        //            return player;
        //        }
        //    }
        //    return null;
        //}
    }
}
