using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.Models
{
    internal class Board
    {
        private List<Cell> _gameCells;        

        public List<Cell> GameCells 
        {
            get { return _gameCells; }
            set { _gameCells = value; } 
        }

        public Board()
        {
            _gameCells = new List<Cell>() 
            {
                new Cell(0, -1 , false, new int[] { 400, 50 }),
                new Cell(0, -2 , false, new int[] { 430, 50 }),
                new Cell(0, -3 , false, new int[] { 400, 80 }),
                new Cell(0, -4 , false, new int[] { 430, 80 }),
                new Cell(1, -1 , false, new int[] { 400, 400 }),
                new Cell(1, -2 , false, new int[] { 430, 400 }),
                new Cell(1, -3 , false, new int[] { 400, 430 }),
                new Cell(1, -4 , false, new int[] { 430, 430 }),
                new Cell(2, -1 , false, new int[] { 50, 400 }),
                new Cell(2, -2 , false, new int[] { 80, 400 }),
                new Cell(2, -3 , false, new int[] { 50, 430 }),
                new Cell(2, -4 , false, new int[] { 80, 430 }),
                new Cell(3, -1 , false, new int[] { 50, 50 }),
                new Cell(3, -2 , false, new int[] { 80, 50 }),
                new Cell(3, -3 , false, new int[] { 50, 80 }),
                new Cell(3, -4 , false, new int[] { 80, 80 }),
            };
        }


    }
}
