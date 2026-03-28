#nullable enable

namespace RevAI
{
    public partial interface ITopicExtractionJobsClient
    {
        /// <summary>
        /// Submit Topic Extraction Job<br/>
        /// Starts an asynchronous topic extraction job. Input can be plain text, a JSON transcript, or reference a completed transcription job.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.TopicExtractionJob> SubmitTopicExtractionJobAsync(

            global::RevAI.SubmitTopicExtractionJobRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Submit Topic Extraction Job<br/>
        /// Starts an asynchronous topic extraction job. Input can be plain text, a JSON transcript, or reference a completed transcription job.
        /// </summary>
        /// <param name="json">
        /// Rev.ai Transcript
        /// </param>
        /// <param name="text">
        /// Plain text to extract topics from
        /// </param>
        /// <param name="metadata"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="language"></param>
        /// <param name="deleteAfterSeconds"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.TopicExtractionJob> SubmitTopicExtractionJobAsync(
            global::RevAI.Transcript? json = default,
            string? text = default,
            string? metadata = default,
            string? callbackUrl = default,
            string? language = default,
            int? deleteAfterSeconds = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}