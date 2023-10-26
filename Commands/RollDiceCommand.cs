using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using LUDO.Models;
using System.Threading;

namespace LUDO.Commands
{
    /// <summary>
    /// The command-class that shows the dice and how much it´s been rolled
    /// </summary>
    internal class RollDiceCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            if (Dice.Instance != null)
            {
                var (rollResult, imagePath) = Dice.Instance.DiceRoll();
                GameBoardViewModel.Instance.CurrentDiceImage = imagePath;
                GameBoardViewModel.Instance.DiceResult = rollResult;
                GameBoardViewModel.Instance.IsDiceEnabled = false;

                bool possibleMove = false;
                foreach (Piece piece in GameLogic.Instance.activePlayer.Pieces)
                {
                    if (piece.SimulatePieceMove(rollResult))
                    {
                        possibleMove = true;
                    }
                }

                if (!possibleMove)
                {
                    var dialog = new MessageDialog($"▶ NO VALID MOVE FOR DICE ROLL: {rollResult}");
                    dialog.Title = "NO VALID MOVE";
                    dialog.Commands.Clear();
                    dialog.Commands.Add(new UICommand("OK", new UICommandInvokedHandler(NextTurn)));
                    Task.Run(() => dialog.ShowAsync()).GetAwaiter();
                }
            }
        }

        /// <summary>
        /// The method switches onto the next on turn player to roll the dice 
        /// </summary>
        /// <param name="command"></param>
        private void NextTurn(IUICommand command)
        {
            GameLogic.Instance.SetNextPlayer();
            GameBoardViewModel.Instance.IsDiceEnabled = true;
            GameBoardViewModel.Instance.IsSimulateMoveButtonVisible = false;
        }
    }
}
