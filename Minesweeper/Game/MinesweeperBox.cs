namespace Minesweeper.Game
{
    public struct MinesweeperBox
    {
        public bool Mine { get; set; }
        public int BoarderingMines { get; set; }

        public override string ToString()
        {
            return Mine ? "*" : BoarderingMines.ToString();
        }
    }
}