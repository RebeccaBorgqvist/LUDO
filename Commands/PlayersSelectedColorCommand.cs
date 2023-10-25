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
using LUDO.Helpers;
using LUDO.Models;

namespace LUDO.Commands
{
    internal class PlayersSelectedColorCommand : BaseCommands
    {
            public override void Execute(object parameter)
            {
                string[] colorNames = { "Blue", "Red", "Green", "Yellow" };
                var playersList = new List<Player>();

                for (int player = 1; player <= 4; player++)
                {
                    Color selectedColor = Color.None; // Default color if none is selected

                    foreach (string color in colorNames)
                    {
                        bool isColorSelected = (bool)GameSettingsViewModel.Instance
                            .GetType()
                            .GetProperty($"{color}{player}")
                            .GetValue(GameSettingsViewModel.Instance);

                        if (isColorSelected)
                        {
                            selectedColor = (Color)Enum.Parse(typeof(Color), color);
                            break; // Exit the loop as soon as a color is selected
                        }
                    }

                // Create a new Player instance with the selected color and add it to the list
                var newPlayer = new Player($"Player {player}", selectedColor);
                playersList.Add(newPlayer);
                //Debug.WriteLine($"Player {newPlayer} selected color: {selectedColor}");
            }
            GameSettingsViewModel.Instance.PlayersList = playersList;
        }
    }

}
  


