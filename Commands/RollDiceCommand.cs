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
    internal class RollDiceCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            if (Dice.Instance != null)
            {
                var (rollResult, imagePath) = Dice.Instance.DiceRoll();
                GameBoardViewModel.Instance.CurrentDiceImage = imagePath;
                GameBoardViewModel.Instance.DiceResult = rollResult;

                GameBoardViewModel.Instance.GameLogicModel.PlayerTurn();
            }
        }
    }
}
