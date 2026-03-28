#nullable enable

namespace RevAI
{
    public partial interface ITranscriptClient
    {
        /// <summary>
        /// Get Transcript<br/>
        /// Returns the transcript for a completed transcription job in JSON or plain text format.
        /// </summary>
        /// <param name="accept">
        /// Default Value: application/vnd.rev.transcript.v1.0+json
        /// </param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.Transcript> GetTranscriptAsync(
            string id,
            global::RevAI.GetTranscriptAccept? accept = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}