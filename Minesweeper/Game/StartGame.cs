using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Minesweeper.Game
{
    /// <summary>
    /// This class loads the game configurations from file and then executes each minesweeper game
    /// </summary>
    public static class StartGame
    {
        /// <summary>
        /// Upon loading the file the program will start recursing through every sequence of games until EOF signal is
        /// reached.
        /// </summary>
        /// <param name="file">A path to a file where the configurations for all the games are</param>
        public static void Games(string file)
        {
            PlotGame(File.ReadAllLines(file).ToList(), 1);
        }

        /// <summary>
        /// The recursion is carried out by reading the first line of the passed string which contains the board
        /// parameters of the minesweeper game. If the first line equals "0 0" the program returns as it signifies an
        /// EOF. Otherwise it will call the <see cref="ConfigurationsReader"/> class which will be able to build and
        /// print the board.
        /// </summary>
        /// <param name="lines">The string of lines to be parsed from the file</param>
        /// <param name="current">The current game number. Starts from 1 and increments by 1 for each game</param>
        public static void PlotGame(List<string> lines, int current)
        {
            Validate.InitialFileLine(lines);
            //EOF specification
            if (lines.ElementAt(0).Equals("0 0")) return;
            
            //Otherwise execute current game
            var validator = new Validate();
            Console.WriteLine("Field #{0}:", current);
            var boardSettings = Validate.ValidateBoardSettings(lines.ElementAt(0));
            ConfigurationsReader.Reader
                (boardSettings, lines.Skip(1).Take(boardSettings.ElementAt(0)).ToList(), validator);

            //Recurse and remove the current game from the passed string. Increment the current game by 1
            PlotGame(lines.Skip(boardSettings.ElementAt(0) + 1).ToList(), current + 1);           
        }
    }
}