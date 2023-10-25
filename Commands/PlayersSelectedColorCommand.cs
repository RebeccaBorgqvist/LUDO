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

namespace LUDO.Commands
{
    internal class PlayersSelectedColorCommand : BaseCommands
    {
            public override void Execute(object parameter)
            {
                string[] colorNames = { "Blue", "Red", "Green", "Yellow" };
                var playersList = new List<Color>();

                for (int player = 1; player <= 4; player++)
                {
                    Color selectedColor = Color.Blue; // Default color if none is selected

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

                    playersList.Add(selectedColor);
                }

                GameSettingsViewModel.Instance.PlayersList = playersList;
            }
    }

        /* public override void Execute(object parameter)
         {
             string[] colorNames = { "Blue", "Red", "Green", "Yellow" };
             var playersList = new List<Color>();

             for (int player = 1; player <= 4; player++)
             {
                 Color selectedColor = Color.Blue; // Default color if none is selected

                 bool isAnyColorSelected = false;

                 foreach (string color in colorNames)
                 {
                     bool isColorSelected = (bool)GameSettingsViewModel.Instance
                         .GetType()
                         .GetProperty($"{color}{player}")
                         .GetValue(GameSettingsViewModel.Instance);

                     if (isColorSelected)
                     {
                         selectedColor = (Color)Enum.Parse(typeof(Color), color);
                         isAnyColorSelected = true;
                         break; // Exit the loop as soon as a color is selected
                     }
                 }

                 if (!isAnyColorSelected)
                 {
                     // Handle the case where no color is selected by setting a default color.
                     // You can choose a different default color if needed.
                     selectedColor = Color.Black; // Default color
                 }

                 playersList.Add(selectedColor);
             }

             GameSettingsViewModel.Instance.PlayersList = playersList;
         }*

        /*public override void Execute(object parameter)
        {
            string[] colorNames = { "Blue", "Red", "Green", "Yellow" };
            var playersList = new List<Color>();

            for (int player = 1; player <= 4; player++)
            {
                Color selectedColor = Color.None; // Default unselected state

                bool isAnyColorSelected = false;

                foreach (string color in colorNames)
                {
                    bool isColorSelected = (bool)GameSettingsViewModel.Instance
                        .GetType()
                        .GetProperty($"{color}{player}")
                        .GetValue(GameSettingsViewModel.Instance);

                    if (isColorSelected)
                    {
                        selectedColor = (Color)Enum.Parse(typeof(Color), color);
                        isAnyColorSelected = true;
                        break; // Exit the loop as soon as a color is selected
                    }
                }

                playersList.Add(selectedColor);
            }

            GameSettingsViewModel.Instance.PlayersList = playersList;

            // Check the validity of selections
            GameSettingsViewModel.Instance.CheckSelectionsValidity();
        }*/

    }
  


