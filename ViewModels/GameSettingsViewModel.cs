using LUDO.Commands;
using LUDO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using static System.Net.Mime.MediaTypeNames;

namespace LUDO.ViewModels
{

    internal class GameSettingsViewModel : ViewModelBase
    {
        private bool _isPlayer3Visible;
        private bool _isPlayer4Visible;
        private bool _isMinusButtonVisible;
        private bool _isPlusButtonVisible = true;
        private string _addRemoveText = "Add more players";
        public ICommand PlusPlayerCommand { get; set; }
        public ICommand MinusPlayerCommand { get; set; }
        public ICommand ForwardCommand { get; set; }
        public ICommand ChoosedColorCommand { get; set;}
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
        public GameSettingsViewModel()
        {
            Instance = this;
            PlusPlayerCommand = new AddPlayerCommand();
            MinusPlayerCommand = new RemovePlayerCommand();
        }

        //---- G ----
        private bool _isPlayer3ColorVisible;
        private bool _isPlayer4ColorVisible;


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

    }
}
  

