using Minesweeper.Game.BoardComponents;

namespace Minesweeper.Game
{
    public struct MinesweeperBox
    {
        public IBoardComponents Component { get; private set; }
      
        public MinesweeperBox(IBoardComponents component) : this()
        {
            Component = component;
        }
        
        public override string ToString()
        {       
            return Component.IsMine ? "*" : Component.BoarderingMines.ToString();
        }
    }
}