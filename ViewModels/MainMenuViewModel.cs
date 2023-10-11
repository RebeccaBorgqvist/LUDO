using LUDO.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LUDO.ViewModels
{
    internal class MainMenuViewModel : ViewModelBase // ViewModelBase ärvs för att man ska kunna använda OnPropertyChange i denna klass och andra.
    {
        public static MainMenuViewModel Instance { get; set; } // Denna behövs för att köra ett command, se nedan

        private string _text;
        public string Text
        {
            get { return _text; }
            set { if (value != _text)
                  {
                    _text = value;
                    OnPropertyChanged(nameof(Text)); // Denna känner av om Propertyn ändrats.
                  }
            }
        }
        public ICommand Command // Detta är Property för det Command man skriver i Binding. Den är oftast kopplad till knappar(button).
        {
            get; set;
        }
        /*public MainMenuViewModel()
        {
            Text = "HejHopp";
            Instance = this; // Denna tror vi används som en adress för att i TestCommands, ska komma åt rätt objekt? :)
            Command = new TestCommand(); // I TestCommand objektet kommer man skriva koden som ska styra det man vill ska ske när kommandot körs.
        }*/

       

    }
}
