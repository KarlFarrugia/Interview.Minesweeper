using System.Collections.Generic;

namespace Minesweeper.Game
{
    public static class ConfigurationsReader
    {
        private static Board Board { get; set; }

        public static void Reader(List<int> gameSettings, IEnumerable<string> lines)
        {
            Board = BuildBoard(gameSettings, lines);
            new Printer(Board);
        }

        private static Board BuildBoard(List<int> gameSettings, IEnumerable<string> lines)
        {
            var board = new Board();
            return board.CreateBoard(gameSettings, lines);
        }
    }
}