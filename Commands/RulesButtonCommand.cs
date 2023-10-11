using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace LUDO.Commands
{
    internal class RulesButtonCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            var dialog = new MessageDialog("Rules not yet implemented!");
            Task.Run(() => dialog.ShowAsync()).GetAwaiter();
        }
    }
}
