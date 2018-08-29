using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Game
{
    public class Board
    {
        private int BoardWidth { get; set; }
        private int BoardLength { get; set; }
        private static MinesweeperBox[,] Box { get; set; }
        private const string Safe = ".";
        private const char Mine = '*';
        private static Validate validate { get; set; }

        public Board()
        {
            validate = new Validate();
        }
        
        private static void IncrementNeighbours(Coordinates coordinates)
        {
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var validateCoordinates = new Coordinates 
                        {CoordinateX = coordinates.CoordinateX + i,CoordinateY = coordinates.CoordinateY + j};
                    if(Validate.ValidBox(validateCoordinates))
                        Box[validateCoordinates.CoordinateX, validateCoordinates.CoordinateY].BoarderingMines++;
                }
            }
        }
        
        public Board CreateBoard(List<int> boardSettings, IEnumerable<string> lines)
        {
            validate.ValidateBoard(boardSettings);
            BoardLength = boardSettings.ElementAt(0);
            BoardWidth = boardSettings.ElementAt(1);
            Box = new MinesweeperBox[BoardLength, BoardWidth];
            Console.Write(BoardLength);
            Console.WriteLine(BoardWidth);
            for (var i = 0; i < BoardLength; i++)
            {
                for (var j = 0; j < BoardWidth; j++)
                {
                    if (!Equals(lines.ElementAt(i).ElementAt(j),Mine)) continue;
                    
                    Box[i, j].Mine = true;
                    var coordinates = new Coordinates{CoordinateX = i, CoordinateY = j};
                    //IncrementNeighbours(coordinates);
                }
            }

            return this;
        }
        
        public void Print()
        {
            for (var i = 0; i < BoardLength; i++)
            {
                for (var j = 0; j < BoardWidth; j++)
                {
                    Console.Write(Box[i, j].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}