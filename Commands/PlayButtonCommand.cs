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
    internal class PlayButtonCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            // TBD: Transitions?
            MainMenuViewModel.Instance.MainMenuFrame.Navigate(typeof(PlayerSelect), null, new SuppressNavigationTransitionInfo());
        }
    }
}
