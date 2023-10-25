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
    }
}
