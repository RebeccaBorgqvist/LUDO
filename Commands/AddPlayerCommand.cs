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
            else if (GameSettingsViewModel.Instance.IsPlayer4Visible) 
            {
                GameSettingsViewModel.Instance.IsPlusButtonVisible = false;
            }
            else
            {
                GameSettingsViewModel.Instance.IsPlayer3Visible = true;
                GameSettingsViewModel.Instance.IsMinusButtonVisible = true;
                GameSettingsViewModel.Instance.AddRemoveText = "Remove or add players";
            }
        }
    }

    // Skapa detta för varje färg och sen via Namegroup jämföra Player1 och andra players och beroende på färg  villkora och if sats
}
