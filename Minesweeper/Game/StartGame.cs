namespace Minesweeper.Game
{
    public class StartGame
    {
        public static void Game(string file)
        {
            var gameConfiguration = new ConfigurationsReader(file);
        }
    }
}