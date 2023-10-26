using LUDO.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace LUDO.ViewModels
{
    internal class MainMenuViewModel : ViewModelBase // ViewModelBase ärvs för att man ska kunna använda OnPropertyChange i denna klass och andra.
    {
        public static MainMenuViewModel Instance { get; set; } // Denna behövs för att köra ett command, se nedan

        public Frame MainMenuFrame { get; set; }

        public ICommand PlayButtonCommand { get; private set; }
        public ICommand HighscoreButtonCommand { get; private set; }
        public ICommand RulesButtonCommand { get; private set; }

        public ICommand GoToMainMenuCommand { get; private set; }

        public MainMenuViewModel()
        {
            // Assigning this instance to public static property for object access
            Instance = this;

            // Command instantiations
            PlayButtonCommand = new PlayButtonCommand();
            HighscoreButtonCommand = new HighscoreButtonCommand();
            RulesButtonCommand = new RulesButtonCommand();

            //navigation within the application
            GoToMainMenuCommand = new GoToMainMenuCommand();
        }
    }
}
