namespace Minesweeper.Game.BoardComponents
{
    public class Safe : IBoardComponents
    {
        public int BoarderingMines { get; private set; }
        public bool IsMine { get; private set; }
        public Coordinates Coordinates { get; private set; }
        
        public Safe(int boarderingMines, Coordinates coordinates)
        {
            IsMine = false;
            BoarderingMines = boarderingMines;
            Coordinates = coordinates;
        }
    }
}