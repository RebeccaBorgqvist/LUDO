using LUDO.Models;
using LUDO.Views;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;

namespace LUDO.ViewModels
{
    internal class GameBoardViewModel : ViewModelBase
    {
        private string _textStorlek;

        Board gameBoard = new Board(); 

        public static GameBoardViewModel Instance { get; set; }

        public string TextStorlek {  
            get { return _textStorlek;}
            set { if (value != _textStorlek) 
                { 
                    _textStorlek = value;
                    OnPropertyChanged(nameof(TextStorlek));
                };
            }
        }


        //property for building game board.
        public CanvasControl GameBoardCanvas
        { get; set; }



        public GameBoardViewModel( ) 
        {
            this._textStorlek = "25";
            Location nest = new Location(new List<Piece>(), Helpers.TypeOfLocation.Nest);
            Instance = this;
        }


        //USAGE OF WIN2D API: DRAWING CELLS OF THE GAME BOARD(fields, finals, goals, nests)       

        internal void DrawBoard(CanvasControl sender, CanvasDrawEventArgs args)
        {

            List<Cell> gameBoardCells = new List<Cell>();

            CanvasDevice device = CanvasDevice.GetSharedDevice();
            using (CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (float)sender.ActualWidth, (float)sender.ActualHeight, 96))
            using (CanvasDrawingSession dSession = renderTarget.CreateDrawingSession())
            {

                //size for the fields

                float width = 20;
                float height = 20;

                //coordinates
                int xDefault;
                int yDefault;

                int x;
                int y;
                Color color = new Color();

                //SECTIONS: 0=north;1=east;2=south;3=west
                for (int section = 0; section < 4; section++)
                {
                    //ID to recognize a cell
                    int fieldsID = 0;
                    int finalsID = 0;

                    //params for nests
                    float centerX;
                    float centerY;

                    float radius;
                    float radius2; // for white inner circle 

                    if (section == 0)
                    {
                        //cells
                        x = 430; xDefault = 430;
                        y = 280; yDefault = 280;
                        color = Colors.Red;

                        //nest belonging to NORTH(yellow) player
                        centerX = 620;
                        centerY = 205; 
                        radius = 75;
                        radius2 = radius - 20;



                    }
                    else if (section == 1)
                    {
                        x = 520; xDefault = 520;
                        y = 300; yDefault = 300;
                        color = Colors.Green;

                        //nest belonging to WEST(green) player
                        centerX = 620;
                        centerY = 480;
                        radius = 75;
                        radius2 = radius - 20;

                    }
                    else if (section == 2)
                    {
                        x = 490; xDefault = 490;
                        y = 380; yDefault = 380;
                        color = Colors.Yellow;

                        //nest belonging to SOUTH (red) player
                        centerX = 320;
                        centerY = 480;
                        radius = 75;
                        radius2 = radius - 20;
                    }
                    else
                    {
                        x = 400; xDefault = 400;
                        y = 360; yDefault = 360;
                        color = Colors.Blue;

                        //nest belonging to EAST(blue) player
                        centerX = 320;
                        centerY = 205;
                        radius = 75;
                        radius2 = radius - 20;
                    }

                    //fields & finals
                    for (int raw = 0; raw < 3; raw++)
                    {
                        for (int field = 0; field < 6; field++)
                        {
                            if (raw == 0 || raw == 2) // here only white fields
                            {
                                //front end
                                dSession.FillRectangle(x, y, width, height, Colors.White);



                                //back end
                                int[] cellsCoordinates = new int[] { x, y };
                                if (section == 0) y -= 30;
                                if (section == 1) x += 30;
                                if(section  == 2) y += 30;
                                if(section == 3) x -= 30;
                           
                                Cell fieldCell = new Cell(section, ++fieldsID, false,cellsCoordinates);
                                gameBoardCells.Add(fieldCell);

                            }
                            else if (raw == 1)
                            {
                                if (field <5)
                                {
                                    //front end
                                    dSession.FillRectangle(x, y, width, height, color);


                                    //back end
                                    int[] cellsCoordinates = new int[] { x, y };
                                    if (section == 0) y -= 30;
                                    if(section==1) x += 30;
                                    if(section == 2) y += 30;
                                    if (section == 3) x -= 30;

                                    Cell finalCell = new Cell(section, ++finalsID, true, cellsCoordinates);
                                    gameBoardCells.Add(finalCell);

                                }
                                if (field == 5)
                                {
                                    //front end
                                    dSession.FillRectangle(x, y, width, height, Colors.White);


                                    //back end
                                    int[] cellsCoordinates = new int[] { x, y };
                                    Cell fieldCell = new Cell(section, ++fieldsID, false, cellsCoordinates);
                                    gameBoardCells.Add(fieldCell);

                                }
                            }
                        }
                        if (section == 0)
                        {
                            y = yDefault;
                            x += 30;
                        }
                        if (section == 1)
                        { 
                            x= xDefault;
                            y += 30;
                        }
                        if (section == 2)
                        { 
                            y= yDefault;
                            x -= 30;
                        }
                        if (section == 3)
                        {
                            x = xDefault;
                            y -= 30;
                        }                        
                    }



                    //nest
                    dSession.FillCircle(centerX, centerY, radius, color); // outer colored circle
                    dSession.FillCircle(centerX, centerY, radius2, Colors.White); //inner circle


                    int nestCellsID = 0;

                    for (int nestCell = 0; nestCell < 4; nestCell++)
                    {
                        int coordX = (int)centerX;
                        int coordY = (int)centerY;
                        
                        if (nestCell == 0)
                        {
                            coordX = (int)centerX - 25;
                            coordY = (int)centerY - 25;
                        } 
                        if(nestCell == 1) 
                        {
                            coordX = (int)centerX + 25;
                            coordY = (int)centerY - 25;
                        }
                        if( nestCell == 2)
                        {
                            coordX = (int)centerX - 25;
                            coordY = (int)centerY + 25;
                        }
                        if( nestCell == 3)
                        {
                            coordX = (int)centerX + 25;
                            coordY = (int)centerY + 25;
                        }

                        //front end
                        dSession.FillCircle(coordX, coordY, radius-60, color);                            

                        //back end
                        int[] coordinates = new int[] { coordX, coordY };
                        Cell nestCellObj = new Cell(section,--nestCellsID, false, coordinates);
                        gameBoardCells.Add(nestCellObj);
                    }
                }
                args.DrawingSession.DrawImage(renderTarget);
            }
            gameBoard.GameCells = gameBoardCells;



            foreach (Cell cell in gameBoard.GameCells)
            {
                if (cell.Section == 0 && cell.Id == 8 && cell.IsFinal == false)
                {
                    int[] coord = cell.Coordinates;
                    Debug.WriteLine($"x: {coord[0]}, y: {coord[1]}");

                    
                }
            }

        }
    }
}
