namespace Minesweeper.Game.BoardObjects
{
    public class Safe : IBoardObjectsInterface
    {
        private int BoarderingMines { get; set; }
        public Safe(Coordinates coordinates)
        {
            Coordinates = coordinates;
            BoarderingMines = 0;
        }
        
        public Coordinates Coordinates { get; set; }
    }
}