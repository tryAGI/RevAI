namespace RevAI.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static RevAIClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("REVAI_API_KEY") is { Length: > 0 } apiKeyValue
                ? apiKeyValue
                : throw new AssertInconclusiveException("REVAI_API_KEY environment variable is not found.");

        var client = new RevAIClient(apiKey);
        
        return client;
    }
}
