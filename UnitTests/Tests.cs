using System;
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
        /// <summary>
        /// Tests that the <see cref="Coordinates"/> structure holds the X and Y coordinates properly.
        /// </summary>
        [TestCase]
        public void TestCoordinates()
        {
            var coordinates = new Coordinates {CoordinateX = 4, CoordinateY = 2};
            Assert.AreEqual(coordinates.CoordinateX, 4);
            Assert.AreEqual(coordinates.CoordinateY, 2);
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
        /// Tests that an <see cref="Safe"/> cannot be null.
        /// </summary>
        [TestCase]
        public void TestNullSafe()
        {
            Assert.Throws<ArgumentNullException>(() => new Safe()); 
        }
    }
}