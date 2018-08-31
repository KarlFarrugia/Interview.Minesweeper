namespace Minesweeper.Game.BoardComponents
{
    public interface IBoardComponents
    {
        bool IsMine { get;}
        Coordinates Coordinates { get; }
        int BoarderingMines { get; }
    }
}