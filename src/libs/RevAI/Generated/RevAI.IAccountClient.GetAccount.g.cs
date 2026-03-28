#nullable enable

namespace RevAI
{
    public partial interface IAccountClient
    {
        /// <summary>
        /// Get Account<br/>
        /// Get the developer's account information
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::RevAI.Account> GetAccountAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}