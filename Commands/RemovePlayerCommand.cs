using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Commands
{
    /// <summary>
    /// The command-class that removes a player from the game 
    /// (when choosing how many players there are going to play this time)
    /// </summary>
    internal class RemovePlayerCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            if (GameSettingsViewModel.Instance.IsPlayer3Visible && GameSettingsViewModel.Instance.IsPlayer4Visible)
            {
                GameSettingsViewModel.Instance.IsPlayer4Visible = false;
                GameSettingsViewModel.Instance.IsPlusButtonVisible = true;
                GameSettingsViewModel.Instance.AddRemoveText = "Remove or add players";
                GameSettingsViewModel.Instance.Players = 3;
            }
            else
            {
                GameSettingsViewModel.Instance.IsPlayer3Visible = false;
                GameSettingsViewModel.Instance.IsMinusButtonVisible = false;
                GameSettingsViewModel.Instance.AddRemoveText = "Add more players";
                GameSettingsViewModel.Instance.Players = 2;
            }

            Models.Player lastPlayer = GameSettingsViewModel.Instance.PlayerList.Last();
            GameSettingsViewModel.Instance.PlayerList.Remove(lastPlayer);
        }
    }
}
