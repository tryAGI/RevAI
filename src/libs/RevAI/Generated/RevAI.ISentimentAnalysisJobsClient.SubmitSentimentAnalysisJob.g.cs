#nullable enable

namespace RevAI
{
    public partial interface ISentimentAnalysisJobsClient
    {
        /// <summary>
        /// Submit Sentiment Analysis Job<br/>
        /// Starts an asynchronous sentiment analysis job. Input can be plain text, a JSON transcript, or reference a completed transcription job.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.SentimentAnalysisJob> SubmitSentimentAnalysisJobAsync(

            global::RevAI.SubmitSentimentAnalysisJobRequest request,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Submit Sentiment Analysis Job<br/>
        /// Starts an asynchronous sentiment analysis job. Input can be plain text, a JSON transcript, or reference a completed transcription job.
        /// </summary>
        /// <param name="json">
        /// Rev.ai Transcript
        /// </param>
        /// <param name="text">
        /// Plain text to analyze for sentiment
        /// </param>
        /// <param name="metadata">
        /// Optional metadata
        /// </param>
        /// <param name="callbackUrl">
        /// Optional callback URL
        /// </param>
        /// <param name="language">
        /// Language of the input text
        /// </param>
        /// <param name="deleteAfterSeconds">
        /// Auto-delete job after this many seconds
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.SentimentAnalysisJob> SubmitSentimentAnalysisJobAsync(
            global::RevAI.Transcript? json = default,
            string? text = default,
            string? metadata = default,
            string? callbackUrl = default,
            string? language = default,
            int? deleteAfterSeconds = default,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}