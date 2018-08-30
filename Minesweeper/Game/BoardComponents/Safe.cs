namespace Minesweeper.Game.BoardComponents
{
    public class Safe : IBoardComponents
    {
        public int BoarderingMines { get; set; }
        public bool IsMine { get; set; }
        public Coordinates Coordinates { get; set; }
        
        public Safe(int boarderingMines, Coordinates coordinates)
        {
            IsMine = false;
            BoarderingMines = boarderingMines;
            Coordinates = coordinates;
        }
    }
}