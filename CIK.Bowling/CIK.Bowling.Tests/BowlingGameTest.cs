using System;
using CIK.Bowling.BowlingGame;
using Xunit;

namespace CIK.Bowling.Tests
{
    public class BowlingGameTest
    {
        private readonly Game _game;
        
        public BowlingGameTest()
        {
            _game = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (var i = 0; i < n; i++)
            {
                _game.Roll(pins);
            }
        }
        
        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, _game.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            _game.Roll(5);
            _game.Roll(5); // Spare
            _game.Roll(3);
            RollMany(17,0);
            Assert.Equal(16, _game.Score());
        }

        [Fact]
        public void TestOneStrike()
        {
            _game.Roll(10); // Strike
            _game.Roll(3);
            _game.Roll(3);
            RollMany(16, 0);
            Assert.Equal(22, _game.Score());
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, _game.Score());
        }
    }
}
