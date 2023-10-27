using LUDO.ViewModels;
using LUDO.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace LUDO.Commands
{
    /// <summary>
    /// The command-class that navigates user to GameSettings Frame 
    /// </summary>
    internal class PlayButtonCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            // TBD: Transitions?
            MainMenuViewModel.Instance.MainMenuFrame.Navigate(typeof(GameSettings), null, new SuppressNavigationTransitionInfo());
        }
    }
}
