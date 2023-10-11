using System;
using LUDO.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LUDO.ViewModels.GameSettingsViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace LUDO.Commands
{
    internal class SelectColorCommand : BaseCommands
    {
        public override void Execute(object parameter)
         {
             
             /*if (GameSettingsViewModel.Instance.IsPlayer1BlueVisible)
             {
                 GameSettingsViewModel.Instance.IsPlayer1BlueVisible = true;
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
             }*/
         }
    }
        
}

