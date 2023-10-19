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
    public sealed partial class GameSettings : Page
    {
        public static Style RadioButtonStyle;
        public GameSettings()
        {
            this.InitializeComponent();

            RadioButtonStyle = radioButtonStyle;

            this.DataContext = new GameSettingsViewModel();
        }
    }
}
