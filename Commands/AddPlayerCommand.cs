using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Commands
{
    /// <summary>
    /// A class-command that adds players into the game (default: 2players; max players)
    /// </summary>
    internal class AddPlayerCommand : BaseCommands
    {
        /// <summary>
        /// An overridden function that takes one parameter and interact with "GameSettingsViewModel" class adding new players
        /// </summary>
        /// <param name="parameter"></param>

        public override void Execute(object parameter)
        {
            if (!GameSettingsViewModel.Instance.IsPlayer3Visible && !GameSettingsViewModel.Instance.IsPlayer4Visible)
            {
                GameSettingsViewModel.Instance.IsPlayer3Visible = true;
                GameSettingsViewModel.Instance.IsMinusButtonVisible = true;
                GameSettingsViewModel.Instance.AddRemoveText = "Remove or add players";
                GameSettingsViewModel.Instance.Players = 3;
                GameSettingsViewModel.Instance.PlayerList.Add(new Models.Player("Player 3"));
            }
            else 
            {
                GameSettingsViewModel.Instance.IsPlayer4Visible = true;
                GameSettingsViewModel.Instance.IsPlusButtonVisible = false;
                GameSettingsViewModel.Instance.AddRemoveText = "Remove players";
                GameSettingsViewModel.Instance.Players = 4;
                GameSettingsViewModel.Instance.PlayerList.Add(new Models.Player("Player 4"));
            }

            
        }
    }
}
