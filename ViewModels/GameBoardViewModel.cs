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
        public ICommand RollDiceCommand { get; set; }
        public ICommand StartGameCommand { get; set; }
        public CanvasControl GameBoardCanvas { get; set; } //property for building game board (win2d class)
        public static GameBoardViewModel Instance { get; private set; }

        private Dice _diceModel;
        private int _diceResult;
        private Board _boardModel = new Board();
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
        private bool _redPiece2Visibility = false;
        private int _redPiece2CoordinateX;
        private int _redPiece2CoordinateY;
        private bool _greenPiece2Visibility = false;
        private int _greenPiece2CoordinateX;
        private int _greenPiece2CoordinateY;
        private bool _yellowPiece2Visibility = false;
        private int _yellowPiece2CoordinateX;
        private int _yellowPiece2CoordinateY;
        private bool _bluePiece2Visibility = false;
        private int _bluePiece2CoordinateX;
        private int _bluePiece2CoordinateY;
        private bool _redPiece3Visibility = false;
        private int _redPiece3CoordinateX;
        private int _redPiece3CoordinateY;
        private bool _greenPiece3Visibility = false;
        private int _greenPiece3CoordinateX;
        private int _greenPiece3CoordinateY;
        private bool _yellowPiece3Visibility = false;
        private int _yellowPiece3CoordinateX;
        private int _yellowPiece3CoordinateY;
        private bool _bluePiece3Visibility = false;
        private int _bluePiece3CoordinateX;
        private int _bluePiece3CoordinateY;
        private bool _redPiece4Visibility = false;
        private int _redPiece4CoordinateX;
        private int _redPiece4CoordinateY;
        private bool _greenPiece4Visibility = false;
        private int _greenPiece4CoordinateX;
        private int _greenPiece4CoordinateY;
        private bool _yellowPiece4Visibility = false;
        private int _yellowPiece4CoordinateX;
        private int _yellowPiece4CoordinateY;
        private bool _bluePiece4Visibility = false;
        private int _bluePiece4CoordinateX;
        private int _bluePiece4CoordinateY;

        private int _highlightCurrentCoordinateX; 
        private int _highlightCurrentCoordinateY;
        private int _highlightVisualizedCoordinateX;
        private int _highlightVisualizedCoordinateY;
        public int DiceResult { get; set; }
        public bool RedPiece1Visibility 
        {
            get { return _redPiece1Visibility;}
            set { 
                _redPiece1Visibility = value;
                OnPropertyChanged(nameof(RedPiece1Visibility));
            }
        }
        public int RedPiece1CoordinateX 
        {
            get { return _redPiece1CoordinateX; }
            set { 
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
        public bool RedPiece2Visibility
        {
            get { return _redPiece2Visibility; }
            set
            {
                _redPiece2Visibility = value;
                OnPropertyChanged(nameof(RedPiece2Visibility));
            }
        }
        public int RedPiece2CoordinateX
        {
            get { return _redPiece2CoordinateX; }
            set
            {
                _redPiece2CoordinateX = value;
                OnPropertyChanged(nameof(RedPiece2CoordinateX));
            }
        }
        public int RedPiece2CoordinateY
        {
            get { return _redPiece2CoordinateY; }
            set
            {
                _redPiece2CoordinateY = value;
                OnPropertyChanged(nameof(RedPiece2CoordinateY));
            }
        }
        public bool GreenPiece2Visibility
        {
            get { return _greenPiece2Visibility; }
            set
            {
                _greenPiece2Visibility = value;
                OnPropertyChanged(nameof(GreenPiece2Visibility));
            }
        }
        public int GreenPiece2CoordinateX
        {
            get { return _greenPiece2CoordinateX; }
            set
            {
                _greenPiece2CoordinateX = value;
                OnPropertyChanged(nameof(GreenPiece2CoordinateX));
            }
        }
        public int GreenPiece2CoordinateY
        {
            get { return _greenPiece2CoordinateY; }
            set
            {
                _greenPiece2CoordinateY = value;
                OnPropertyChanged(nameof(GreenPiece2CoordinateY));
            }
        }
        public bool YellowPiece2Visibility
        {
            get { return _yellowPiece2Visibility; }
            set
            {
                _yellowPiece2Visibility = value;
                OnPropertyChanged(nameof(YellowPiece2Visibility));
            }
        }
        public int YellowPiece2CoordinateX
        {
            get { return _yellowPiece2CoordinateX; }
            set
            {
                _yellowPiece2CoordinateX = value;
                OnPropertyChanged(nameof(YellowPiece2CoordinateX));
            }
        }
        public int YellowPiece2CoordinateY
        {
            get { return _yellowPiece2CoordinateY; }
            set
            {
                _yellowPiece2CoordinateY = value;
                OnPropertyChanged(nameof(YellowPiece2CoordinateY));
            }
        }
        public bool BluePiece2Visibility
        {
            get { return _bluePiece2Visibility; }
            set
            {
                _bluePiece2Visibility = value;
                OnPropertyChanged(nameof(BluePiece2Visibility));
            }
        }
        public int BluePiece2CoordinateX
        {
            get { return _bluePiece2CoordinateX; }
            set
            {
                _bluePiece2CoordinateX = value;
                OnPropertyChanged(nameof(BluePiece2CoordinateX));
            }
        }
        public int BluePiece2CoordinateY
        {
            get { return _bluePiece2CoordinateY; }
            set
            {
                _bluePiece2CoordinateY = value;
                OnPropertyChanged(nameof(BluePiece2CoordinateY));
            }
        }
        public bool RedPiece3Visibility
        {
            get { return _redPiece3Visibility; }
            set
            {
                _redPiece3Visibility = value;
                OnPropertyChanged(nameof(RedPiece3Visibility));
            }
        }
        public int RedPiece3CoordinateX
        {
            get { return _redPiece3CoordinateX; }
            set
            {
                _redPiece3CoordinateX = value;
                OnPropertyChanged(nameof(RedPiece3CoordinateX));
            }
        }
        public int RedPiece3CoordinateY
        {
            get { return _redPiece3CoordinateY; }
            set
            {
                _redPiece3CoordinateY = value;
                OnPropertyChanged(nameof(RedPiece3CoordinateY));
            }
        }
        public bool GreenPiece3Visibility
        {
            get { return _greenPiece3Visibility; }
            set
            {
                _greenPiece3Visibility = value;
                OnPropertyChanged(nameof(GreenPiece3Visibility));
            }
        }
        public int GreenPiece3CoordinateX
        {
            get { return _greenPiece3CoordinateX; }
            set
            {
                _greenPiece3CoordinateX = value;
                OnPropertyChanged(nameof(GreenPiece3CoordinateX));
            }
        }
        public int GreenPiece3CoordinateY
        {
            get { return _greenPiece3CoordinateY; }
            set
            {
                _greenPiece3CoordinateY = value;
                OnPropertyChanged(nameof(GreenPiece3CoordinateY));
            }
        }
        public bool YellowPiece3Visibility
        {
            get { return _yellowPiece3Visibility; }
            set
            {
                _yellowPiece3Visibility = value;
                OnPropertyChanged(nameof(YellowPiece3Visibility));
            }
        }
        public int YellowPiece3CoordinateX
        {
            get { return _yellowPiece3CoordinateX; }
            set
            {
                _yellowPiece3CoordinateX = value;
                OnPropertyChanged(nameof(YellowPiece3CoordinateX));
            }
        }
        public int YellowPiece3CoordinateY
        {
            get { return _yellowPiece3CoordinateY; }
            set
            {
                _yellowPiece3CoordinateY = value;
                OnPropertyChanged(nameof(YellowPiece3CoordinateY));
            }
        }
        public bool BluePiece3Visibility
        {
            get { return _bluePiece3Visibility; }
            set
            {
                _bluePiece3Visibility = value;
                OnPropertyChanged(nameof(BluePiece3Visibility));
            }
        }
        public int BluePiece3CoordinateX
        {
            get { return _bluePiece3CoordinateX; }
            set
            {
                _bluePiece3CoordinateX = value;
                OnPropertyChanged(nameof(BluePiece3CoordinateX));
            }
        }
        public int BluePiece3CoordinateY
        {
            get { return _bluePiece3CoordinateY; }
            set
            {
                _bluePiece3CoordinateY = value;
                OnPropertyChanged(nameof(BluePiece3CoordinateY));
            }
        }
        public bool RedPiece4Visibility
        {
            get { return _redPiece4Visibility; }
            set
            {
                _redPiece4Visibility = value;
                OnPropertyChanged(nameof(RedPiece4Visibility));
            }
        }
        public int RedPiece4CoordinateX
        {
            get { return _redPiece4CoordinateX; }
            set
            {
                _redPiece4CoordinateX = value;
                OnPropertyChanged(nameof(RedPiece4CoordinateX));
            }
        }
        public int RedPiece4CoordinateY
        {
            get { return _redPiece4CoordinateY; }
            set
            {
                _redPiece4CoordinateY = value;
                OnPropertyChanged(nameof(RedPiece4CoordinateY));
            }
        }
        public bool GreenPiece4Visibility
        {
            get { return _greenPiece4Visibility; }
            set
            {
                _greenPiece4Visibility = value;
                OnPropertyChanged(nameof(GreenPiece4Visibility));
            }
        }
        public int GreenPiece4CoordinateX
        {
            get { return _greenPiece4CoordinateX; }
            set
            {
                _greenPiece4CoordinateX = value;
                OnPropertyChanged(nameof(GreenPiece4CoordinateX));
            }
        }
        public int GreenPiece4CoordinateY
        {
            get { return _greenPiece4CoordinateY; }
            set
            {
                _greenPiece4CoordinateY = value;
                OnPropertyChanged(nameof(GreenPiece4CoordinateY));
            }
        }
        public bool YellowPiece4Visibility
        {
            get { return _yellowPiece4Visibility; }
            set
            {
                _yellowPiece4Visibility = value;
                OnPropertyChanged(nameof(YellowPiece4Visibility));
            }
        }
        public int YellowPiece4CoordinateX
        {
            get { return _yellowPiece4CoordinateX; }
            set
            {
                _yellowPiece4CoordinateX = value;
                OnPropertyChanged(nameof(YellowPiece4CoordinateX));
            }
        }
        public int YellowPiece4CoordinateY
        {
            get { return _yellowPiece4CoordinateY; }
            set
            {
                _yellowPiece4CoordinateY = value;
                OnPropertyChanged(nameof(YellowPiece4CoordinateY));
            }
        }
        public bool BluePiece4Visibility
        {
            get { return _bluePiece4Visibility; }
            set
            {
                _bluePiece4Visibility = value;
                OnPropertyChanged(nameof(BluePiece4Visibility));
            }
        }
        public int BluePiece4CoordinateX
        {
            get { return _bluePiece4CoordinateX; }
            set
            {
                _bluePiece4CoordinateX = value;
                OnPropertyChanged(nameof(BluePiece4CoordinateX));
            }
        }
        public int BluePiece4CoordinateY
        {
            get { return _bluePiece4CoordinateY; }
            set
            {
                _bluePiece4CoordinateY = value;
                OnPropertyChanged(nameof(BluePiece4CoordinateY));
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
        private Visibility _startButtonVisibility;
        public Visibility StartButtonVisibility
        {
            get { return _startButtonVisibility; }
            set
            {
                if (value != _startButtonVisibility)
                {
                    _startButtonVisibility = value;
                    OnPropertyChanged(nameof(StartButtonVisibility));
                }
            }
        }

        public Dice DiceModel
        {
            get { return _diceModel; }
            set { _diceModel = value; }
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
            
            RollDiceCommand = new RollDiceCommand();
            StartGameCommand = new StartGameCommand();

            CurrentDiceImage = "ms-appx:///Assets/roll_dice.png";
        }

        public void CreateGame()
        {
            _diceModel = new Dice();
            _gameLogicModel = new GameLogic();
            //_gameLogicModel.SetPlayerColor();
            //_gameLogicModel.CreatePlayerOrder();

            _gameLogicModel.SetPlayerList();
            _gameLogicModel.CreatePlayerPieces();
            _gameLogicModel.StartGame();
        }

        public void ShowPieceOnBoard(Helpers.Color pieceColor, bool visibility, int pieceId, int[] pieceCoordinates)
        {
            if(pieceColor == Helpers.Color.Red)
            {
                switch (pieceId)
                {
                    case 1:
                        RedPiece1Visibility = visibility;
                        RedPiece1CoordinateX = pieceCoordinates[0];
                        RedPiece1CoordinateY = pieceCoordinates[1];
                        break;
                    case 2:
                        RedPiece2Visibility = visibility;
                        RedPiece2CoordinateX = pieceCoordinates[0];
                        RedPiece2CoordinateY = pieceCoordinates[1];
                        break;
                    case 3:
                        RedPiece3Visibility = visibility;
                        RedPiece3CoordinateX = pieceCoordinates[0];
                        RedPiece3CoordinateY = pieceCoordinates[1];
                        break;
                    case 4:
                        RedPiece4Visibility = visibility;
                        RedPiece4CoordinateX = pieceCoordinates[0];
                        RedPiece4CoordinateY = pieceCoordinates[1];
                        break;
                }
            }
            else if (pieceColor == Helpers.Color.Green)
            {
                switch (pieceId)
                {
                    case 1:
                        GreenPiece1Visibility = visibility;
                        GreenPiece1CoordinateX = pieceCoordinates[0];
                        GreenPiece1CoordinateY = pieceCoordinates[1];
                        break;
                    case 2:
                        GreenPiece2Visibility = visibility;
                        GreenPiece2CoordinateX = pieceCoordinates[0];
                        GreenPiece2CoordinateY = pieceCoordinates[1];
                        break;
                    case 3:
                        GreenPiece3Visibility = visibility;
                        GreenPiece3CoordinateX = pieceCoordinates[0];
                        GreenPiece3CoordinateY = pieceCoordinates[1];
                        break;
                    case 4:
                        GreenPiece4Visibility = visibility;
                        GreenPiece4CoordinateX = pieceCoordinates[0];
                        GreenPiece4CoordinateY = pieceCoordinates[1];
                        break;
                }
            }
            else if (pieceColor == Helpers.Color.Yellow)
            {
                switch (pieceId)
                {
                    case 1:
                        YellowPiece1Visibility = visibility;
                        YellowPiece1CoordinateX = pieceCoordinates[0];
                        YellowPiece1CoordinateY = pieceCoordinates[1];
                        break;
                    case 2:
                        YellowPiece2Visibility = visibility;
                        YellowPiece2CoordinateX = pieceCoordinates[0];
                        YellowPiece2CoordinateY = pieceCoordinates[1];
                        break;
                    case 3:
                        YellowPiece3Visibility = visibility;
                        YellowPiece3CoordinateX = pieceCoordinates[0];
                        YellowPiece3CoordinateY = pieceCoordinates[1];
                        break;
                    case 4:
                        YellowPiece4Visibility = visibility;
                        YellowPiece4CoordinateX = pieceCoordinates[0];
                        YellowPiece4CoordinateY = pieceCoordinates[1];
                        break;
                }
            }
            else
            {
                switch (pieceId)
                {
                    case 1:
                        BluePiece1Visibility = visibility;
                        BluePiece1CoordinateX = pieceCoordinates[0];
                        BluePiece1CoordinateY = pieceCoordinates[1];
                        break;
                    case 2:
                        BluePiece2Visibility = visibility;
                        BluePiece2CoordinateX = pieceCoordinates[0];
                        BluePiece2CoordinateY = pieceCoordinates[1];
                        break;
                    case 3:
                        BluePiece3Visibility = visibility;
                        BluePiece3CoordinateX = pieceCoordinates[0];
                        BluePiece3CoordinateY = pieceCoordinates[1];
                        break;
                    case 4:
                        BluePiece4Visibility = visibility;
                        BluePiece4CoordinateX = pieceCoordinates[0];
                        BluePiece4CoordinateY = pieceCoordinates[1];
                        break;
                }
            }
        }
        public static void Highlighting(int xNuvarande, int yNuvarande, int newCoordinateInX, int newCoordinateInY)
        {
            Instance.HighlightCurrentCoordinateX = xNuvarande;
            Instance.HighlightCurrentCoordinateY = yNuvarande;
            Instance.HighlightVisualizedCoordinateX = newCoordinateInX;
            Instance.HighlightVisualizedCoordinateY = newCoordinateInY;
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
                        //dSession.FillCircle(coordX, coordY, radius - 80, Colors.Black); // a piece(a dot so far) that will be navigated throughout the gameboard.

                        //back end
                        int[] coordinates = new int[] { coordX, coordY };

                        Cell nestCellObj = new Cell(section, nestCellsID, false, coordinates);
                        //nestCellObj.PiecesVisiting = new List<Piece>();

                        gameBoardCells.Add(nestCellObj);
                    }
                }
                args.DrawingSession.DrawImage(renderTarget);
            }
            BoardModel.GameCells = gameBoardCells;
        }
    }
}
