﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUDO.ViewModels;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace LUDO.Commands
{
    internal class ChangeNameCommand : BaseCommands
    {

        public override async void Execute(object parameter)
        {
            ContentDialog dialog = new ContentDialog
            {
                PrimaryButtonText = "OK",
                CloseButtonText = "Cancel"
            };

            StackPanel panel = new StackPanel();
            TextBox inputTextBox = new TextBox
            {
                MaxLength = 12
            };

            void HandleDialogResult(string newName)
            {
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    // Determine which player's name to change based on the parameter
                    switch (parameter.ToString())
                    {
                        case "Player1Name":
                            GameSettingsViewModel.Instance.Player1Name = newName;
                            break;
                        case "Player2Name":
                            GameSettingsViewModel.Instance.Player2Name = newName;
                            break;
                        case "Player3Name":
                            GameSettingsViewModel.Instance.Player3Name = newName;
                            break;
                        case "Player4Name":
                            GameSettingsViewModel.Instance.Player4Name = newName;
                            break;
                    }
                }
            }

            // Attach a callback to the PrimaryButtonClick event (OK button)
            dialog.PrimaryButtonClick += (sender, args) =>
            {
                string newName = inputTextBox.Text;
                HandleDialogResult(newName);
            };

            // Handle KeyUp event for the TextBox
            inputTextBox.KeyUp += async (sender, e) =>
            {
                if (e.Key == Windows.System.VirtualKey.Enter)
                {
                    dialog.Hide(); // Close the dialog
                    string newName = inputTextBox.Text;
                    HandleDialogResult(newName);
                }
            };

            // Add the TextBox to the StackPanel
            panel.Children.Add(inputTextBox);
            dialog.Content = panel;

            // Show the ContentDialog and await the result
            ContentDialogResult result = await dialog.ShowAsync();
        }
    }
}
