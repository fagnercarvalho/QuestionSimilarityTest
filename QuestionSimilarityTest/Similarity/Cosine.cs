using QuestionSimilarityTest.Extensions;
using System;
using System.Linq;

namespace QuestionSimilarityTest.Similarity
{
    internal class Cosine : ISimilarityAlgorithm
    {
        /// <summary>
        /// Method made to execute the cosine similarity to compare the similarity of two questions.
        /// 
        /// More details in the <a href="https://en.wikipedia.org/wiki/Cosine_similarity">Wikipedia article about Cosine similarity</a>.
        /// </summary>
        /// <param name="questionOne">Question one.</param>
        /// <param name="questionTwo">Question two.</param>
        /// <returns>Any float number between 0 if the questions are totally different or 1 if the questions are identical.</returns>
        public double Run(string questionOne, string questionTwo)
        {
            var questionOneWords = questionOne.ExtractShingles();
            var questionTwoWords = questionTwo.ExtractShingles();

            var uniqueWords = questionOneWords
                .Union(questionTwoWords)
                .Distinct()
                .ToArray();

            var questionOneWordOccurrences = new int[uniqueWords.Length];
            var questionTwoWordOccurrences = new int[uniqueWords.Length];
            for (var i = 0; i < uniqueWords.Length; i++)
            {
                var word = uniqueWords[i];

                questionOneWordOccurrences[i] = Convert.ToInt32(questionOneWords.Contains(word));
                questionTwoWordOccurrences[i] = Convert.ToInt32(questionTwoWords.Contains(word));
            }

            double numerator = 0, questionOneDenominator = 0, questionTwoDenominator = 0;
            for (var j = 0; j < uniqueWords.Length; j++)
            {
                var questionOneWordOccurrence = questionOneWordOccurrences[j];
                var questionTwoWordOccurrence = questionTwoWordOccurrences[j];

                numerator += questionOneWordOccurrence * questionTwoWordOccurrence;
                questionOneDenominator += Math.Pow(questionOneWordOccurrence, 2);
                questionTwoDenominator += Math.Pow(questionTwoWordOccurrence, 2);
            }

            var denominator = Math.Sqrt(questionOneDenominator) * Math.Sqrt(questionTwoDenominator);

            return Math.Round(numerator / denominator, 2);
        }
    }
}
