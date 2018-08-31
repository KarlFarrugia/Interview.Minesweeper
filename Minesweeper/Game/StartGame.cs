using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Minesweeper.Game
{
    public static class StartGame
    {
        public static void Games(string file)
        {
            var lines = File.ReadAllLines(file);
            PlotGame(lines, 0);
        }

        private static void PlotGame(IEnumerable<string> lines, int current)
        {
            if (lines.ElementAt(0).Equals("0 0")) return;
            
            Console.WriteLine("Field #{0}:", current);
            
            var gameSettings = lines.ElementAt(0).Split(' ').Select(int.Parse).ToList();

            ConfigurationsReader.Reader(gameSettings, lines.Skip(1).Take(gameSettings.ElementAt(0)).ToList());

            PlotGame(lines.Skip(gameSettings.ElementAt(0) + 1).ToArray(), current + 1);
        }
    }
}