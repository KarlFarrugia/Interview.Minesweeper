using System;
using System.Collections.Generic;
using Minesweeper.Game;
using Minesweeper.Game.BoardComponents;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// A set of Unit Tests with the aim of testing different aspects of the minesweeper program execution.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private readonly Coordinates Coordinates = new Coordinates {CoordinateX = 4, CoordinateY = 2};

        /// <summary>
        /// Tests that the <see cref="Coordinates"/> structure holds the X and Y coordinates properly.
        /// </summary>
        [TestCase]
        public void TestCoordinates()
        {
            Assert.AreEqual(Coordinates.CoordinateX, 4);
            Assert.AreEqual(Coordinates.CoordinateY, 2);
            Assert.AreNotEqual(Coordinates.CoordinateY, 4);
            Assert.AreNotEqual(Coordinates.CoordinateX, 2);
        }
        
        /// <summary>
        /// Tests that an <see cref="Mine"/> cannot be null.
        /// </summary>
        [TestCase]
        public void TestNullMine()
        {
            Assert.Throws<ArgumentNullException>(() => new Mine()); 
        }
        
        /// <summary>
        /// Tests that a <see cref="Mine"/> object.
        /// </summary>
        [TestCase]
        public void TestCorrectMine()
        {
            var mine = new Mine(Coordinates); 
            Assert.AreEqual(mine.BorderingMines, 0);
            Assert.AreEqual(mine.Coordinates, Coordinates);
            Assert.IsTrue(mine.IsMine);
        }
        
        /// <summary>
        /// Tests that an <see cref="Safe"/> cannot be null.
        /// </summary>
        [TestCase]
        public void TestNullSafe()
        {
            Assert.Throws<ArgumentNullException>(() => new Safe()); 
        }
        
        /// <summary>
        /// Tests that a <see cref="Safe"/> object.
        /// </summary>
        [TestCase]
        public void TestCorrectSafe()
        {
            var safe = new Safe(2, Coordinates); 
            Assert.AreEqual(safe.BorderingMines, 2);
            Assert.AreEqual(safe.Coordinates, Coordinates);
            Assert.IsFalse(safe.IsMine);
        }

        /// <summary>
        /// Tests the <see cref="Mine"/> ToString method
        /// </summary>
        [TestCase]
        public void TestMineMinesweeperBox()
        {
            var box = new MinesweeperBox(new Mine(Coordinates));
            Assert.AreEqual(box.ToString(),"*");
        }
        
        /// <summary>
        /// Tests the <see cref="Safe"/> ToString method
        /// </summary>
        [TestCase]
        public void TestSafeMinesweeperBox()
        {
            var box = new MinesweeperBox(new Safe(2, Coordinates));
            Assert.AreEqual(box.ToString(),"2");
        }
        
        /// <summary>
        /// Checks for more than 2 board settings
        /// </summary>
        [TestCase]
        public void ExtraBoardSettings()
        {
            var testSettings = new List<int>{0, 0, 0};        
            Assert.Throws<Exception>(() => Validate.ValidateBoard(testSettings));
        }
        
        /// <summary>
        /// Checks when a board setting is negative
        /// </summary>
        [TestCase]
        public void NegativeBoardSettings()
        {
            var testSettings = new List<int>{0, -1};        
            Assert.Throws<Exception>(() => Validate.ValidateBoard(testSettings));
        }
        
        /// <summary>
        /// Checks when a board settings is NaN
        /// </summary>
        [TestCase]
        public void NonNumericBoardSettings()
        {
            var testSettings = new List<string>{"0 a","...","...","..."};        
            Assert.Throws<Exception>(() => StartGame.PlotGame(testSettings, 1));
        }
        
        /// <summary>
        /// Checks when the board specifications and the actual data do not match
        /// </summary>
        [TestCase]
        public void BoardSettingsMismatch()
        {
            var testSettings = new List<string>{"1 1", "...","...","..."};        
            Assert.Throws<Exception>(() => StartGame.PlotGame(testSettings, 1));
        }
        
        /// <summary>
        /// Checks a specification with a wrong EOF 
        /// </summary>
        [TestCase]
        public void WrongEof()
        {
            var testSettings = new List<string>{"4 4", "*...","....",".*..","...."};
            Assert.Throws<Exception>(() => StartGame.PlotGame(testSettings, 1));
        }

        /// <summary>
        /// Checks that a correct execution does not crash
        /// </summary>
        [TestCase]
        public void CorrectBoardParse()
        {
            var testSettings = new List<string>{"4 4", "*...","....",".*..","....","0 0"};
            StartGame.PlotGame(testSettings, 1);
            Assert.Pass();
        }
        
        /// <summary>
        /// Checks that a correct execution does not crash
        /// </summary>
        [TestCase]
        public void CorrectBoardParse2()
        {
            var testSettings = new List<string>{"3 5", "**...",".....",".*...","0 0"};
            StartGame.PlotGame(testSettings, 1);
            Assert.Pass();
        }
    }
}