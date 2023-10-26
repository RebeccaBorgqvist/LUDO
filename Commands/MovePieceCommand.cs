using LUDO.Models;
using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Commands
{
    internal class MovePieceCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            GameLogic.Instance.activePlayer.SelectedPiece.PieceMove(GameBoardViewModel.Instance.DiceResult);
            GameLogic.Instance.SetNextPlayer();
            GameBoardViewModel.Instance.IsDiceEnabled = true;
            GameBoardViewModel.Instance.IsSimulateMoveButtonVisible = false;
        }
    }
}
