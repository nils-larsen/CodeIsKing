using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceWithDeath.Logic;
using Moq;

namespace DiceWithDeath.Tests
{
    [TestClass]
    public class GameTests
    {
        private Mock<IDice> mockDice;
        private Game game;

        [TestInitialize]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            game = new Game(mockDice.Object);
        }

        [TestMethod]
        public void Moq_RollDice_should_return_mock_value()
        {
            mockDice.Setup(x => x.Roll()).Returns(1);
            Assert.AreEqual(1, game.RollDice());

            mockDice.Setup(x => x.Roll()).Returns(3);
            Assert.AreEqual(3, game.RollDice());
        }

        [TestMethod]
        public void ReadyToGuess_should_return_false_if_dice_has_not_been_rolled()
        {
            Assert.IsFalse(game.ReadyToGuess());
        }

        [TestMethod]
        public void ReadyToGuess_should_return_true_if_dice_has_been_rolled()
        {
            var result = game.RollDice();
            Assert.IsTrue(game.ReadyToGuess());
        }

        [TestMethod]
        public void Score_should_be_1_if_correct_guess()
        {
            mockDice.Setup(x => x.Roll()).Returns(1);
            var roll1 = game.RollDice();

            game.GuessHigher();

            mockDice.Setup(x => x.Roll()).Returns(3);
            var roll2 = game.RollDice();

            Assert.IsTrue(game.HigherIsCorrect());
            game.ValidateGuess();
            Assert.AreEqual(1, game.Score);
        }

        [TestMethod]
        public void Score_should_be_0_if_incorrect_first_guess()
        {
            mockDice.Setup(x => x.Roll()).Returns(4);
            var roll1 = game.RollDice();

            game.GuessLower();

            mockDice.Setup(x => x.Roll()).Returns(6);
            var roll2 = game.RollDice();

            Assert.IsFalse(game.LowerIsCorrect());
            game.ValidateGuess();
            Assert.AreEqual(0, game.Score);
        }

        [TestMethod]
        public void Score_should_be_2_if_correct_second_guess()
        {
            mockDice.Setup(x => x.Roll()).Returns(4);
            var roll1 = game.RollDice();

            game.GuessHigher();

            mockDice.Setup(x => x.Roll()).Returns(6);
            var roll2 = game.RollDice();

            Assert.IsTrue(game.HigherIsCorrect());
            game.ValidateGuess();
            game.GuessLower();

            mockDice.Setup(x => x.Roll()).Returns(2);
            var roll3 = game.RollDice();

            Assert.IsTrue(game.LowerIsCorrect());
            game.ValidateGuess();
            Assert.AreEqual(2, game.Score);
        }

        [TestMethod]
        public void Score_should_be_0_if_same_numbers_in_row()
        {
            mockDice.Setup(x => x.Roll()).Returns(4);
            var roll1 = game.RollDice();

            game.GuessHigher();
            
            mockDice.Setup(x => x.Roll()).Returns(4);
            var roll2 = game.RollDice();

            Assert.IsTrue(game.SameNumbersTwiceInRow());
            game.ValidateGuess();
            Assert.AreEqual(0, game.Score);
            Assert.IsFalse(game.GameOver);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SecondLastExtension_should_throw_when_not_enough_elements()
        {
            mockDice.Setup(x => x.Roll()).Returns(3);
            var roll1 = game.RollDice();
            game.GuessHigher();
            game.HigherIsCorrect(); 
        }
    }
}
