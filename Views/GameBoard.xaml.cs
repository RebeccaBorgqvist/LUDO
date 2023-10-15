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
using LUDO.ViewModels; // Denna läggs till för att kunna nå ViewModels filerna
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas;
using Windows.UI;
using LUDO.Models;

namespace LUDO.Views
{
    public sealed partial class GameBoard : Page
    {
      
        public GameBoard()
        {
            this.InitializeComponent();
            this.DataContext = new GameBoardViewModel();

            GameBoardViewModel.Instance.GameBoardCanvas = GameBoardCanvas;
            GameBoardViewModel.Instance.GameBoardCanvas.Draw += GameBoardViewModel.Instance.DrawBoard;
        }
    }
}
