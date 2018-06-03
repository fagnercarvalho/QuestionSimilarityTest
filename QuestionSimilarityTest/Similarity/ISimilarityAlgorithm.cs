namespace QuestionSimilarityTest.Similarity
{
    /// <summary>
    /// A question similarity algorithm.
    /// </summary>
    internal interface ISimilarityAlgorithm
    {
        double Run(string questionOne, string questionTwo);
    }
}
