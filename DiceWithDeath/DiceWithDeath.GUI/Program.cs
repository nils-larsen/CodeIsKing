using System;
using System.Collections.Generic;
using System.Linq;
using DiceWithDeath.Logic;

namespace DiceWithDeath.GUI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("WELCOME TO DICE WITH DEATH");

            while (true)
            {
                Console.Write("\nChoose dice size (3-whatever): ");
                var diceSize = DiceSize();
                var game = new Game(new Dice(diceSize));

                GameLoop(game);

                Console.WriteLine("Your score: {0}", game.Score);

                Console.Write("\nDo you want to play again? (y/n)");
                var playAgain = Console.ReadKey();
                if (playAgain.Key != ConsoleKey.Y)
                    break;
            }
            Console.WriteLine("\nBye!");
        }

        private static void GameLoop(Game game)
        {
            Console.WriteLine("\nFirst roll: {0}", game.RollDice());

            while (!game.GameOver)
            {
                Console.Write("\nPress <F> for lower and <H> for higher: ");
                
                var guessInput = Console.ReadKey();

                switch (guessInput.Key)
                {
                    case ConsoleKey.H:
                        game.GuessHigher();
                        break;
                    case ConsoleKey.F:
                        game.GuessLower();
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        continue;
                }
                
                Console.WriteLine("\nNew roll: {0}", game.RollDice());

                if (game.SameNumbersTwiceInRow())
                    Console.WriteLine("Same numbers twice in a row! No score given but you may continue");

                else if (game.HigherIsCorrect() || game.LowerIsCorrect())
                    Console.WriteLine("Your guess was correct! Continue");

                else
                    Console.WriteLine("You loose!");

                game.ValidateGuess();
            }
        }

        static int DiceSize()
        {
            if (int.TryParse(Console.ReadLine(), out int diceSize))
            {
                if (diceSize < 3)
                {
                    Console.WriteLine("That's not a real dice! Setting dice number to 6.");
                    return 6;
                }
                return diceSize;
            }
            Console.WriteLine("What kind of dice is that? Setting dice number to 6.");
            return 6;
        }
    }
}
