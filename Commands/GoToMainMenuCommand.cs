using LUDO.ViewModels;
using LUDO.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using System.Diagnostics;
using Windows.UI.Popups;

namespace LUDO.Commands
{
    /// <summary>
    /// The class-command that navigates the user into the MainMenu Frame
    /// </summary>
    internal class GoToMainMenuCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            var dialog = new MessageDialog("Be aware that if you exit, the current game progress will be lost!");
            Task.Run(() => dialog.ShowAsync()).GetAwaiter();

            dialog.Commands.Add(new UICommand("OK", command =>
            {
                Frame currentFrame = Window.Current.Content as Frame;

                if (currentFrame != null)
                {
                    currentFrame.Navigate(typeof(MainWindow));
                }
            }
                ));

            dialog.Commands.Add(new UICommand("Cancel", command =>
            {

            }
               ));
        }
    }
}
