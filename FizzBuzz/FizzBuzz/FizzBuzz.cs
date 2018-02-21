namespace FizzBuzz.Logic
{
    public class FizzBuzzer
    {
        public string FizzString { get; set; }
        public int FizzValue { get; set; }
        public string BuzzString { get; set; }
        public int BuzzValue { get; set; }
        public int EndValue { get; set; }

        public FizzBuzzer()
        {
            FizzString = "Fizz";
            FizzValue = 3;
            BuzzString = "Buzz";
            BuzzValue = 5;
            EndValue = 100;
        }

        public bool IsFizzBuzz(int candidate)
        {
            return (candidate % FizzValue) == 0 && (candidate % BuzzValue) == 0;
        }

        public bool IsFizz(int candidate)
        {
            return !(IsFizzBuzz(candidate) || (candidate % FizzValue) != 0);
        }

        public bool IsBuzz(int candidate)
        {
            return !(IsFizzBuzz(candidate) || (candidate % BuzzValue) != 0);
        }
    }
}
