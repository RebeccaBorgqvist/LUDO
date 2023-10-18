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

        private bool _isTurnToRoll;


        public bool IsTurnToRoll
        {
            get { return _isTurnToRoll; }
            set { _isTurnToRoll = value; }
        }

        public string Name { get { return _name; } set { _name = value; } }


        public Player(string name)
        {
            _name = name;
            _isTurnToRoll = false;
        }
    }
}
