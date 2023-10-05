using LUDO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.ViewModels
{
    internal class GameBoardViewModel : ViewModelBase
    {
        private string _textStorlek;

        public string TextStorlek {  
            get { return _textStorlek;}
            set { if (value != _textStorlek) 
                { 
                    _textStorlek = value;
                    OnPropertyChanged(nameof(TextStorlek));
                };
            }
        }

        public GameBoardViewModel( ) 
        {
            this._textStorlek = "25";
            Location nest = new Location(new List<Piece>(), Helpers.TypeOfLocation.Nest);
        }
    }
}
