using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Game.BoardComponents;

namespace Minesweeper.Game
{
    /// <summary>
    /// The Board object to be created
    /// </summary>
    public class Board
    {
        internal int BoardWidth { get; private set; }
        internal int BoardLength { get; private set; }
        internal static MinesweeperBox[,] Box { get; private set; }
        private const char Safe = '.';
        private const char Mine = '*';
        private static Validate Validate { get; set; }

        /// <summary>
        /// The Board constructor intialises the <see cref="Validate"/> class which is used to validate the board
        /// parameters.
        /// </summary>
        public Board()
        {
            Validate = new Validate();
        }

        /// <summary>
        /// Returns a <see cref="IBoardComponents"/> from a given set of <see cref="Coordinates"/>
        /// </summary>
        /// <param name="coordinates">The coordinates of the board component</param>
        /// <returns>The component that belongs to the given coordinates</returns>
        private static IBoardComponents GetComponent(Coordinates coordinates)
        {
            return Box[coordinates.CoordinateX, coordinates.CoordinateY].Component;
        }
      
        /// <summary>
        /// Checks if a <see cref="IBoardComponents"/> exists and if it is a <see cref="Mine"/>
        /// </summary>
        /// <param name="component">The component to be checked</param>
        /// <returns>A boolean value: true if it is a mine and false otherwise</returns>
        private static bool IsMine(IBoardComponents component)
        {
            return component != null && component.IsMine;
        }
        
        /// <summary>
        /// Increments the BorderingMines by returning an integer incrementation of the current
        /// <see cref="IBoardComponents"/> or 0 if component doesn't exist.
        /// </summary>
        /// <param name="component">The component to use to get the number of BorderingMines</param>
        /// <returns>An integer value of the number of bordering mines</returns>
        private static int IncrementComponent(IBoardComponents component)
        {
            return component != null ? component.BorderingMines + 1 : 0;
        }
        
        /// <summary>
        /// Checks if the neighbouring box lies on the board or is a <see cref="Mine"/>. If it is a valid
        /// <see cref="Safe"/> box then the neighbour is incremented by instantiating a new <see cref="Safe"/> object in
        /// its place. This is done to preserve the program's immutability.
        /// </summary>
        /// <param name="coordinates"></param>
        private static void IncrementCheck(Coordinates coordinates)
        {
            if (Validate.ValidBox(coordinates) && !IsMine(GetComponent(coordinates)))
                Box[coordinates.CoordinateX, coordinates.CoordinateY] = new MinesweeperBox(
                    new Safe(IncrementComponent(GetComponent(coordinates)), coordinates));    
        }
        
        /// <summary>
        /// This method varies the width value of the neighbour's to be incremented through recursion.
        /// 
        /// Calls the <see cref="IncrementCheck"/> on each neighbouring box within a 1 box parameter.
        ///
        /// (-1,-1) (-1, 0) (-1, 1)
        /// ( 0,-1) ( 0, 0) ( 0, 1)
        /// ( 1,-1) ( 1, 0) ( 1, 1)
        ///
        /// The (0,0) will not be incremented since the <see cref="IncrementCheck"/> method will find it to be a
        /// <see cref="Mine"/>. The recursion method will return once the width reaches -2 (Goes beyond the incrementing
        /// area).
        /// </summary>
        /// <param name="coordinates">The coordinates of the current component</param>
        /// <param name="length">The length coordinate value of the component to increment</param>
        /// <param name="width">The width coordinate value of the component to increment</param>
        private static void IncrementNeighbour(Coordinates coordinates, int length, int width)
        {
            if (width == -2) return;
            IncrementCheck(new Coordinates{CoordinateX = coordinates.CoordinateX + length,
                                           CoordinateY = coordinates.CoordinateY + width});
            IncrementNeighbour(coordinates, length, width - 1);            
        }
        
        /// <summary>
        /// Same description as above but varies the length value of the neighbour's to be incremented through recursion.
        /// </summary>
        /// <param name="coordinates">The coordinates of the current component</param>
        /// <param name="length">The length coordinate value of the component to increment</param>
        private static void IncrementNeighbours(Coordinates coordinates, int length)
        {
            if (length == -2) return;
            IncrementNeighbour(coordinates, length, 1);
            IncrementNeighbours(coordinates, length - 1);
        }

        /// <summary>
        /// Recursively goes through each character in a line and checks whether it is a <see cref="Mine"/> or a
        /// <see cref="Safe"/>. If it is a mine call the <see cref="IncrementNeighbours"/> method to increment the
        /// BorderingMines of the boxes within a 1 box range. If it is safe instantiate a new safe component.
        ///
        /// The recursion stops once the width value matches the BoardWidth value.
        /// </summary>
        /// <param name="line">The current line to be parsed</param>
        /// <param name="length">The length value of the char to be parsed</param>
        /// <param name="width">The width value of the char to be parsed</param>
        /// <exception cref="Exception">If a game specification does not match '.' or '*' throw an exception</exception>
        private void ParseLine(string line, int length, int width)
        {
            if(width == BoardWidth) return;
            var coordinates =  new Coordinates{CoordinateX = length, CoordinateY = width};
            switch (line.ElementAt(width))
            {
                case Mine:
                    Box[length, width] = new MinesweeperBox(new Mine(coordinates));
                    IncrementNeighbours(coordinates, 1);
                    break;
                case Safe:
                    Box[length, width] = new MinesweeperBox
                        (new Safe(IncrementComponent(GetComponent(coordinates)),coordinates));
                    break;
                default:
                    throw new Exception("Incorrect Character Found");
            }
            ParseLine(line, length, width + 1);
        }

        /// <summary>
        /// Same description as above but recurses over a list of lines. Each line is sent to <see cref="ParseLine"/> to
        /// be parsed on a character level.
        /// </summary>
        /// <param name="lines">The list of lines to be parsed</param>
        /// <param name="length">The length value of the line to be parsed</param>
        private void ParseLines(List<string> lines, int length)
        {
            if (length == BoardLength) return;
            ParseLine(lines.ElementAt(length), length, 0);
            ParseLines(lines, length + 1);
        }
        
        /// <summary>
        /// This method builds the Board and returns itself as a finished board object.
        /// </summary>
        /// <param name="boardSettings">The length and width of the board</param>
        /// <param name="lines">The game specifications to be parsed</param>
        /// <returns>A finished board objected parsed from the given parameters</returns>
        public Board CreateBoard(List<int> boardSettings, List<string> lines)
        {
            Validate.ValidateBoard(boardSettings);
            BoardLength = boardSettings.ElementAt(0);
            BoardWidth = boardSettings.ElementAt(1);
            Box = new MinesweeperBox[BoardLength, BoardWidth];
            ParseLines(lines,0);
            return this;
        }
    }
}