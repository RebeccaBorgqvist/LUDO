using LUDO.Commands;
using LUDO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LUDO.ViewModels
{
    internal class GameBoardViewModel : ViewModelBase
    {
        public static GameBoardViewModel Instance { get; private set; }

        private Dice _diceModel;

        private string _currentDiceImage;
        public string CurrentDiceImage
        {
            get { return _currentDiceImage; }
            set
            {
                if (_currentDiceImage != value)
                {
                    _currentDiceImage = value;
                    OnPropertyChanged(nameof(CurrentDiceImage));
                }
            }
        }

        public ICommand RollDiceCommand { get; set; }

        public GameBoardViewModel()
        {
            Instance = this;
            _diceModel = new Dice();
            RollDiceCommand = new RollDiceCommand();
            CurrentDiceImage = "ms-appx:///Assets/roll_dice.png";
        }
    }
}
