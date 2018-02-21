
using Xunit;
using Reverser.Logic;

namespace Reverser.Tests
{

    public class ReverserTests
    {
        private Reverserize _reverser;

        public ReverserTests()
        {
            _reverser = new Reverserize();
        }

        [Fact]
        public void Should_reverse_one_word()
        {
            string result = _reverser.Reverse("hello");
            Assert.Equal("olleh", result);
        }

        [Fact]
        public void Should_reverse_words_in_sentence_and_keep_them_in_place()
        {
            string result = _reverser.Reverse("hello world");
            Assert.Equal("olleh dlrow", result);
        }

        [Fact]
        public void Should_keep_uppercase_positions()
        {
            string result = _reverser.Reverse("FoR the Win");
            Assert.Equal("RoF eht Niw", result);
        }

        [Fact]
        public void Bonus()
        {
            string result = _reverser.Reverse("ForeFront");
            Assert.Equal("TnorFerof", result);
        }
    }
}