using System.IO;

namespace Minesweeper.Game
{
    public class ConfigurationsReader
    {
        public ConfigurationsReader(string file)
        {
            var lines = File.ReadAllLines(file);
        }
    }
}