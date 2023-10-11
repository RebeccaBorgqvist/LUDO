using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Commands
{
    internal class AddPlayerCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            if (!GameSettingsViewModel.Instance.IsPlayer3Visible && !GameSettingsViewModel.Instance.IsPlayer4Visible)
            {
                GameSettingsViewModel.Instance.IsPlayer3Visible = true;
                GameSettingsViewModel.Instance.IsMinusButtonVisible = true;
                GameSettingsViewModel.Instance.AddRemoveText = "Remove or add players";
                GameSettingsViewModel.Instance.Players = 3;
            }
            else 
            {
                GameSettingsViewModel.Instance.IsPlayer4Visible = true;
                GameSettingsViewModel.Instance.IsPlusButtonVisible = false;
                GameSettingsViewModel.Instance.AddRemoveText = "Remove players";
                GameSettingsViewModel.Instance.Players = 4;
            }
        }
    }
}
