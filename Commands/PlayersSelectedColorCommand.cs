using LUDO.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace LUDO.Commands
{
    internal class PlayersSelectedColorCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            //GameSettingsViewModel.Instance.ColorSelectionAvailability[colorIndex - 1] = false;
            //GameSettingsViewModel.Instance.UpdateColorSelectionAvailability();
        }
    }
}
