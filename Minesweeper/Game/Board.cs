using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Game.BoardComponents;

namespace Minesweeper.Game
{
    public class Board
    {
        private int BoardWidth { get; set; }
        private int BoardLength { get; set; }
        private static MinesweeperBox[,] Box { get; set; }
        private const char Safe = '.';
        private const char Mine = '*';
        private static Validate validate { get; set; }

        public Board()
        {
            validate = new Validate();
        }

        private static int Increment(Coordinates coordinates)
        {
            if (Box[coordinates.CoordinateX,coordinates.CoordinateY].Component != null)
            {
                return Box[coordinates.CoordinateX,coordinates.CoordinateY].Component.BoarderingMines + 1;
            }
            return 0;   
        }
        
        private static void IncrementNeighbours(MinesweeperBox component)
        {
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    var validateCoordinates = new Coordinates
                    {
                        CoordinateX = component.Component.Coordinates.CoordinateX + i,
                        CoordinateY = component.Component.Coordinates.CoordinateY + j
                    };
                    if (Validate.ValidBox(validateCoordinates))
                    {
                        Box[validateCoordinates.CoordinateX, validateCoordinates.CoordinateY] = new MinesweeperBox(
                            new Safe(Increment(validateCoordinates), validateCoordinates));
                    }
                }
            }
        }
        
        public Board CreateBoard(List<int> boardSettings, IEnumerable<string> lines)
        {
            Validate.ValidateBoard(boardSettings);
            BoardLength = boardSettings.ElementAt(0);
            BoardWidth = boardSettings.ElementAt(1);
            Box = new MinesweeperBox[BoardLength, BoardWidth];
            for (var i = 0; i < BoardLength; i++)
            {
                for (var j = 0; j < BoardWidth; j++)
                {
                    switch (lines.ElementAt(i).ElementAt(j))
                    {
                        case Mine:
                            Box[i, j] = new MinesweeperBox(new Mine(new Coordinates{CoordinateX = i, CoordinateY = j}));
                            IncrementNeighbours(Box[i, j]);
                            break;
                        case Safe:
                            var coordinates =  new Coordinates{CoordinateX = i, CoordinateY = j};
                            Box[i, j] = new MinesweeperBox(new Safe(Increment(coordinates),coordinates));
                            break;
                        default:
                            throw new Exception("Incorrect Character");
                    }
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