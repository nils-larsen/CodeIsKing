using FizzBuzz.Logic;
using Xunit;

namespace FizzBuzz.Tests
{
    public class TestFizzBuzz
    {
        [Fact]
        public void TestIfBuzzFizz()
        {
            var fizzer = new FizzBuzzer();
            var expectedFizzBuzz = fizzer.IsFizzBuzz(fizzer.FizzValue * fizzer.BuzzValue);
            Assert.True(expectedFizzBuzz);
        }

        [Fact]
        public void TestIfNotBuzzFizz()
        {
            var fizzer = new FizzBuzzer();
            var expectedFizzBuzz = fizzer.IsFizzBuzz(fizzer.FizzValue * fizzer.BuzzValue + 1);
            Assert.False(expectedFizzBuzz);
        }

        [Fact]
        public void TestIfFizz()
        {
            var fizzer = new FizzBuzzer();
            var expectedFizz = fizzer.IsFizz(fizzer.FizzValue);
            Assert.True(expectedFizz);
        }

        [Fact]
        public void TestIfNotFizz()
        {
            var fizzer = new FizzBuzzer();
            var expectedFizz = fizzer.IsFizz(fizzer.FizzValue * fizzer.BuzzValue);
            Assert.False(expectedFizz);
        }

        [Fact]
        public void TestIfBuzz()
        {
            var fizzer = new FizzBuzzer();
            var expectedBuzz = fizzer.IsBuzz(fizzer.BuzzValue);
            Assert.True(expectedBuzz);
        }

        [Fact]
        public void TestIfNotBuzz()
        {
            var fizzer = new FizzBuzzer();
            var expectedBuzz = fizzer.IsBuzz(fizzer.FizzValue);
            Assert.False(expectedBuzz);
        }
    }
}
