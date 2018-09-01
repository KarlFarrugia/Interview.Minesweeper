using System;

namespace Minesweeper.Game.BoardComponents
{
    /// <inheritdoc />
    /// <summary>
    /// The Safe (non-Mine) object on the board is represented using this class
    /// </summary>
    public class Safe : IBoardComponents
    {
        /// <inheritdoc />
        /// <summary>
        /// The boolean to indicate that the Component is not a Mine.
        /// The Coordinates for each Safe Component.
        /// The number of boardering mines.
        /// </summary>
        public int BorderingMines { get; private set; }
        public bool IsMine { get; private set; }
        public Coordinates Coordinates { get; private set; }
        
        /// <summary>
        /// The correct safe takes a <see cref="BorderingMines"/> integer and a set of <see cref="Coordinates"/> as its
        /// parameters.
        /// </summary>
        /// <exception cref="ArgumentNullException">Cannot create a null <see cref="Mine"/></exception>
        public Safe()
        {
            throw new ArgumentNullException();
        }
        
        /// <summary>
        /// The IsMine boolean is automatically set to false.
        /// The Coordinates is set from the passed parameter.
        /// The number of BorderingMines is set to the borderingMines parameter passed to the method.
        /// </summary>
        /// <param name="borderingMines">The number of bordering mines</param>
        /// <param name="coordinates">The coordinates of the safe component</param>
        public Safe(int borderingMines, Coordinates coordinates)
        {
            IsMine = false;
            BorderingMines = borderingMines;
            Coordinates = coordinates;
        }
    }
}