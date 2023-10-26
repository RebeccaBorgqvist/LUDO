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
using System.Threading;

namespace LUDO.Models
{
    /// <summary>
    /// The class that allows to roll the dice. 
    /// Returns the rollResult and the appropriate image of the dice
    /// </summary>
    public class Dice
    {
        public static Dice Instance { get; private set; }

        public Dice()
        {
            Instance = this;
        }

        public (int RollResult, string ImagePath) DiceRoll()
        {
            Random random = new Random();
            int rollResult = random.Next(1, 7);
            string imagePath = $"ms-appx:///Assets/{rollResult}.png";

            return (rollResult, imagePath);
        }
    }
}

