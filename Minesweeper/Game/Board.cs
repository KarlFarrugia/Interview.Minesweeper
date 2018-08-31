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

        private static IBoardComponents GetComponent(Coordinates coordinates)
        {
            return Box[coordinates.CoordinateX, coordinates.CoordinateY].Component;
        }
        
        private static int IncrementSafeComponent(IBoardComponents component)
        {
            return component != null ? component.BoarderingMines + 1 : 0;
        }

        private static bool IsMine(IBoardComponents component)
        {
            return component != null && component.IsMine;
        }
        
        private static void Increment(MinesweeperBox component, int i, int j)
        {
            var validateCoordinates = new Coordinates
            {
                CoordinateX = component.Component.Coordinates.CoordinateX + i,
                CoordinateY = component.Component.Coordinates.CoordinateY + j
            };
            if (Validate.ValidBox(validateCoordinates) && !IsMine(GetComponent(validateCoordinates)))
                Box[validateCoordinates.CoordinateX, validateCoordinates.CoordinateY] = new MinesweeperBox(
                    new Safe(IncrementSafeComponent(GetComponent(validateCoordinates)), validateCoordinates));    
        }
        
        private static void IncrementNeighbour(MinesweeperBox component, int length, int width)
        {
            if (width == -2) return;
            if (length == 0 && width == 0) IncrementNeighbour(component, length, width - 1);            
            else
            {
                Increment(component, length, width);
                IncrementNeighbour(component, length, width - 1);
            }
        }
        
        private static void IncrementNeighbours(MinesweeperBox component, int length)
        {
            if (length == -2) return;
            IncrementNeighbour(component, length, 1);
            IncrementNeighbours(component, length - 1);
        }

        private void CreateLine(string line, int length, int width)
        {
            if(width == BoardWidth) return;
            var coordinates =  new Coordinates{CoordinateX = length, CoordinateY = width};
            switch (line.ElementAt(width))
            {
                case Mine:
                    Box[length, width] = new MinesweeperBox(new Mine(coordinates));
                    IncrementNeighbours(Box[length, width], 1);
                    break;
                case Safe:
                    Box[length, width] = new MinesweeperBox
                        (new Safe(IncrementSafeComponent(GetComponent(coordinates)),coordinates));
                    break;
                default:
                    throw new Exception("Incorrect Character");
            }
            CreateLine(line, length, width + 1);
        }

        private void CreateLines(IEnumerable<string> lines, int length)
        {
            if (length == BoardLength) return;
            CreateLine(lines.ElementAt(length), length, 0);
            CreateLines(lines, length + 1);
        }
        
        
        public Board CreateBoard(List<int> boardSettings, IEnumerable<string> lines)
        {
            Validate.ValidateBoard(boardSettings);
            BoardLength = boardSettings.ElementAt(0);
            BoardWidth = boardSettings.ElementAt(1);
            Box = new MinesweeperBox[BoardLength, BoardWidth];
            CreateLines(lines,0);
            return this;
        }

        private void PrintLine(int length, int width)
        {
            if(width == BoardWidth) return;
            Console.Write(Box[length, width].ToString());
            PrintLine(length, width + 1);           
        }
        
        private void PrintLines(int length)
        {
            if (length == BoardLength) return;
            PrintLine(length, 0);
            Console.WriteLine();
            PrintLines(length + 1);
        }
        
        public void Print()
        {
            PrintLines(0);
        }
    }
}