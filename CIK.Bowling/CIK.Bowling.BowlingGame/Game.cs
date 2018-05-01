using System;
using System.Collections.Generic;

namespace CIK.Bowling.BowlingGame
{
    public class Game
    {
        private readonly List<int> _rollHistory;
        
        public Game()
        {
            _rollHistory = new List<int>();
        }

        public void Roll(int pins)
        {
            _rollHistory.Add(pins);
        }

        public int Score()
        {
            var score = 0;
            var rollNumber = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollNumber))
                {
                    score += GetExtraScore(rollNumber);
                    rollNumber++;
                }
                else if (IsSpare(rollNumber))
                {
                    score += GetExtraScore(rollNumber);
                    rollNumber += 2;
                }
                else
                {
                    score += GetStandardScore(rollNumber);
                    rollNumber += 2;
                }
            }
            return score;  
        }

        private bool IsStrike(int rollIndex)
        {
            return _rollHistory[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return _rollHistory[rollIndex] + _rollHistory[rollIndex + 1] == 10;
        }

        private int GetExtraScore(int rollIndex)
        {
            return _rollHistory[rollIndex] + _rollHistory[rollIndex + 1] + _rollHistory[rollIndex + 2];
        }

        private int GetStandardScore(int rollIndex)
        {
            return _rollHistory[rollIndex] + _rollHistory[rollIndex + 1];
        }
    }
}
