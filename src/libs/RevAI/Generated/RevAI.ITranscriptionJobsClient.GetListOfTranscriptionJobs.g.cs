#nullable enable

namespace RevAI
{
    public partial interface ITranscriptionJobsClient
    {
        /// <summary>
        /// Get List of Transcription Jobs<br/>
        /// Gets a list of transcription jobs submitted within the last 30 days in reverse chronological order up to the provided limit number of jobs per call.
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="startingAfter"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<global::RevAI.TranscriptionJob>> GetListOfTranscriptionJobsAsync(
            int? limit = default,
            string? startingAfter = default,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}