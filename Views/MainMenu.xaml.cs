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
using Microsoft.Graphics.Canvas.Brushes; //superkommentaren för test!!!!
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;
using Microsoft.Graphics.Canvas;

namespace LUDO.Views
{
    public sealed partial class MainWindow : Page
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainMenuViewModel();
            MainMenuViewModel.Instance.MainMenuFrame = MainFrame;
            MainFrame.Navigate(typeof(StartMenu));
        }
        private void GoToGameBoard(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameBoard));
        } 
        
        
        
    }
}
