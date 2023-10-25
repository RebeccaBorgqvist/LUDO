using LUDO.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.I2c;
using LUDO.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;

namespace LUDO.ViewModels
{
    internal class GameSettingsViewModel : ViewModelBase
    {
        private bool _isPlayer3Visible;
        private bool _isPlayer4Visible;
        private bool _isMinusButtonVisible;
        private bool _isPlusButtonVisible = true;
        private bool _isPlayer3ColorVisible;
        private bool _isPlayer4ColorVisible;

        private bool _blue1 = true;
        private bool _blue2 = true;
        private bool _blue3 = true;
        private bool _blue4 = true;

        private bool _red1 = true;
        private bool _red2 = true;
        private bool _red3 = true;
        private bool _red4 = true;

        private bool _green1 = true;
        private bool _green2 = true;
        private bool _green3 = true;
        private bool _green4 = true;

        private bool _yellow1 = true;
        private bool _yellow2 = true;
        private bool _yellow3 = true;
        private bool _yellow4 = true;

        private string _addRemoveText = "Add more players";

        private int _players = 2;

        private string _player1Name = "Player 1";
        private string _player2Name = "Player 2";
        private string _player3Name = "Player 3";
        private string _player4Name = "Player 4";


        public List<Player> PlayerList { get; set; }
        //

        public ICommand PlusPlayerCommand { get; set; }
        public ICommand MinusPlayerCommand { get; set; }
        public ICommand ForwardCommand { get; set; }
        public ICommand ChangeNameCommand { get; set; }
        public ICommand ChangeColor { get; set; }
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
        public bool IsPlayer3ColorsVisible
        {
            get { return _isPlayer3ColorVisible; }
            set
            {
                _isPlayer3ColorVisible = value;
                OnPropertyChanged(nameof(IsPlayer3ColorsVisible));
            }
        }

        public bool IsPlayer4ColorsVisible
        {
            get { return _isPlayer4ColorVisible; }
            set
            {
                _isPlayer4ColorVisible = value;
                OnPropertyChanged(nameof(IsPlayer4ColorsVisible));
            }
        }
        // BLUE
        public bool Blue1
        {
            get { return _blue1; }
            set
            {
                _blue1 = value;
                OnPropertyChanged(nameof(Blue1));
            }
        }

        public bool Blue2
        {
            get { return _blue2; }
            set
            {
                _blue2 = value;
                OnPropertyChanged(nameof(Blue2));
            }
        }
        public bool Blue3
        {
            get { return _blue3; }
            set
            {
                _blue3 = value;
                OnPropertyChanged(nameof(Blue3));
            }
        }
        public bool Blue4
        {
            get { return _blue4; }
            set
            {
                _blue4 = value;
                OnPropertyChanged(nameof(Blue4));
            }
        }
        // RED
        public bool Red1
        {
            get { return _red1; }
            set
            {
                _red1 = value;
                OnPropertyChanged(nameof(Red1));
            }
        }
        public bool Red2
        {
            get { return _red2; }
            set
            {
                _red2 = value;
                OnPropertyChanged(nameof(Red2));
            }
        }
        public bool Red3
        {
            get { return _red3; }
            set
            {
                _red3 = value;
                OnPropertyChanged(nameof(Red3));
            }
        }
        public bool Red4
        {
            get { return _red4; }
            set
            {
                _red4 = value;
                OnPropertyChanged(nameof(Red4));
            }
        }
        // GREEN
        public bool Green1
        {
            get { return _green1; }
            set
            {
                _green1 = value;
                OnPropertyChanged(nameof(Green1));
            }
        }
        public bool Green2
        {
            get { return _green2; }
            set
            {
                _green2 = value;
                OnPropertyChanged(nameof(Green2));
            }
        }
        public bool Green3
        {
            get { return _green3; }
            set
            {
                _green3 = value;
                OnPropertyChanged(nameof(Green3));
            }
        }
        public bool Green4
        {
            get { return _green4; }
            set
            {
                _green4 = value;
                OnPropertyChanged(nameof(Green4));
            }
        }

        // YELLOW
        public bool Yellow1
        {
            get { return _yellow1; }
            set
            {
                _yellow1 = value;
                OnPropertyChanged(nameof(Yellow1));
            }
        }
        public bool Yellow2
        {
            get { return _yellow2; }
            set
            {
                _yellow2 = value;
                OnPropertyChanged(nameof(Yellow2));
            }
        }
        public bool Yellow3
        {
            get { return _yellow3; }
            set
            {
                _yellow3 = value;
                OnPropertyChanged(nameof(Yellow3));
            }
        }
        public bool Yellow4
        {
            get { return _yellow4; }
            set
            {
                _yellow4 = value;
                OnPropertyChanged(nameof(Yellow4));
            }
        }

        public GameSettingsViewModel()
        {
            Instance = this;
            PlusPlayerCommand = new AddPlayerCommand();
            MinusPlayerCommand = new RemovePlayerCommand();
            ForwardCommand = new ForwardCommand();
            ChangeNameCommand = new ChangeNameCommand();
            ChangeColor = new PlayersSelectedColorCommand();
        }

    }
}
