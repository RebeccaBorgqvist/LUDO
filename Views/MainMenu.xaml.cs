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
using LUDO.ViewModels; // Denna läggs till för att kunna nå ViewModels filerna
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;
using Microsoft.Graphics.Canvas;

namespace LUDO.Views
{
    public sealed partial class MainMenu : Page
    {
        public MainMenu()
        {
            this.InitializeComponent();
            this.DataContext = new MainMenuViewModel(); // Här kopplas xaml filen ihop med ViewModel, istället för att arbeta med sin bakomliggande xaml.cs fil.
            
        }
        private void GoToGameBoard(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameBoard));
        }       
        
    }
}
