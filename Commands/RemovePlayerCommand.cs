using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Commands
{
    internal class RemovePlayerCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            if (GameSettingsViewModel.Instance.IsPlayer4Visible)
            {
                GameSettingsViewModel.Instance.IsPlayer4Visible = false;
            }
            else
            {
                GameSettingsViewModel.Instance.IsPlayer3Visible = false;
                GameSettingsViewModel.Instance.IsMinusButtonVisible = false;
                GameSettingsViewModel.Instance.AddRemoveText = "Add more players";
            }
        }

    }
}
