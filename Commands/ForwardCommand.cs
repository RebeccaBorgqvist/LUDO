using LUDO.Models;
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
    internal class ForwardCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            // TBD: MOVE CODE TO RELEVANT CLASS?
            List<Player> players = new List<Player>();

            players.Add(new Player(GameSettingsViewModel.Instance.Player1Name));
            players.Add(new Player(GameSettingsViewModel.Instance.Player2Name));

            if (GameSettingsViewModel.Instance.IsPlayer3Visible)
            {
                players.Add(new Player(GameSettingsViewModel.Instance.Player3Name));
            }
            if (GameSettingsViewModel.Instance.IsPlayer4Visible)
            {
                players.Add(new Player(GameSettingsViewModel.Instance.Player4Name));
            }

            MainMenuViewModel.Instance.MainMenuFrame.Navigate(typeof(GameBoard), null, new SuppressNavigationTransitionInfo());
        }
    }
}
