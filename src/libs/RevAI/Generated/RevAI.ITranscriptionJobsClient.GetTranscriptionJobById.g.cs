#nullable enable

namespace RevAI
{
    public partial interface ITranscriptionJobsClient
    {
        /// <summary>
        /// Get Transcription Job By Id<br/>
        /// Returns information about a transcription job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.TranscriptionJob> GetTranscriptionJobByIdAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}