namespace Minesweeper.Game.BoardComponents
{
    /// <summary>
    /// An interface for the objects on the board namely <see cref="Mine"/> and <see cref="Safe"/>
    /// which require them to have at least <see cref="Coordinates"/>.
    /// </summary>
    public interface IBoardComponents
    {
        /// <summary>
        /// The interface requires all the methods that implement it to have a boolean to indicate if it is a mine or
        /// not, have implemented <see cref="Coordinates"/> and an integer to indicate the number of mines it borders.
        /// </summary>
        bool IsMine { get; }
        Coordinates Coordinates { get; }
        int BorderingMines { get; }
    }
}