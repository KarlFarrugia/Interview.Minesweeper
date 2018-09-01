using Minesweeper.Game;

namespace Minesweeper
{
    /// <summary>
    /// This class loads the file from the command line arguments and starts the game.
    /// </summary>
    internal static class Program
    {

        /// <summary>
        /// The main method starts off the minesweeper program by receiving a command line argument, which denotes the 
        /// path to the game-settings file, and calls the <see cref="StartGame"/> class to start the game.
        /// </summary>
        /// <param name="args">The args parameter is expecting a path to a file</param>
        public static void Main(string[] args)
        {
            StartGame.Games(args[0]);
        }
    }
}