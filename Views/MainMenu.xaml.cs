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

        private void TestDrawings(CanvasControl sender, CanvasDrawEventArgs args)
        {
            CanvasDevice device = CanvasDevice.GetSharedDevice();
            using (CanvasRenderTarget renderTarget = new CanvasRenderTarget(device,(float)sender.ActualWidth, (float)sender.ActualHeight,96)) 
                using(CanvasDrawingSession dSession = renderTarget.CreateDrawingSession())
            {
                dSession.DrawText("The future FIA-game", 10, 10, Windows.UI.Colors.Pink);

                float x = 50;
                float y = 50;                
                float width = 20;
                float height = 20;

                for(int i = 0; i < 10; i++) 
                {
                    dSession.FillRectangle(x, y, width, height, Colors.White);
                    y += 30;                    
                }
                y = 50;
                for (int i = 0; i < 10; i++)
                {
                    dSession.FillRectangle(x, y, width, height, Colors.White);
                    x += 30;
                }



                args.DrawingSession.DrawImage(renderTarget);
            }
        }
    }
}
