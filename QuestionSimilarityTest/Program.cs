using QuestionSimilarityTest.Similarity;
using System;

namespace QuestionSimilarityTest
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var questionOne = "What is your zip code?";
            var questionTwo = "What is your postal code?";

            ISimilarityAlgorithm jaccardIndexAlgorithm = new Jaccard();
            var jaccardIndex = jaccardIndexAlgorithm.Run(questionOne, questionTwo);

            ISimilarityAlgorithm cosineSimilarityAlgorithm = new Cosine();
            var cosineSimilarity = cosineSimilarityAlgorithm.Run(questionOne, questionTwo);

            Console.WriteLine($"Jaccard similarity: {jaccardIndex}");
            Console.WriteLine($"Cosine similarity: {cosineSimilarity}");

            Console.Read();
        }
    }
}
