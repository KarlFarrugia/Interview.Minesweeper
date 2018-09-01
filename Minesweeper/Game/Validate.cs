using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Game
{
    /// <summary>
    /// This class is used to validate different parts of the minesweeper game
    /// </summary>
    public class Validate
    {
        private static int BoardWidth { get; set; }
        private static int BoardLength { get; set; }
        
        /// <summary>
        /// This method checks that the given boardSettings are of a correct format otherwise it throws an exception.
        /// </summary>
        /// <param name="boardSettings">Is supposed to represent a list of 2 integers representing the
        /// <see cref="BoardWidth"/> and the <see cref="BoardLength"/></param>
        /// <exception cref="Exception">Is thrown if the given board settings are not correct</exception>
        public static void ValidateBoard (List<int> boardSettings)
        {
            //checks that the board settings contains just 2 values; the length and width of the board
            if (boardSettings.Count != 2) throw new Exception("Invalid game settings");   
            
            BoardWidth = boardSettings.ElementAt(0);
            BoardLength = boardSettings.ElementAt(1);
            //checks board settings are both greater than 0
            if (BoardLength < 0 || BoardWidth < 0) throw new Exception("Invalid board parameters");           
        }
        
        /// <summary>
        /// Checks if a given set of coordinates lie within the box or outside of it.
        /// </summary>
        /// <param name="coordinates">The <see cref="Coordinates"/> to be checked</param>
        /// <returns>Returns true if the coordinates lie within the box and false otherwise</returns>
        public static bool ValidBox(Coordinates coordinates)
        {
            return coordinates.CoordinateX >= 0 && coordinates.CoordinateY >= 0 && 
                   coordinates.CoordinateX < BoardWidth && coordinates.CoordinateY < BoardLength;
        }
    }
}