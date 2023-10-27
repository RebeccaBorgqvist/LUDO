using LUDO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace LUDO.Models
{
    /// <summary>
    /// The class that is responsible for a player and its object for the game
    /// </summary>
    internal class Player
    {
        private string _name;
        private Color _color;
        private int _colorInt;
        private bool _isTurnToRoll;
        private List<Piece> _pieces;

        public Piece SelectedPiece { get; set; }

        public string Name { get { return _name; } set { _name = value; } }
        public Color Color { get { return _color; } set { _color = value; } }
        public int ColorInt { get { return _colorInt; } private set { _colorInt = value; } }
        public bool IsTurnToRoll
        {
            get { return _isTurnToRoll; }
            set { _isTurnToRoll = value; }
        }
        public List<Piece> Pieces
        {
            get { return _pieces; }
            set { _pieces = value; }
        }

        public Player(string name, Color color = Color.Black)
        {
            _name = name;
            _color = color;
            _colorInt = (int)color;
            _isTurnToRoll = false;
        }

        /// <summary>
        /// The method that creates pieces for the player. Every player gets 4 pieces 
        /// </summary>
        public void CreatePieces()
        {
            _pieces = new List<Piece>()
            {
                new Piece(Color, 1),
                new Piece(Color, 2),
                new Piece(Color, 3),
                new Piece(Color, 4)
            };
        }
    }
}