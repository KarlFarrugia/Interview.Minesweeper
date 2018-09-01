using System;

namespace Minesweeper.Game
{
    /// <summary>
    /// The Printer class prints the information regarding each component. 
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// The Board object to be printed
        /// </summary>
        private static Board Board { get; set; }

        /// <summary>
        /// The Printer constructor to create the printing class. The constructor continues to call the <see cref=
        /// "PrintBoard"/> method to start printing information about each board component.
        /// </summary>
        /// <param name="board">The board objected to be printed</param>
        public Printer(Board board)
        {
            Board = board;
            PrintBoard(0);
        }
        
        /// <summary>
        /// Prints an entire line's width by recursing over the PrintLine method until the width parameter matches the
        /// <see cref="Board"/>'s width.
        /// </summary>
        /// <param name="length">The current vertical level of the board</param>
        /// <param name="width">The current horizontal level of the board</param>
        private static void PrintLine(int length, int width)
        {  
            //Base Case when the width matches the Board Width return
            if(width == Board.BoardWidth) return;
            
            //Iterative Case print one character to console and recurse over method to the next component
            Console.Write(Board.Box[length, width].ToString());
            PrintLine(length, width + 1);           
        }
        
        /// <summary>
        /// Recurses over each line and calls the <see cref="PrintLine"/> method for each line. The method continues
        /// recursing until the <see cref="Board"/>'s length is matched.
        /// </summary>
        /// <param name="length">The current vertical level of the board</param>
        private static void PrintBoard(int length)
        {
            //Base Case when the length matches the Board Length return
            if (length == Board.BoardLength) return;
            
            //Iterative Case print one line to console and recurse over method to the next line
            PrintLine(length, 0);
            Console.WriteLine();
            PrintBoard(length + 1);
        }
    }
}