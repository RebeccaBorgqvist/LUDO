using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class Player
    {
        private string _name;
        private Helpers.Color _color;
        private int _colorInt;
        private bool _isTurnToRoll;
        private List<Piece> _pieces;

        public string Name { get { return _name; } set { _name = value; } }
        public Helpers.Color Color { get { return _color; } set { _color = value; } }
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

        public Player(string name, Helpers.Color color)
        {
            _name = name;
            _color = color;
            _colorInt = (int)color;
            _isTurnToRoll = false;
            _pieces = new List<Piece>()
            {
                new Piece(color),
                new Piece(color),
                new Piece(color),
                new Piece(color)
            };
        }
    }
}