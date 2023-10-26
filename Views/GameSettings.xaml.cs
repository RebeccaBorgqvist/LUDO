using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LUDO.ViewModels;

namespace LUDO.Views
{
    /// <summary>
    /// The Frame class that stands for the game settings
    /// The manipulations with the game board goes via GameSettingsViewModel class
    /// </summary>
    public sealed partial class GameSettings : Page
    {
        public GameSettings()
        {
            this.InitializeComponent();
            this.DataContext = new GameSettingsViewModel();
        }
    }
}
