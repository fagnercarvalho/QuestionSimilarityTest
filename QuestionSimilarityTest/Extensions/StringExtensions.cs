using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionSimilarityTest.Extensions
{
    public static class StringExtensions
    {
        private const int DefaultNGrams = 1;

        public static string[] ExtractShingles(this string sentence)
        {
            return ExtractShingles(sentence, DefaultNGrams);
        }

        public static string[] ExtractShingles(this string sentence, int ngrams)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                throw new ArgumentException(nameof(sentence));
            }

            var words = sentence.Split(' ').ToList();

            if (words.Count < ngrams)
            {
                throw new ArgumentException(nameof(sentence));
            }

            if (words.Count == ngrams)
            {
                return new string[] { sentence };
            }

            var shingles = new List<string>();

            for(int i = 0; i <= words.Count - ngrams;  i++)
            {
                var shingle = string.Join(' ', words.Skip(i).Take(ngrams));
                shingles.Add(shingle);
            }

            return shingles.Distinct().ToArray();
        }
    }
}
