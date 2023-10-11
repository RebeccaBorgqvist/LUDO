using LUDO.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.I2c;
using LUDO.Models;

namespace LUDO.ViewModels
{
    internal class GameSettingsViewModel : ViewModelBase
    {
        private bool _isPlayer3Visible;
        private bool _isPlayer4Visible;
        private bool _isMinusButtonVisible;
        private bool _isPlusButtonVisible = true;
        private string _addRemoveText = "Add more players";
        private int _players = 2;
        private string _player1Name = "Player 1";
        private string _player2Name = "Player 2";
        private string _player3Name = "Player 3";
        private string _player4Name = "Player 4";
        public ICommand PlusPlayerCommand { get; set; }
        public ICommand MinusPlayerCommand { get; set; }
        public ICommand ForwardCommand { get; set; }
        public ICommand ChangeNameCommand { get; set; }
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
        public bool IsPlusButtonVisible
        {
            get { return _isPlusButtonVisible; }
            set
            {
                _isPlusButtonVisible = value;
                OnPropertyChanged(nameof(IsPlusButtonVisible));
            }
        }
        public string AddRemoveText
        {
            get { return _addRemoveText; }
            set 
            {
                _addRemoveText = value;
                OnPropertyChanged(nameof(AddRemoveText));
            }
        }
        public string Player1Name
        {
            get { return _player1Name; }
            set
            {
                _player1Name = value;
                OnPropertyChanged(nameof(Player1Name));
            }
        }
        public string Player2Name
        {
            get { return _player2Name; }
            set
            {
                _player2Name = value;
                OnPropertyChanged(nameof(Player2Name));
            }
        }
        public string Player3Name
        {
            get { return _player3Name; }
            set
            {
                _player3Name = value;
                OnPropertyChanged(nameof(Player3Name));
            }
        }
        public string Player4Name
        {
            get { return _player4Name; }
            set
            {
                _player4Name = value;
                OnPropertyChanged(nameof(Player4Name));
            }
        }
        public int Players
        {
            get { return _players; }
            set { _players = value; }
        }
        public GameSettingsViewModel()
        {
            Instance = this;
            PlusPlayerCommand = new AddPlayerCommand();
            MinusPlayerCommand = new RemovePlayerCommand();
            ForwardCommand = new ForwardCommand();
            ChangeNameCommand = new ChangeNameCommand();
        }
    }
}
