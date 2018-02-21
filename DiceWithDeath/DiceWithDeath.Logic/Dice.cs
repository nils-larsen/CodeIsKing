using System;

namespace DiceWithDeath.Logic
{
    public interface IDice
    {
        int Roll();
    }

    public class Dice : IDice
    {
        private Random _random;
        private int _sides;

        public Dice(int sides)
        {
            _sides = sides;
            _random = new Random();
        }

        public int Roll()
        {
            return _random.Next(1, _sides + 1);
        }
    }
}
