﻿using LUDO.Helpers;
using LUDO.Commands;
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
        private Color _color;
        private int _colorInt;
        private bool _isTurnToRoll;
        private List<Piece> _pieces;

        private bool _isHighlighted;
        public bool IsHighlighted
        {
            get { return _isHighlighted; }
            set { _isHighlighted = value; }
        }

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

        public Player(string name, Color color)
        {
            _isHighlighted = false;
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
        /*
        public void PieceCommand(int diceResult)
        {
            if (diceResult == 6)
            {
                foreach (var piece in Pieces)
                {
                    if (piece.PieceInNest)  // Antag att IsInNest är en egenskap i Piece-klassen som indikerar om pjäsen är i boet
                    {
                        Piece.IsHighlighted = true;
                    }
                }
            }
        }
        */
    }
}