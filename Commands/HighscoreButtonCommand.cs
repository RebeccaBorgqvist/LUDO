using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace LUDO.Commands
{
    /// <summary>
    /// The command-class that navigates user into HighScore Section (TBD)
    /// </summary>
    internal class HighscoreButtonCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            var dialog = new MessageDialog("Highscore not yet implemented!");
            Task.Run(() => dialog.ShowAsync()).GetAwaiter();
        }
    }
}
