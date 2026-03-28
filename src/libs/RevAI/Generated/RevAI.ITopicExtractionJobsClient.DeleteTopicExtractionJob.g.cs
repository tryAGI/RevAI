#nullable enable

namespace RevAI
{
    public partial interface ITopicExtractionJobsClient
    {
        /// <summary>
        /// Delete Topic Extraction Job<br/>
        /// Deletes a topic extraction job and all associated data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task DeleteTopicExtractionJobAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}