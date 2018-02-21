using System.Collections.Generic;
using System.Linq;
using System;

namespace DiceWithDeath.Logic
{
    using CustomExtensions;
    public class Game
    {
        public int Score { get; private set; }
        public bool HighGuess { get; private set; }
        public bool GameOver { get; private set; }

        private List<int> _rolledDiceValues = new List<int>();
        private IDice _dice;

        public Game(IDice dice)
        {
            _dice = dice;
            Score = 0;
            GameOver = false;
        }

        public int RollDice()
        {
            var result = _dice.Roll();
            _rolledDiceValues.Add(result);
            return result;
        }

        public bool ReadyToGuess()
        {
            return _rolledDiceValues.Any();
        }

        public bool SameNumbersTwiceInRow()
        {
            return _rolledDiceValues.Last() == _rolledDiceValues.SecondLast();
        }

        public bool HigherIsCorrect()
        {
            return (_rolledDiceValues.Last() > _rolledDiceValues.SecondLast() && HighGuess);
        }

        public bool LowerIsCorrect()
        {
            return (_rolledDiceValues.Last() < _rolledDiceValues.SecondLast() && !HighGuess);
        }

        public void ValidateGuess()
        {
            if (_rolledDiceValues.Count < 2 || SameNumbersTwiceInRow())
                return;
            if (HigherIsCorrect() || LowerIsCorrect())
            {
                Score++;
                return;
            }
            SetGameOver();
        }

        private void SetGameOver()
        {
            GameOver = true;
        }

        public void GuessHigher()
        {
            HighGuess = true;
        }
        
        public void GuessLower()
        {
            HighGuess = false;
        }
    }
}

namespace CustomExtensions
{
    public static class Extension
    { 
        public static int SecondLast(this IEnumerable<int> items)
        {
            var list = items as List<int>;
            int count = list.Count;
            if (count > 1)
            {
                return list[count - 2];
            }
            else
                throw new ArgumentException("List must contain at least two elements.");
        }
    }
}
