using System;
using FizzBuzz.Logic;

namespace FizzBuzzNS
{
    class Program
    {
        static void Main()
        {
            var fizzer = new FizzBuzzer();

            for (int i = 1; i <= fizzer.EndValue; i++)
            {
                if (fizzer.IsFizz(i))
                {
                    Console.WriteLine(fizzer.FizzString);
                }
                else if (fizzer.IsBuzz(i))
                {
                    Console.WriteLine(fizzer.BuzzString);
                }
                else if (fizzer.IsFizzBuzz(i))
                {
                    Console.WriteLine(fizzer.FizzString + fizzer.BuzzString);
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
