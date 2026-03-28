/* order: 20, title: Speech-to-Text (MEAI), slug: speech-to-text */

using Microsoft.Extensions.AI;

namespace RevAI.IntegrationTests.Examples;

[TestClass]
public class SpeechToText
{
    //// Use Rev.ai as an `ISpeechToTextClient` from Microsoft.Extensions.AI.

    [TestMethod]
    public async Task TranscribeWithMeai()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("REVAI_API_KEY") is { Length: > 0 } value
                ? value
                : throw new AssertInconclusiveException("REVAI_API_KEY environment variable is not found.");

        using var client = new RevAIClient(apiKey);
        ISpeechToTextClient sttClient = client;

        //// Provide an audio URL via RawRepresentationFactory.
        var options = new SpeechToTextOptions
        {
            SpeechLanguage = "en",
            RawRepresentationFactory = _ => new SubmitTranscriptionJobRequest
            {
                MediaUrl = "https://www.rev.ai/FTC_Sample_1.mp3",
            },
        };

        //// Get the transcription result.
        var response = await sttClient.GetTextAsync(
            audioSpeechStream: Stream.Null,
            options: options);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.Text.Length > 0);
        Console.WriteLine($"Transcript: {response.Text[..Math.Min(200, response.Text.Length)]}...");
    }
}
