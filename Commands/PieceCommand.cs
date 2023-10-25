using LUDO.ViewModels;
using LUDO.Helpers;
using LUDO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Commands
{
    internal class PieceCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            if (Piece.Instance != null)
            {
                var highlightPieceStoryboard = Piece.Instance.HighlightPieceStoryboard;
            }
        }
    }
}
