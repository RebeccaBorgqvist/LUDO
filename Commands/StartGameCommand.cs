using LUDO.Models;
using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace LUDO.Commands
{
    /// <summary>
    /// The command-class that starts the game 
    /// </summary>
    internal class StartGameCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            GameBoardViewModel.Instance.StartButtonVisibility = Visibility.Collapsed;
            GameBoardViewModel.Instance.CreateGame();
        }
    }
}
