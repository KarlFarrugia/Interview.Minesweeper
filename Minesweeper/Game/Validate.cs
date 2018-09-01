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
        /// Trys to get the board settings. If a on numeric value is found an exception is thrown. After successfully
        /// parsing the board settings the <see cref="ValidateBoard"/> method is called.
        /// </summary>
        /// <param name="settings">The settings of the board to be parsed</param>
        /// <returns>a list of board settings</returns>
        /// <exception cref="Exception">Throws an exception if a type mismatch is found</exception>
        public static List<int> ValidateBoardSettings(string settings)
        {
            try
            {
                var boardSettings = settings.Split(' ').Select(int.Parse).ToList();
                ValidateBoard(boardSettings);
                return boardSettings;
            }
            catch (Exception)
            {
                throw new Exception("Non numeric game specifications");
            }
        }
        
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
            
            BoardLength = boardSettings.ElementAt(0);
            BoardWidth = boardSettings.ElementAt(1);
            //checks board settings are both greater than 0
            if (BoardLength < 0 || BoardWidth < 0) throw new Exception("Invalid board parameters");           
        }
        
        /// <summary>
        /// Checks if a given set of coordinates lie within the box or outside of it.
        /// </summary>
        /// <param name="coordinates">The <see cref="Coordinates"/> to be checked</param>
        /// <returns>Returns true if the coordinates lie within the box and false otherwise</returns>
        public bool ValidBox(Coordinates coordinates)
        {
            return coordinates.CoordinateX >= 0 && coordinates.CoordinateY >= 0 && 
                   coordinates.CoordinateX < BoardLength && coordinates.CoordinateY < BoardWidth;
        }

        /// <summary>
        /// Checks that the specified board length and the length specification match
        /// </summary>
        /// <param name="length">The length of lines of specifications</param>
        /// <exception cref="Exception">An exception is thrown if the specified length and actual found length do not
        ///                             match</exception>
        public void ValidateLength(int length)
        {
            if (length != BoardLength) throw new Exception("Specified and actual length do not match");
        }
        
        /// <summary>
        /// Checks that the specified board width and the width specification match
        /// </summary>
        /// <param name="width">The width of a line of specifications</param>
        /// <exception cref="Exception">An exception is thrown if the specified width and actual found width do not
        ///                             match</exception>
        public void ValidateWidth(int width)
        {
            if (width != BoardWidth) throw new Exception("Specified and actual width do not match");
        }

        /// <summary>
        /// Checks that the set of lines to be tested exist
        /// </summary>
        /// <param name="lines">The string of lines to be parsed</param>
        /// <exception cref="Exception">If the number of lines is 0 or a null object a wrong EOF is reached.</exception>
        public static void InitialFileLine(List<string> lines)
        {
            if (lines == null || lines.Count == 0) throw new Exception("Wrong EOF format");
        }
    }
}