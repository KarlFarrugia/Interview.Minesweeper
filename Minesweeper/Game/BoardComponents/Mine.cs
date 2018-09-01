using System;

namespace Minesweeper.Game.BoardComponents
{
    /// <inheritdoc />
    /// <summary>
    /// The Mine object on the board is represented using this class
    /// </summary>
    public class Mine : IBoardComponents
    {
        /// <inheritdoc />
        /// <summary>
        /// The boolean to indicate that the Component is a Mine.
        /// The Coordinates for each Mine Component.
        /// The number of boardering mines. In the case of a mine this is left as 0.
        /// </summary>
        public bool IsMine { get; private set; }
        public Coordinates Coordinates { get; private set; }
        public int BorderingMines { get; private set; }
        
        /// <summary>
        /// The correct mine takes <see cref="Coordinates"/> as its parameters.
        /// </summary>
        /// <exception cref="ArgumentNullException">Cannot create a null <see cref="Mine"/></exception>
        public Mine()
        {
            throw new ArgumentNullException();
        }

        /// <summary>
        /// The IsMine boolean is automatically set to true.
        /// The Coordinates is set from the passed parameter.
        /// The number of BorderingMines is set to 0 as it is not needed for the intents of this assignment.
        /// </summary>
        /// <param name="coordinates">The coordinates of the mine</param>
        public Mine(Coordinates coordinates)
        {
            IsMine = true;
            Coordinates = coordinates;
            BorderingMines = 0;
        }
    }
}