using LUDO.Models;
using LUDO.ViewModels;
using LUDO.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;

namespace LUDO.Commands
{
    internal class ForwardCommand : BaseCommands
    {
        public override void Execute(object parameter)
         {
             MainMenuViewModel.Instance.MainMenuFrame.Navigate(typeof(GameBoard), null, new SuppressNavigationTransitionInfo());
         }

       /* public override async void Execute(object parameter)
        {
            if (GameSettingsViewModel.Instance.AreSelectionsValid)
            {
                MainMenuViewModel.Instance.MainMenuFrame.Navigate(typeof(GameBoard), null, new SuppressNavigationTransitionInfo());
            }
            else
            {
                // Display a warning message to the user
                var messageDialog = new MessageDialog("Please select colors for all players before starting the game.");
                await messageDialog.ShowAsync();
            }
        }*/
    }
}
