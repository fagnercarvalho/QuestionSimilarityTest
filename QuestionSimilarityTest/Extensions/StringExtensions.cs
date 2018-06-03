using System;

namespace QuestionSimilarityTest.Extensions
{
    public static class StringExtensions
    {
        public static string[] ExtractWords(this string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                throw new ArgumentException(nameof(sentence));
            }

            var words = sentence.Split(' ');

            return words;
        }
    }
}
