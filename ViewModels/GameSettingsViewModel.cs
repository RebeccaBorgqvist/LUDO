using LUDO.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.I2c;

namespace LUDO.ViewModels
{
    internal class GameSettingsViewModel : ViewModelBase
    {
        private bool _isPlayer3Visible;
        private bool _isPlayer4Visible;
        private bool _isMinusButtonVisible;
        public ICommand PlusPlayerCommand { get; set; }
        public ICommand MinusPlayerCommand { get; set; }
        public static GameSettingsViewModel Instance { get; set; }
        public bool IsPlayer3Visible
        {
            get { return _isPlayer3Visible; }
            set 
            { 
                _isPlayer3Visible = value;
                OnPropertyChanged(nameof(IsPlayer3Visible));   
            }
        }
        public bool IsPlayer4Visible
        {
            get { return _isPlayer4Visible; }
            set
            {
                _isPlayer4Visible = value;
                OnPropertyChanged(nameof(IsPlayer4Visible));
            }
        }
        public bool IsMinusButtonVisible
        {
            get { return _isMinusButtonVisible; }
            set
            {
                _isMinusButtonVisible = value;
                OnPropertyChanged(nameof(IsMinusButtonVisible));
            }
        }
        public GameSettingsViewModel()
        {
            Instance = this;
            PlusPlayerCommand = new AddPlayerCommand();
            MinusPlayerCommand = new RemovePlayerCommand();
        }
    }
}
