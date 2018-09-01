using System.Collections.Generic;

namespace Minesweeper.Game
{
    /// <summary>
    /// After the <see cref="StartGame"/> reads a board's configuration the specifications are sent to this class for
    /// parsing into a <see cref="Board"/> and then printed using the <see cref="Printer"/> method.
    /// </summary>
    public static class ConfigurationsReader
    {
        /// <summary>
        /// The Board object to be created
        /// </summary>
        private static Board Board { get; set; }

        /// <summary>
        /// This method calls the <see cref="BuildBoard"/> method and then it prints the <see cref="Board"/>
        /// </summary>
        /// <param name="boardSettings">The length and width of the board</param>
        /// <param name="lines">The lines making up the board configuration</param>
        public static void Reader(List<int> boardSettings, List<string> lines)
        {
            Board = BuildBoard(boardSettings, lines);
            new Printer(Board);
        }

        /// <summary>
        /// This method creates the <see cref="Board"/> and returns it to the previous method for printing
        /// </summary>
        /// <param name="boardSettings">The length and width of the board</param>
        /// <param name="lines">The lines making up the board configuration</param>
        /// <returns>A finished <see cref="Board"/></returns>
        private static Board BuildBoard(List<int> boardSettings, List<string> lines)
        {
            var board = new Board();
            return board.CreateBoard(boardSettings, lines);
        }
    }
}