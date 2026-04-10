#nullable enable

namespace RevAI
{
    public partial interface ITopicExtractionJobsClient
    {
        /// <summary>
        /// Get Topic Extraction Job By Id<br/>
        /// Returns information about a topic extraction job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.TopicExtractionJob> GetTopicExtractionJobByIdAsync(
            string id,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}