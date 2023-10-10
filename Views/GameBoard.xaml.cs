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
        Board gameBoard = new Board(); //move to GameBoardViewModel ? 
        public GameBoard()
        {
            this.InitializeComponent();
            this.DataContext = new GameBoardViewModel();
        }

        //A draft-method for drawing A GAME BOARD 
        private void DrawBoard(CanvasControl sender, CanvasDrawEventArgs args)
        {
            List<Piece> pieces = new List<Piece>();
            //using of win2D´s classes

            CanvasDevice device = CanvasDevice.GetSharedDevice();
            using (CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (float)sender.ActualWidth, (float)sender.ActualHeight, 96))
            using (CanvasDrawingSession dSession = renderTarget.CreateDrawingSession())
            {

                //DRAWING PIECES OF THE GAME BOARD, so far there are squares 20x20
                float width = 20;
                float height = 20;

                //WEST ZONE========================================================================================================================
                float x = 30; 
                float y = 220;


                //a better tactics to merge all of four zones ?? 
                for (int raw = 0; raw < 3; raw++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (raw == 0 || raw == 2) //usual fields, all of them are white
                        {
                            dSession.FillRectangle(x, y, width, height, Colors.White);
                            x += 30;

                            Piece field = new Piece(Helpers.TypeOfLocation.Field,"w"); // w - west zone
                            pieces.Add(field);
                            //gameBoard.AddPiece(field);
                        }
                        if (raw == 1)
                        {

                            if (j > 0) 
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.Blue);
                                x += 30;
                                Piece final = new Piece(Helpers.TypeOfLocation.Final,"w");
                                pieces.Add(final);
                                //gameBoard.AddPiece(final);
                            }
                            else //usual field, white color 
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.White);
                                x += 30;
                                Piece field = new Piece(Helpers.TypeOfLocation.Field, "w");
                                pieces.Add(field);
                                //gameBoard.AddPiece(field);
                            }
                        }
                    }
                    x = 30;
                    y += 30;
                }


                //EAST ZONE==========================================================================================================================
                x = 420;
                y = 220;

                for (int raw = 0; raw < 3; raw++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (raw == 0 || raw == 2) //usual fields, all of them are white
                        {
                            dSession.FillRectangle(x, y, width, height, Colors.White);
                            x += 30;
                            Piece field = new Piece(Helpers.TypeOfLocation.Field, "e"); // e - east zone
                            pieces.Add(field);
                            //gameBoard.AddPiece(field);
                        }
                        if (raw == 1)
                        {
                            if (j < 5) //final pieces
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.Green);
                                x += 30;
                                Piece final = new Piece(Helpers.TypeOfLocation.Final, "e");
                                pieces.Add(final);
                                //gameBoard.AddPiece(final);
                            }
                            else //usual field, white color
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.White);
                                x += 30;
                                Piece field = new Piece(Helpers.TypeOfLocation.Field, "e");
                                pieces.Add(field);
                                //gameBoard.AddPiece(field);
                            }
                        }
                    }
                    x = 420;
                    y += 30;
                }


                // NORTH ZONE=======================================================================================================================
                x = 300;
                y = 200;
                for (int raw = 0; raw < 3; raw++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (raw == 0 || raw == 2) //usual fields, all of them are white
                        {
                            dSession.FillRectangle(x, y, width, height, Colors.White);
                            y -= 30;
                            Piece field = new Piece(Helpers.TypeOfLocation.Field, "n"); // north zone
                            pieces.Add (field);
                            //gameBoard.AddPiece(field);
                        }
                        if (raw == 1)
                        {
                            if (j < 5) //final pieces
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.Red);
                                y -= 30;
                                Piece final = new Piece(Helpers.TypeOfLocation.Final, "n");
                                pieces.Add(final);
                                //gameBoard.AddPiece(final);
                            }
                            else //usual field, white color
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.White);
                                y -= 30;
                                Piece field = new Piece(Helpers.TypeOfLocation.Field, "n");
                                pieces.Add(field);
                                //gameBoard.AddPiece(field);
                            }
                        }
                    }
                    x +=30;
                    y = 200;
                }


                //SOUTH ZONE======================================================================================================================
                x = 300;
                y = 370;
                for (int raw = 0; raw < 3; raw++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (raw == 0 || raw == 2) //usual fields, all of them are white
                        {
                            dSession.FillRectangle(x, y, width, height, Colors.White);
                            y += 30;
                            Piece field = new Piece(Helpers.TypeOfLocation.Field, "s");
                            pieces.Add(field);
                            //gameBoard.AddPiece(field);
                        }
                        if (raw == 1)
                        {
                            if (j < 5) //final pieces
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.Yellow);
                                y += 30;
                                Piece final = new Piece(Helpers.TypeOfLocation.Final, "s");
                                pieces.Add(final);
                                //gameBoard.AddPiece(final);
                            }
                            else //usual field, white color
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.White);
                                y += 30;
                                Piece field = new Piece(Helpers.TypeOfLocation.Field, "s");
                                pieces.Add(field);
                                //gameBoard.AddPiece(field);
                            }
                        }
                    }
                    x += 30;
                    y = 370;
                }

                gameBoard.GamePieces = pieces;
                counter.Text = $"{gameBoard.GamePieces.Count} pieces";
               


                args.DrawingSession.DrawImage(renderTarget);
            }
        }
    }
}
