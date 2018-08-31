using System;

namespace Minesweeper.Game
{
    public class Printer
    {
        private static Board Board { get; set; }

        public Printer(Board board)
        {
            Board = board;
            PrintLines(0);
        }
        
        private static void PrintLine(int length, int width)
        {
            //Base Case when the width matches the Board Width
            if(width == Board.BoardWidth) return;
            
            //Iteratice Case print one character to console and recurse over method
            Console.Write(Board.Box[length, width].ToString());
            PrintLine(length, width + 1);           
        }
        
        private static void PrintLines(int length)
        {
            //Base Case when the length matches the Board Length
            if (length == Board.BoardLength) return;
            
            //Iteratice Case print one line to console and recurse over method
            PrintLine(length, 0);
            Console.WriteLine();
            PrintLines(length + 1);
        }
    }
}