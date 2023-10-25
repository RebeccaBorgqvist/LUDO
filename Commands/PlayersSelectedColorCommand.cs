using LUDO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LUDO.ViewModels.GameSettingsViewModel;
using LUDO.Views;
using Windows.UI.Popups;
using System.Reflection;

namespace LUDO.Commands
{
    internal class PlayersSelectedColorCommand : BaseCommands
    {
       public override void Execute(object parameter)
        {
            string[] colorNames = { "Blue", "Red", "Green", "Yellow" };

            for (int player = 1; player <= 4; player++)
            {
                bool isPlayerSelected = false;

                foreach (string color in colorNames)
                {
                    bool isColorSelected = (bool)GameSettingsViewModel.Instance
                        .GetType()
                        .GetProperty($"{color}{player}")
                        .GetValue(GameSettingsViewModel.Instance);

                    if (isColorSelected)
                    {
                        // If the color is selected, set it to true
                        isPlayerSelected = true;
                    }
                    else
                    {
                        // If the color is not selected, set it to false
                        GameSettingsViewModel.Instance.GetType()
                            .GetProperty($"{color}{player}")
                            .SetValue(GameSettingsViewModel.Instance, false);
                    }
                }

                // If no color is selected for the player, set all colors to false
                if (!isPlayerSelected)
                {
                    foreach (string color in colorNames)
                    {
                        GameSettingsViewModel.Instance.GetType()
                            .GetProperty($"{color}{player}")
                            .SetValue(GameSettingsViewModel.Instance, false);
                    }
                }
            }

        }

    }
}


