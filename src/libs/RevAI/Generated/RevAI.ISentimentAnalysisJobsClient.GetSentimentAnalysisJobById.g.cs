#nullable enable

namespace RevAI
{
    public partial interface ISentimentAnalysisJobsClient
    {
        /// <summary>
        /// Get Sentiment Analysis Job By Id<br/>
        /// Returns information about a sentiment analysis job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.SentimentAnalysisJob> GetSentimentAnalysisJobByIdAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}