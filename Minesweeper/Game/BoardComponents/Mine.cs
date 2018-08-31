namespace Minesweeper.Game.BoardComponents
{
    public class Mine : IBoardComponents
    {
        public bool IsMine { get; private set; }
        public Coordinates Coordinates { get; private set; }
        public int BoarderingMines { get; private set; }
        
        public Mine(Coordinates coordinates)
        {
            IsMine = true;
            Coordinates = coordinates;
            BoarderingMines = 0;
        }
    }
}