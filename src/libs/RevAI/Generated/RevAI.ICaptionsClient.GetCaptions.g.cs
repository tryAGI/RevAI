#nullable enable

namespace RevAI
{
    public partial interface ICaptionsClient
    {
        /// <summary>
        /// Get Captions<br/>
        /// Returns caption output for a transcription job in SRT or VTT format.
        /// </summary>
        /// <param name="accept">
        /// Default Value: application/x-subrip
        /// </param>
        /// <param name="speakerChannel"></param>
        /// <param name="id"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<byte[]> GetCaptionsAsync(
            string id,
            global::RevAI.GetCaptionsAccept? accept = default,
            int? speakerChannel = default,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Get Captions<br/>
        /// Returns caption output for a transcription job in SRT or VTT format.
        /// </summary>
        /// <param name="accept">
        /// Default Value: application/x-subrip
        /// </param>
        /// <param name="speakerChannel"></param>
        /// <param name="id"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::System.IO.Stream> GetCaptionsAsStreamAsync(
            string id,
            global::RevAI.GetCaptionsAccept? accept = default,
            int? speakerChannel = default,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Get Captions<br/>
        /// Returns caption output for a transcription job in SRT or VTT format.
        /// </summary>
        /// <param name="accept">
        /// Default Value: application/x-subrip
        /// </param>
        /// <param name="speakerChannel"></param>
        /// <param name="id"></param>
        /// <returns>The response metadata and an unbuffered body stream. The caller must dispose Body to release the HTTP response.</returns>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.AutoSDKHttpResponse<global::System.IO.Stream>> GetCaptionsAsStreamAsResponseAsync(
            string id,
            global::RevAI.GetCaptionsAccept? accept = default,
            int? speakerChannel = default,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Get Captions<br/>
        /// Returns caption output for a transcription job in SRT or VTT format.
        /// </summary>
        /// <param name="accept">
        /// Default Value: application/x-subrip
        /// </param>
        /// <param name="speakerChannel"></param>
        /// <param name="id"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.AutoSDKHttpResponse<byte[]>> GetCaptionsAsResponseAsync(
            string id,
            global::RevAI.GetCaptionsAccept? accept = default,
            int? speakerChannel = default,
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}