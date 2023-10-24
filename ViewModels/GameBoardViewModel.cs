using LUDO.Models;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using LUDO.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace LUDO.ViewModels
{
    internal class GameBoardViewModel : ViewModelBase
    {
        public GameLogic GameLogicInstance { get; set; }
        public Helpers.Color CurrentPlayerColor { get; set; }
        //public ICommand PieceCommand { get; set; }

        public ICommand RollDiceCommand { get; set; }
        public CanvasControl GameBoardCanvas { get; set; } //property for building game board (win2d class)
        public static GameBoardViewModel Instance { get; private set; }
        private Dice _diceModel;
        private int _diceResult;
        private Board _boardModel;
        private GameLogic _gameLogicModel; //not sure so far if we are required this later on :/
        private string _currentDiceImage;

        private bool _redPiece1Visibility = false;
        private int _redPiece1CoordinateX;
        private int _redPiece1CoordinateY;

        private bool _greenPiece1Visibility = false;
        private int _greenPiece1CoordinateX;
        private int _greenPiece1CoordinateY;

        private bool _yellowPiece1Visibility = false;
        private int _yellowPiece1CoordinateX;
        private int _yellowPiece1CoordinateY;

        private bool _bluePiece1Visibility = false;
        private int _bluePiece1CoordinateX;
        private int _bluePiece1CoordinateY;

        private int _highlightCurrentCoordinateX;
        private int _highlightCurrentCoordinateY;

        private int _highlightVisualizedCoordinateX;
        private int _highlightVisualizedCoordinateY;

        private bool _diceVisibilityYellow;
        private bool _diceVisibilityGreen;
        private bool _diceVisibilityRed;
        private bool _diceVisibilityBlue;

        private Player _currentPlayer;
        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
                OnPropertyChanged(nameof(DiceVisibilityBlue));
                OnPropertyChanged(nameof(DiceVisibilityRed));
                OnPropertyChanged(nameof(DiceVisibilityGreen));
                OnPropertyChanged(nameof(DiceVisibilityYellow));
            }
        }
        public int DiceResult { get; set; }

        public bool RedPiece1Visibility
        {
            get { return _redPiece1Visibility; }
            set
            {
                _redPiece1Visibility = value;
                OnPropertyChanged(nameof(RedPiece1Visibility));
            }
        }
        public int RedPiece1CoordinateX
        {
            get { return _redPiece1CoordinateX; }
            set
            {
                _redPiece1CoordinateX = value;
                OnPropertyChanged(nameof(RedPiece1CoordinateX));
            }
        }
        public int RedPiece1CoordinateY
        {
            get { return _redPiece1CoordinateY; }
            set
            {
                _redPiece1CoordinateY = value;
                OnPropertyChanged(nameof(RedPiece1CoordinateY));
            }
        }
        public bool GreenPiece1Visibility
        {
            get { return _greenPiece1Visibility; }
            set
            {
                _greenPiece1Visibility = value;
                OnPropertyChanged(nameof(GreenPiece1Visibility));
            }
        }
        public int GreenPiece1CoordinateX
        {
            get { return _greenPiece1CoordinateX; }
            set
            {
                _greenPiece1CoordinateX = value;
                OnPropertyChanged(nameof(GreenPiece1CoordinateX));
            }
        }
        public int GreenPiece1CoordinateY
        {
            get { return _greenPiece1CoordinateY; }
            set
            {
                _greenPiece1CoordinateY = value;
                OnPropertyChanged(nameof(GreenPiece1CoordinateY));
            }
        }
        public bool YellowPiece1Visibility
        {
            get { return _yellowPiece1Visibility; }
            set
            {
                _yellowPiece1Visibility = value;
                OnPropertyChanged(nameof(YellowPiece1Visibility));
            }
        }
        public int YellowPiece1CoordinateX
        {
            get { return _yellowPiece1CoordinateX; }
            set
            {
                _yellowPiece1CoordinateX = value;
                OnPropertyChanged(nameof(YellowPiece1CoordinateX));
            }
        }
        public int YellowPiece1CoordinateY
        {
            get { return _yellowPiece1CoordinateY; }
            set
            {
                _yellowPiece1CoordinateY = value;
                OnPropertyChanged(nameof(YellowPiece1CoordinateY));
            }
        }
        public bool BluePiece1Visibility
        {
            get { return _bluePiece1Visibility; }
            set
            {
                _bluePiece1Visibility = value;
                OnPropertyChanged(nameof(BluePiece1Visibility));
            }
        }
        public int BluePiece1CoordinateX
        {
            get { return _bluePiece1CoordinateX; }
            set
            {
                _bluePiece1CoordinateX = value;
                OnPropertyChanged(nameof(BluePiece1CoordinateX));
            }
        }
        public int BluePiece1CoordinateY
        {
            get { return _bluePiece1CoordinateY; }
            set
            {
                _bluePiece1CoordinateY = value;
                OnPropertyChanged(nameof(BluePiece1CoordinateY));
            }
        }
        public int HighlightCurrentCoordinateX
        {
            get { return _highlightCurrentCoordinateX; }
            set
            {
                _highlightCurrentCoordinateX = value;
                OnPropertyChanged(nameof(HighlightCurrentCoordinateX));
            }
        }
        public int HighlightCurrentCoordinateY
        {
            get { return _highlightCurrentCoordinateY; }
            set
            {
                _highlightCurrentCoordinateY = value;
                OnPropertyChanged(nameof(HighlightCurrentCoordinateY));
            }
        }
        public int HighlightVisualizedCoordinateX
        {
            get { return _highlightVisualizedCoordinateX; }
            set
            {
                _highlightVisualizedCoordinateX = value;
                OnPropertyChanged(nameof(HighlightVisualizedCoordinateX));
            }
        }
        public int HighlightVisualizedCoordinateY
        {
            get { return _highlightVisualizedCoordinateY; }
            set
            {
                _highlightVisualizedCoordinateY = value;
                OnPropertyChanged(nameof(HighlightVisualizedCoordinateY));
            }
        }

        public Dice DiceModel
        {
            get { return _diceModel; }
            set { _diceModel = value; }
        }

        public bool DiceVisibilityBlue
        {
            get { return _diceVisibilityBlue; }
            set
            {
                _diceVisibilityBlue = value;
                OnPropertyChanged(nameof(DiceVisibilityBlue));
            }
        }

        public bool DiceVisibilityRed
        {
            get { return _diceVisibilityRed; }
            set
            {
                _diceVisibilityRed = value;
                OnPropertyChanged(nameof(DiceVisibilityRed));
            }
        }

        public bool DiceVisibilityGreen
        {
            get { return _diceVisibilityGreen; }
            set
            {
                _diceVisibilityGreen = value;
                OnPropertyChanged(nameof(DiceVisibilityGreen));
            }
        }

        public bool DiceVisibilityYellow
        {
            get { return _diceVisibilityYellow; }
            set
            {
                _diceVisibilityYellow = value;
                OnPropertyChanged(nameof(DiceVisibilityYellow));
            }
        }

        public Board BoardModel
        {
            get { return _boardModel; }
            set { _boardModel = value; }
        }
        public GameLogic GameLogicModel
        {
            get { return _gameLogicModel; }
            set { _gameLogicModel = value; }
        }
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

        public GameBoardViewModel()
        {
            Instance = this;

            //PieceCommand = new PieceCommand();
            RollDiceCommand = new RollDiceCommand();
            GameLogicInstance = new GameLogic();
            _diceModel = new Dice();
            _boardModel = new Board();
            _gameLogicModel = new GameLogic();

            _gameLogicModel.CreatePlayerOrder();
            _gameLogicModel.StartGame();
            GameLogic.SetPlayerColor();

            CurrentDiceImage = "ms-appx:///Assets/roll_dice.png";
        }

        public void ShowPieceOnBoard(Helpers.Color pieceColor, int pieceCoordinateX, int pieceCoordinateY)
        {
            if (pieceColor == Helpers.Color.Red)
            {
                RedPiece1Visibility = true;
                RedPiece1CoordinateX = pieceCoordinateX;
                RedPiece1CoordinateY = pieceCoordinateY;
            }
            else if (pieceColor == Helpers.Color.Green)
            {
                GreenPiece1Visibility = true;
                GreenPiece1CoordinateX = pieceCoordinateX;
                GreenPiece1CoordinateY = pieceCoordinateY;
            }
            else if (pieceColor == Helpers.Color.Yellow)
            {
                YellowPiece1Visibility = true;
                YellowPiece1CoordinateX = pieceCoordinateX;
                YellowPiece1CoordinateY = pieceCoordinateY;
            }
            else
            {
                BluePiece1Visibility = true;
                BluePiece1CoordinateX = pieceCoordinateX;
                BluePiece1CoordinateY = pieceCoordinateY;
            }
        }

        public void MovePieceOnBoard(Helpers.Color pieceColor, int pieceCoordinateX, int pieceCoordinateY)
        {
            if (pieceColor == Helpers.Color.Red)
            {
                RedPiece1CoordinateX = pieceCoordinateX;
                RedPiece1CoordinateY = pieceCoordinateY;
            }
            else if (pieceColor == Helpers.Color.Green)
            {
                GreenPiece1CoordinateX = pieceCoordinateX;
                GreenPiece1CoordinateY = pieceCoordinateY;
            }
            else if (pieceColor == Helpers.Color.Yellow)
            {
                YellowPiece1CoordinateX = pieceCoordinateX;
                YellowPiece1CoordinateY = pieceCoordinateY;
            }
            else
            {
                BluePiece1CoordinateX = pieceCoordinateX;
                BluePiece1CoordinateY = pieceCoordinateY;
            }            
        }

        // Highlight for gameboard cells
        public static void Highlighting(int xNuvarande, int yNuvarande, int newCoordinateInX, int newCoordinateInY)
        {
            Instance.HighlightCurrentCoordinateX = xNuvarande;
            Instance.HighlightCurrentCoordinateY = yNuvarande;
            Instance.HighlightVisualizedCoordinateX = newCoordinateInX;
            Instance.HighlightVisualizedCoordinateY = newCoordinateInY;
        }

        public void HighlightValidPieces()
        {
            foreach (Piece piece in CurrentPlayer.Pieces)
            {
                if (piece.PieceInNest && DiceResult == 6)
                {
                    piece.HighlightValidPiece = true;
                }
                else if (!piece.PieceInNest)
                {
                    piece.HighlightValidPiece = true;
                }
                else
                {
                    piece.HighlightValidPiece = false;
                }
            }
        }

        //USAGE OF WIN2D API: DRAWING CELLS OF THE GAME BOARD(fields, finals, finish and nests)     
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

                //adjustment due to the space to the left and top
                int adjustmentInX = 244; //248
                int adjustmentInY = 130; //132

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
                        x = 430 - adjustmentInX; //xDefault = 430;
                        y = 280 - adjustmentInY; //yDefault = 280;
                        color = Colors.Red;

                        //base for nest in RED section
                        centerX = 620 - adjustmentInX;
                        centerY = 205 - adjustmentInY;
                        radius = 75;
                        radius2 = radius - 20;

                        //finish´s cells 
                        x_finish = 470 - adjustmentInX;
                        y_finish = 320 - adjustmentInY;
                    }
                    else if (section == 1)
                    {
                        x = 520 - adjustmentInX; //xDefault = 520;
                        y = 300 - adjustmentInY; //yDefault = 300;
                        color = Colors.Green;

                        //base for nest in GREEN section
                        centerX = 620 - adjustmentInX;
                        centerY = 480 - adjustmentInY;
                        radius = 75;
                        radius2 = radius - 20;

                        //finish´s cells 
                        x_finish = 500 - adjustmentInX;
                        y_finish = 340 - adjustmentInY;
                    }
                    else if (section == 2)
                    {
                        x = 490 - adjustmentInX; //xDefault = 490;
                        y = 380 - adjustmentInY; //yDefault = 380;
                        color = Colors.Yellow;

                        //base for nest in YELLOW section
                        centerX = 320 - adjustmentInX;
                        centerY = 480 - adjustmentInY;
                        radius = 75;
                        radius2 = radius - 20;

                        //finish´s cells 
                        x_finish = 470 - adjustmentInX;
                        y_finish = 360 - adjustmentInY;
                    }
                    else
                    {
                        x = 400 - adjustmentInX; //xDefault = 400;
                        y = 360 - adjustmentInY; //yDefault = 360;
                        color = Colors.Blue;

                        //base for nest in BLUE section
                        centerX = 320 - adjustmentInX;
                        centerY = 205 - adjustmentInY;
                        radius = 75;
                        radius2 = radius - 20;

                        //finish´s cells 
                        x_finish = 440 - adjustmentInX;
                        y_finish = 340 - adjustmentInY;
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
                            y = 130 - adjustmentInY;
                        }
                        if (section == 1)
                        {
                            y += 30;
                            x = 670 - adjustmentInX;
                        }
                        if (section == 2)
                        {
                            x -= 30;
                            y = 530 - adjustmentInY;
                        }
                        if (section == 3)
                        {
                            y -= 30;
                            x = 250 - adjustmentInX;
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

                        //back end
                        int[] coordinates = new int[] { coordX, coordY };

                        Cell nestCellObj = new Cell(section, nestCellsID, false, coordinates);
                        //nestCellObj.PiecesVisiting = new List<Piece>();

                        gameBoardCells.Add(nestCellObj);
                    }
                }
                args.DrawingSession.DrawImage(renderTarget);
            }
        }
    }
}
