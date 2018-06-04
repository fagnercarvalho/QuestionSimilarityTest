using QuestionSimilarityTest.Extensions;
using System;
using System.Linq;

namespace QuestionSimilarityTest.Similarity
{
    internal class Jaccard : ISimilarityAlgorithm
    {
        /// <summary>
        /// Method made to execute the Jaccard index to compare the similarity of two questions.
        /// 
        /// The Jaccard index is calculated as the intersection of words in the two questions over the union of words in the two questions.
        /// More details in the <a href="https://en.wikipedia.org/wiki/Jaccard_index">Wikipedia article about Jaccard index</a>.
        /// </summary>
        /// <param name="questionOne">Question one.</param>
        /// <param name="questionTwo">Question two.</param>
        /// <returns>Any float number between 0 if the questions are totally different or 1 if the questions are identical.</returns>
        public double Run(string questionOne, string questionTwo)
        {
            var questionOneWords = questionOne.ExtractShingles();
            var questionTwoWords = questionTwo.ExtractShingles();

            var numerator = questionOneWords
                .AsEnumerable()
                .Intersect(questionTwoWords.AsEnumerable())
                .Count();

            var denominator = questionOneWords
                .AsEnumerable()
                .Union(questionTwoWords.AsEnumerable())
                .Count();

            return Math.Round((double)numerator / denominator, 2);
        }
    }
}
