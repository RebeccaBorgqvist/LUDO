using System;
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
            panel.Children.Add(inputTextBox);
            dialog.Content = panel;
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string newName = inputTextBox.Text;
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
    }
}
