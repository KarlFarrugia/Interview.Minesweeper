using System.Collections.Generic;
using System.Linq;
using Minesweeper.Game.BoardObjects;

namespace Minesweeper.Game
{
    public class Board
    {
        private int BoardWidth { get; set; }
        private int BoardLength { get; set; }
        private MinesweeperBoard[,] Box { get; set; }

        private static void IncrementNeighbours(Coordinates coordinates)
        {
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    Coordinates validateCoordinates = new Coordinates {CoordinateX = coordinates.CoordinateX + i,CoordinateY = coordinates.CoordinateY + j};
                    Validate.ValidBox(validateCoordinates);
                }
            }
        }
        
        public void CreateBoard(List<int> boardSettings, IEnumerable<Mine> mines)
        {
            BoardWidth = boardSettings.ElementAt(0);
            BoardLength = boardSettings.ElementAt(1);
            Box = new MinesweeperBoard[BoardWidth, BoardLength];

            foreach (var mine in mines)
            {
                Box[mine.Coordinates.CoordinateX, mine.Coordinates.CoordinateY].Mine = true;
                IncrementNeighbours(mine.Coordinates);
            }
            
            //default of boolean is false therefore no need to instantiate other values to false.
        }
        
        public bool IsMine(Coordinates mine)
        {
            return Box[mine.CoordinateX, mine.CoordinateY].Mine;
        }
    }
}