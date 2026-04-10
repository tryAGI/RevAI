#nullable enable

namespace RevAI
{
    public partial interface ITranscriptionJobsClient
    {
        /// <summary>
        /// Delete Transcription Job<br/>
        /// Deletes a transcription job. All data related to the job will be permanently deleted. A job can only be deleted once it's completed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task DeleteTranscriptionJobAsync(
            string id,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}