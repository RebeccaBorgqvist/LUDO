using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
using LUDO.Commands;
using LUDO.ViewModels;
using Windows.UI.Popups;

namespace LUDO.Models
{
    internal class Dice
    {
        public static (int RollResult, string ImagePath) RollDice()
        {
            Random random = new Random();
            int rollResult = random.Next(1, 7);
            string imagePath = $"ms-appx:///Assets/{rollResult}.png";
            return (rollResult, imagePath);
        }
    }
}

