#nullable enable

namespace RevAI
{
    public partial interface ILanguageIdentificationJobsClient
    {
        /// <summary>
        /// Delete Language Identification Job<br/>
        /// Deletes a language identification job and all associated data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::RevAI.ApiException"></exception>
        global::System.Threading.Tasks.Task DeleteLanguageIdentificationJobAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}