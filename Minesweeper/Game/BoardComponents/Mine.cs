namespace Minesweeper.Game.BoardComponents
{
    public class Mine : IBoardComponents
    {
        public Mine(Coordinates coordinates)
        {
            IsMine = true;
            Coordinates = coordinates;
            BoarderingMines = 0;
        }

        public bool IsMine { get; set; }
        public Coordinates Coordinates { get; set; }
        public int BoarderingMines { get; set; }
    }
}