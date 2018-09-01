using Minesweeper.Game.BoardComponents;

namespace Minesweeper.Game
{
    /// <summary>
    /// A data structure created to hold a <see cref="IBoardComponents"/> in each board space
    /// </summary>
    public struct MinesweeperBox
    {
        /// <summary>
        /// The component to be stored in a board location.
        /// </summary>
        public IBoardComponents Component { get; private set; }

        /// <summary>
        /// A constructor for the MinesweeperBox which takes a <see cref="IBoardComponents"/> as its parameter
        /// </summary>
        /// <param name="component">The type of component to be inserted in the board</param>
        public MinesweeperBox(IBoardComponents component) : this()
        {
            Component = component;
        }
        
        /// <summary>
        /// Overrides the ToString method to deliver either a Mine or the number of bordering mines
        /// </summary>
        /// <returns>Returns an * if it is a mine or the number of bordering mines as a string type</returns>
        public override string ToString()
        {       
            return Component.IsMine ? "*" : Component.BorderingMines.ToString();
        }
    }
}