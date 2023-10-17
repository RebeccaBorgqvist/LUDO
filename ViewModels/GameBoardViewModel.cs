
﻿using LUDO.Models;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
﻿using LUDO.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;


namespace LUDO.ViewModels
{
    internal class GameBoardViewModel : ViewModelBase
    {
        public static GameBoardViewModel Instance { get; private set; }

        private Dice _diceModel;
        Board gameBoard = new Board();

        private string _currentDiceImage;
        public string CurrentDiceImage
        {
            get { return _currentDiceImage; }
            set
            {
                if (_currentDiceImage != value)
                {
                    _currentDiceImage = value;
                    OnPropertyChanged(nameof(CurrentDiceImage));
                }
            }
        }

        public ICommand RollDiceCommand { get; set; }


        //property for building game board.
        public CanvasControl GameBoardCanvas
        { get; set; }

        public GameBoardViewModel()
        {
            Instance = this;
            _diceModel = new Dice();
            RollDiceCommand = new RollDiceCommand();
            CurrentDiceImage = "./Assets/roll_dice.png";
        }



        //USAGE OF WIN2D API: DRAWING CELLS OF THE GAME BOARD(fields, finals, goals, nests)     
        internal void DrawBoard(CanvasControl sender, CanvasDrawEventArgs args)
        {

            List<Cell> gameBoardCells = new List<Cell>();

            CanvasDevice device = CanvasDevice.GetSharedDevice();
            using (CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (float)sender.ActualWidth, (float)sender.ActualHeight, 96))
            using (CanvasDrawingSession dSession = renderTarget.CreateDrawingSession())
            {

                //size and coordinates for the fields

                float width = 20;
                float height = 20;
                int x;
                int y;

                Color color = new Color();



                //DRAWING 4 SECTIONS WITH THEIR FIELDS, FINALS AND NESTS ===============================================================================

                for (int section = 0; section < 4; section++) //SECTIONS: 0=RED;1=GREEN;2=YELLOW;3=BLUE
                {
                    //ID to recognize a cell
                    int fieldsID = 0;
                    int finalsID = 0;

                    //params for circles (base for nests in which pieces will be placed)
                    float centerX;
                    float centerY;

                    float radius;
                    float radius2; // for white inner circle 


                    //params for finish

                    int x_finish = 470;
                    int y_finish = 320;
                    int radius_finish = 15;


                    if (section == 0)
                    {
                        // gameboard´s cells

                        x = 430; //xDefault = 430;
                        y = 280; //yDefault = 280;
                        color = Colors.Red;

                        //base for nest in RED section
                        centerX = 620;
                        centerY = 205;
                        radius = 75;
                        radius2 = radius - 20;

                        //finish´s cells 
                        x_finish = 470;
                        y_finish = 320;


                    }
                    else if (section == 1)
                    {
                        x = 520; //xDefault = 520;
                        y = 300; //yDefault = 300;
                        color = Colors.Green;

                        //base for nest in GREEN section
                        centerX = 620;
                        centerY = 480;
                        radius = 75;
                        radius2 = radius - 20;


                        //finish´s cells 
                        x_finish = 500;
                        y_finish = 340;

                    }
                    else if (section == 2)
                    {
                        x = 490; //xDefault = 490;
                        y = 380; //yDefault = 380;
                        color = Colors.Yellow;

                        //base for nest in YELLOW section
                        centerX = 320;
                        centerY = 480;
                        radius = 75;
                        radius2 = radius - 20;


                        //finish´s cells 
                        x_finish = 470;
                        y_finish = 360;
                    }
                    else
                    {
                        x = 400; //xDefault = 400;
                        y = 360; //yDefault = 360;
                        color = Colors.Blue;

                        //base for nest in BLUE section
                        centerX = 320;
                        centerY = 205;
                        radius = 75;
                        radius2 = radius - 20;

                        //finish´s cells 
                        x_finish = 440;
                        y_finish = 340;
                    }

                    // 13 fields and 5 finals in every section
                    for (int raw = 0; raw < 3; raw++)
                    {
                        for (int field = 0; field < 6; field++)
                        {
                            if (raw == 0)// here only white fields
                            {
                                //front end
                                dSession.FillRectangle(x, y, width, height, Colors.White);
                                int[] cellsCoordinates = new int[] { x, y };

                                if (section == 0) y -= 30;
                                if (section == 1) x += 30;
                                if (section == 2) y += 30;
                                if (section == 3) x -= 30;


                                //back end  
                                Cell fieldCell = new Cell(section, ++fieldsID, false, cellsCoordinates);
                                gameBoardCells.Add(fieldCell);

                            }
                            if (raw == 1)
                            {
                                if (field == 0)
                                {
                                    //front end
                                    dSession.FillRectangle(x, y, width, height, Colors.White);
                                    int[] cellsCoordinates = new int[] { x, y };

                                    if (section == 0) y += 30;
                                    if (section == 1) x -= 30;
                                    if (section == 2) y -= 30;
                                    if (section == 3) x += 30;

                                    //back end

                                    Cell fieldCell = new Cell(section, ++fieldsID, false, cellsCoordinates);
                                    gameBoardCells.Add(fieldCell);

                                }
                                if (field > 0)
                                {
                                    //front end
                                    dSession.FillRectangle(x, y, width, height, color);
                                    int[] cellsCoordinates = new int[] { x, y };

                                    if (section == 0) y += 30;
                                    if (section == 1) x -= 30;
                                    if (section == 2) y -= 30;
                                    if (section == 3) x += 30;


                                    //back end                                   
                                    Cell finalCell = new Cell(section, ++finalsID, true, cellsCoordinates);
                                    gameBoardCells.Add(finalCell);

                                }

                            }
                            if (raw == 2)
                            {
                                dSession.FillRectangle(x, y, width, height, Colors.White);
                                int[] cellsCoordinates = new int[] { x, y };


                                if (section == 0) y += 30;
                                if (section == 1) x -= 30;
                                if (section == 2) y -= 30;
                                if (section == 3) x += 30;

                                //back end     
                                Cell fieldCell = new Cell(section, ++fieldsID, false, cellsCoordinates);
                                gameBoardCells.Add(fieldCell);

                            }
                        }

                        if (section == 0)
                        {
                            x += 30;
                            y = 130;
                        }
                        if (section == 1)
                        {
                            y += 30;
                            x = 670;
                        }
                        if (section == 2)
                        {
                            x -= 30;
                            y = 530;
                        }
                        if (section == 3)
                        {
                            y -= 30;
                            x = 250;
                        }
                    }




                   
                    // front-end for finishCell
                    dSession.FillCircle(x_finish, y_finish, radius_finish, color);

                    //back end for finish cell
                    int[] finish_coordinates = new int[] { x_finish, y_finish };
                    Cell finishCell = new Cell(section, 6, true, finish_coordinates);
                    gameBoardCells.Add(finishCell);



                    //1 NEST IN EVERY SECTION.
                    //THE NEST CONTAINS 4 CELLS.
                    //THE CELLS MAY ONLY CONTAIN ONE PIECE EACH 

                    //circle background for the respective nest
                    dSession.FillCircle(centerX, centerY, radius, color); // outer colored circle
                    dSession.FillCircle(centerX, centerY, radius2, Colors.White); //inner circle



                    //4 cells in every nest; once game starts => every cell gets one piece
                    //(the pieces are moved from nest to the fields => finals => finish)

                    for (int nestCellsID = -1; nestCellsID >= -4; nestCellsID--)
                    {

                        //front end
                        int coordX = (int)centerX;
                        int coordY = (int)centerY;

                        if (nestCellsID == -1)
                        {
                            coordX = (int)centerX - 25;
                            coordY = (int)centerY - 25;
                        }
                        if (nestCellsID == -2)
                        {
                            coordX = (int)centerX + 25;
                            coordY = (int)centerY - 25;
                        }
                        if (nestCellsID == -3)
                        {
                            coordX = (int)centerX - 25;
                            coordY = (int)centerY + 25;
                        }
                        if (nestCellsID == -4)
                        {
                            coordX = (int)centerX + 25;
                            coordY = (int)centerY + 25;
                        }

                        dSession.FillCircle(coordX, coordY, radius - 60, color); //cell with a negative ID that shows that a cell belongs to nest.
                        dSession.FillCircle(coordX, coordY, radius - 80, Colors.Black); // a piece(a dot so far) that will be navigated throughout the gameboard.


                        //back end
                        int[] coordinates = new int[] { coordX, coordY };

                        Cell nestCellObj = new Cell(section, nestCellsID, false, coordinates);
                        nestCellObj.PiecesVisiting = new List<Piece>();


                        gameBoardCells.Add(nestCellObj);
                    }


                }
                args.DrawingSession.DrawImage(renderTarget);
            }
            gameBoard.GameCells = gameBoardCells;


            //TESTER

            //int count = 0;
            //foreach (Cell cell in gameBoard.GameCells)
            //{
            //    if (cell.Id == 6 && cell.IsFinal == true) count++;
            //}
            //Debug.WriteLine(count.ToString());
        }
    }
}
