#nullable enable

namespace RevAI
{
    public partial interface IAccountClient
    {
        /// <summary>
        /// Get Account<br/>
        /// Get the developer's account information
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.Account> GetAccountAsync(
            global::RevAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}