using System.Linq;

namespace Reverser.Logic
{
    public class Reverserize
    {
        public string Reverse(string sentence)
        {
            var sentenceArr = sentence.Split(' ');

            var reversedArr = sentenceArr.Select(word => new string(word.Reverse().ToArray()));

            var adjustUpperCases = sentenceArr.Zip(reversedArr, (x, y) => string.Join("", x.Select((ch, i) => char.IsUpper(ch) ?
                                                                                                              char.ToUpper(y[i]) :
                                                                                                              char.ToLower(y[i]))));

            return string.Join(" ", adjustUpperCases);
        }
    }
}
