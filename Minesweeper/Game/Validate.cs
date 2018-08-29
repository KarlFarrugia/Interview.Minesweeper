using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Game
{
    public class Validate
    {
        
        private int BoardWidth { get; set; }
        private int BoardLength { get; set; }
        
        public void ValidateBoard (List<int> boardSettings)
        {
            BoardWidth = boardSettings.ElementAt(0);
            BoardLength = boardSettings.ElementAt(1);
            //checks board settings are both greater than 0
            if (BoardLength < 0 || BoardWidth < 0) throw new Exception("Invalid board parameters");           
        }
        
        public static bool ValidBox(Coordinates coordinates)
        {
            return true;
        }       
    }
}