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
        /*public override void Execute(object parameter)
        {   //set1
            if (GameSettingsViewModel.Instance.Blue1 == true)
            {
                GameSettingsViewModel.Instance.Blue2 = false;
                GameSettingsViewModel.Instance.Blue3 = false;
                GameSettingsViewModel.Instance.Blue4 = false;
            }
            else if (GameSettingsViewModel.Instance.Red1 == true)
            {
                GameSettingsViewModel.Instance.Red2 = false;
                GameSettingsViewModel.Instance.Red3 = false;
                GameSettingsViewModel.Instance.Red4 = false;
            }
            else if (GameSettingsViewModel.Instance.Green1 == true)
            {
                GameSettingsViewModel.Instance.Green2 = false;
                GameSettingsViewModel.Instance.Green3 = false;
                GameSettingsViewModel.Instance.Green4 = false;
            }
            else if (GameSettingsViewModel.Instance.Yellow1 == true)
            {
                GameSettingsViewModel.Instance.Yellow2 = false;
                GameSettingsViewModel.Instance.Yellow3 = false;
                GameSettingsViewModel.Instance.Yellow4 = false;
            }//set2
            else if (GameSettingsViewModel.Instance.Blue2 == true)
            {
                GameSettingsViewModel.Instance.Blue1 = false;
                GameSettingsViewModel.Instance.Blue3 = false;
                GameSettingsViewModel.Instance.Blue4 = false;
            }
            else if (GameSettingsViewModel.Instance.Red2 == true)
            {
                GameSettingsViewModel.Instance.Red1 = false;
                GameSettingsViewModel.Instance.Red3 = false;
                GameSettingsViewModel.Instance.Red4 = false;
            }
            else if (GameSettingsViewModel.Instance.Green2 == true)
            {
                GameSettingsViewModel.Instance.Green1 = false;
                GameSettingsViewModel.Instance.Green3 = false;
                GameSettingsViewModel.Instance.Green4 = false;
            }
            else if (GameSettingsViewModel.Instance.Yellow2 == true)
            {
                GameSettingsViewModel.Instance.Yellow1 = false;
                GameSettingsViewModel.Instance.Yellow3 = false;
                GameSettingsViewModel.Instance.Yellow4 = false;
            }//set3
            else if (GameSettingsViewModel.Instance.Blue3 == true)
            {
                GameSettingsViewModel.Instance.Blue1 = false;
                GameSettingsViewModel.Instance.Blue2 = false;
                GameSettingsViewModel.Instance.Blue4 = false;
            }
            else if (GameSettingsViewModel.Instance.Red3 == true)
            {
                GameSettingsViewModel.Instance.Red1 = false;
                GameSettingsViewModel.Instance.Red2 = false;
                GameSettingsViewModel.Instance.Red4 = false;
            }
            else if (GameSettingsViewModel.Instance.Green3 == true)
            {
                GameSettingsViewModel.Instance.Green1 = false;
                GameSettingsViewModel.Instance.Green2 = false;
                GameSettingsViewModel.Instance.Green4 = false;
            }
            else if (GameSettingsViewModel.Instance.Yellow3 == true)
            {
                GameSettingsViewModel.Instance.Yellow1 = false;
                GameSettingsViewModel.Instance.Yellow2 = false;
                GameSettingsViewModel.Instance.Yellow4 = false;
            }//set4
            else if (GameSettingsViewModel.Instance.Blue4 == true)
            {
                GameSettingsViewModel.Instance.Blue1 = false;
                GameSettingsViewModel.Instance.Blue2 = false;
                GameSettingsViewModel.Instance.Blue3 = false;
            }
            else if (GameSettingsViewModel.Instance.Red4 == true)
            {
                GameSettingsViewModel.Instance.Red1 = false;
                GameSettingsViewModel.Instance.Red2 = false;
                GameSettingsViewModel.Instance.Red3 = false;
            }
            else if (GameSettingsViewModel.Instance.Green4 == true)
            {
                GameSettingsViewModel.Instance.Green1 = false;
                GameSettingsViewModel.Instance.Green2 = false;
                GameSettingsViewModel.Instance.Green3 = false;
            }
            else if (GameSettingsViewModel.Instance.Yellow4 == true)
            {
                GameSettingsViewModel.Instance.Yellow1 = false;
                GameSettingsViewModel.Instance.Yellow2 = false;
                GameSettingsViewModel.Instance.Yellow3 = false;
            }
            else
            {
                GameSettingsViewModel.Instance.Blue1 = true;
                GameSettingsViewModel.Instance.Blue2 = true;
                GameSettingsViewModel.Instance.Blue3 = true;
                GameSettingsViewModel.Instance.Blue4 = true;
            }
        }*/

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
