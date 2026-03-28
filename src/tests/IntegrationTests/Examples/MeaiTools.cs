/* order: 30, title: MEAI Tools, slug: meai-tools */

namespace RevAI.IntegrationTests.Examples;

[TestClass]
public class MeaiTools
{
    //// Rev.ai provides `AIFunction` tools that can be used with any `IChatClient`
    //// for function/tool calling scenarios.

    [TestMethod]
    public void CreateTools()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("REVAI_API_KEY") is { Length: > 0 } value
                ? value
                : throw new AssertInconclusiveException("REVAI_API_KEY environment variable is not found.");

        using var client = new RevAIClient(apiKey);

        //// Create tools for transcription, job status, and job listing.
        var transcribeTool = client.AsTranscribeUrlTool(defaultLanguage: "en");
        var getJobStatusTool = client.AsGetJobStatusTool();
        var listJobsTool = client.AsListJobsTool(defaultLimit: 5);

        Assert.AreEqual("RevAI_TranscribeUrl", transcribeTool.Name);
        Assert.AreEqual("RevAI_GetJobStatus", getJobStatusTool.Name);
        Assert.AreEqual("RevAI_ListJobs", listJobsTool.Name);

        //// These tools can be passed to any IChatClient that supports function calling.
        var tools = new[] { transcribeTool, getJobStatusTool, listJobsTool };
        Assert.AreEqual(3, tools.Length);
    }
}
