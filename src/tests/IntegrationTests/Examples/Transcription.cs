/* order: 10, title: Transcription, slug: transcription */

namespace RevAI.IntegrationTests.Examples;

[TestClass]
public class Transcription
{
    //// Submit a transcription job from an audio URL and retrieve the transcript.

    [TestMethod]
    public async Task SubmitTranscriptionJobFromUrl()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("REVAI_API_KEY") is { Length: > 0 } value
                ? value
                : throw new AssertInconclusiveException("REVAI_API_KEY environment variable is not found.");

        using var client = new RevAIClient(apiKey);

        //// Submit a transcription job by providing a URL to an audio file.
        var job = await client.TranscriptionJobs.SubmitTranscriptionJobAsync(
            mediaUrl: "https://www.rev.ai/FTC_Sample_1.mp3");

        //// The job runs asynchronously. Poll until it completes.
        while (job.Status == TranscriptionJobStatus.InProgress)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            job = await client.TranscriptionJobs.GetTranscriptionJobByIdAsync(id: job.Id!);
        }

        Assert.AreEqual(TranscriptionJobStatus.Transcribed, job.Status);

        //// Retrieve the transcript once the job is complete.
        var transcript = await client.Transcript.GetTranscriptAsync(id: job.Id!);
        Assert.IsNotNull(transcript.Monologues);
        Assert.IsTrue(transcript.Monologues.Count > 0);

        Console.WriteLine($"Transcript has {transcript.Monologues.Count} monologues");
    }
}
