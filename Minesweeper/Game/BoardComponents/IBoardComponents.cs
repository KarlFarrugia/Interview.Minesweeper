namespace Minesweeper.Game.BoardComponents
{
    public interface IBoardComponents
    {
        bool IsMine { get; set; }
        Coordinates Coordinates { get; set; }
        int BoarderingMines { get; set; }
    }
}