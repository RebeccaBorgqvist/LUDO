using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LUDO.ViewModels.GameSettingsViewModel;

namespace LUDO.Commands
{
    internal class PlayersSelectedColorCommand : BaseCommands
    {

        public override void Execute(object parameter)
        {
            if (parameter is string color)
            {
                for (int player = 1; player <= 4; player++)
                {
                    // Set the current player's color to the desired color and others to false
                    for (int p = 1; p <= 4; p++)
                    {
                        var propertyName = $"{color}{p}";
                        var propertyInfo = GameSettingsViewModel.Instance.GetType().GetProperty(propertyName);
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(GameSettingsViewModel.Instance, p == player);
                        }
                    }
                }
            }
        }
    }
}
