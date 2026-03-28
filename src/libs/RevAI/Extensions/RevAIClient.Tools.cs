#nullable enable

using System.ComponentModel;
using Microsoft.Extensions.AI;

namespace RevAI;

public static class RevAIClientTools
{
    /// <summary>
    /// Creates an AIFunction tool that submits a transcription job from a media URL
    /// and polls until completion.
    /// </summary>
    public static AIFunction AsTranscribeUrlTool(
        this RevAIClient client,
        string? defaultLanguage = null)
    {
        return AIFunctionFactory.Create(
            method: async (
                [Description("The URL of the audio/video file to transcribe")] string mediaUrl,
                [Description("Language code (e.g., 'en', 'es', 'fr'). Optional.")] string? language,
                CancellationToken cancellationToken) =>
            {
                var lang = language ?? defaultLanguage;
                var job = await client.TranscriptionJobs.SubmitTranscriptionJobAsync(
                    mediaUrl: mediaUrl,
                    language: lang is { Length: > 0 }
                        ? SubmitTranscriptionJobRequestLanguageExtensions.ToEnum(lang)
                        : null,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                while (job.Status == TranscriptionJobStatus.InProgress)
                {
                    await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken).ConfigureAwait(false);
                    job = await client.TranscriptionJobs.GetTranscriptionJobByIdAsync(
                        id: job.Id!,
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }

                if (job.Status == TranscriptionJobStatus.Failed)
                {
                    return $"Transcription failed: {job.FailureDetail ?? "unknown error"}";
                }

                var transcript = await client.Transcript.GetTranscriptAsync(
                    id: job.Id!,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var text = string.Join(" ", transcript.Monologues?
                    .SelectMany(m => m.Elements ?? [])
                    .Where(e => e.Value is { Length: > 0 })
                    .Select(e => e.Value) ?? []);

                return text.Trim();
            },
            name: "RevAI_TranscribeUrl",
            description: "Transcribe an audio/video file from a URL using Rev.ai speech-to-text. Returns the transcript text.");
    }

    /// <summary>
    /// Creates an AIFunction tool that gets the status of a transcription job.
    /// </summary>
    public static AIFunction AsGetJobStatusTool(this RevAIClient client)
    {
        return AIFunctionFactory.Create(
            method: async (
                [Description("The transcription job ID")] string jobId,
                CancellationToken cancellationToken) =>
            {
                var job = await client.TranscriptionJobs.GetTranscriptionJobByIdAsync(
                    id: jobId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return new
                {
                    job.Id,
                    Status = job.Status?.ToValueString(),
                    job.Language,
                    job.DurationSeconds,
                    job.FailureDetail,
                };
            },
            name: "RevAI_GetJobStatus",
            description: "Get the status and details of a Rev.ai transcription job.");
    }

    /// <summary>
    /// Creates an AIFunction tool that lists recent transcription jobs.
    /// </summary>
    public static AIFunction AsListJobsTool(
        this RevAIClient client,
        int defaultLimit = 10)
    {
        return AIFunctionFactory.Create(
            method: async (
                [Description("Maximum number of jobs to return")] int? limit,
                CancellationToken cancellationToken) =>
            {
                var jobs = await client.TranscriptionJobs.GetListOfTranscriptionJobsAsync(
                    limit: limit ?? defaultLimit,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return jobs?.Select(j => new
                {
                    j.Id,
                    Status = j.Status?.ToValueString(),
                    j.Language,
                    j.DurationSeconds,
                    j.CreatedOn,
                }) ?? [];
            },
            name: "RevAI_ListJobs",
            description: "List recent Rev.ai transcription jobs with their status.");
    }
}
