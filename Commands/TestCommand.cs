using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace LUDO.Commands
{
    internal class TestCommand : BaseCommands // Ärvd kod som används till att hantera knapptryck och förändring med det
    {
        public override void Execute(object parameter)
        {
            MainMenuViewModel.Instance.Text = "Ny Text :D";
        }
    }
}
