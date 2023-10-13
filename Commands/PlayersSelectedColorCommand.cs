using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LUDO.ViewModels.GameSettingsViewModel;

namespace LUDO.Commands
{
    internal class PlayersSelectedColorCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            if (GameSettingsViewModel.Instance.Blue1 == true)
            {
                GameSettingsViewModel.Instance.Blue2 = false;
                GameSettingsViewModel.Instance.Blue3 = false;
                GameSettingsViewModel.Instance.Blue4 = false;
            }
            else if (GameSettingsViewModel.Instance.Blue2 == true)
            {
                GameSettingsViewModel.Instance.Blue1 = false;
                GameSettingsViewModel.Instance.Blue3 = false;
                GameSettingsViewModel.Instance.Blue4 = false;
            }
            else if (GameSettingsViewModel.Instance.Blue3 == true)
            {
                GameSettingsViewModel.Instance.Blue1 = false;
                GameSettingsViewModel.Instance.Blue2 = false;
                GameSettingsViewModel.Instance.Blue4 = false;
            }
            else if (GameSettingsViewModel.Instance.Blue4 == true)
            {
                GameSettingsViewModel.Instance.Blue1 = false;
                GameSettingsViewModel.Instance.Blue2 = false;
                GameSettingsViewModel.Instance.Blue3 = false;
            }
            else
            {
                GameSettingsViewModel.Instance.Blue1 = true;
                GameSettingsViewModel.Instance.Blue2 = true;
                GameSettingsViewModel.Instance.Blue3 = true;
                GameSettingsViewModel.Instance.Blue4 = true;
            }
        }
    }
}
