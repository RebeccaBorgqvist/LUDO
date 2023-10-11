using LUDO.Models;
using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LUDO.ViewModels.GameSettingsViewModel;

namespace LUDO.Commands
{
    internal class ShowColorsCommand : BaseCommands
    {
         public override void Execute(object parameter)
         {
             if (GameSettingsViewModel.Instance.IsPlayer3Visible)
             {
                 GameSettingsViewModel.Instance.IsPlayer3ColorsVisible = true;
             }
             else if (GameSettingsViewModel.Instance.IsPlayer4Visible)
             {
                 GameSettingsViewModel.Instance.IsPlayer4ColorsVisible = true;
             }
             else
             {
                 GameSettingsViewModel.Instance.IsPlayer3Visible = false;
                 GameSettingsViewModel.Instance.IsPlayer4Visible = false;
                 GameSettingsViewModel.Instance.IsPlayer3ColorsVisible = false;
                 GameSettingsViewModel.Instance.IsPlayer4ColorsVisible = false;
             }
         }

    }
}
