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
            if (GameSettingsViewModel.Instance.IsPlayer3Visible)
            {
                GameSettingsViewModel.Instance.IsPlayer4Visible = true;
            }
            else
            {
                GameSettingsViewModel.Instance.IsPlayer3Visible = true;
                GameSettingsViewModel.Instance.IsMinusButtonVisible = true;
            }
        }

    }
}
