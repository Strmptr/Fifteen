using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{

    [TestFixture]
    class tests
    {
        [TestCase]
        public void game()
        {

            Game game = new Game();
            game.game(4);
            Assert.AreEqual(4, game.size);
            game.game(3);
            Assert.AreEqual(3, game.size);
        }
        [TestCase]
        public void getnumber()
        {
            Game game = new Game();
            game.game(3);
            game.map = new int[,]
            {
                {0, 1, 0},
                {3, 13, 5},
                {9, 7, 8}
            };
            Assert.AreEqual(0, game.GetNumber(0));
            Assert.AreEqual(13, game.GetNumber(4));
            Assert.AreEqual(8, game.GetNumber(8));
        }

        [TestCase]
        public void coordtoposition()
        {
            Game game = new Game();
            game.size = 3;
            Assert.AreEqual(0, game.CoordsToPosition(0, 0));
            Assert.AreEqual(5, game.CoordsToPosition(2, 1));
            Assert.AreEqual(8, game.CoordsToPosition(2, 2));

        }
    }
}
