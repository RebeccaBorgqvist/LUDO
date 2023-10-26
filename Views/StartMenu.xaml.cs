using LUDO.ViewModels;
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

namespace LUDO.Views
{
    /// <summary>
    /// The Frame class that stands for the start menu (with 3 different button options in there) 
    /// The StartMenu goes together with MainMenu and its two buttons(goToMainMenu- and HighScore button)
    /// </summary>
    public sealed partial class StartMenu : Page
    {
        public StartMenu()
        {
            this.InitializeComponent();
            this.DataContext = MainMenuViewModel.Instance;
        }
    }
}
