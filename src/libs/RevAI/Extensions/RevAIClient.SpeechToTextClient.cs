#nullable enable

using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.AI;

namespace RevAI;

public partial class RevAIClient : ISpeechToTextClient
{
    private SpeechToTextClientMetadata? _speechMetadata;

    /// <inheritdoc />
    object? ISpeechToTextClient.GetService(Type serviceType, object? serviceKey) =>
        serviceType is null ? throw new ArgumentNullException(nameof(serviceType)) :
        serviceKey is not null ? null :
        serviceType == typeof(SpeechToTextClientMetadata) ? (_speechMetadata ??= new("rev.ai", new Uri(DefaultBaseUrl))) :
        serviceType.IsInstanceOfType(this) ? this :
        null;

    /// <inheritdoc />
    async Task<SpeechToTextResponse> ISpeechToTextClient.GetTextAsync(
        Stream audioSpeechStream,
        SpeechToTextOptions? options,
        CancellationToken cancellationToken)
    {
        _ = audioSpeechStream ?? throw new ArgumentNullException(nameof(audioSpeechStream));

        // Submit transcription job via URL if provided via RawRepresentationFactory,
        // otherwise use multipart file upload
        string? mediaUrl = (options?.RawRepresentationFactory?.Invoke(this) as SubmitTranscriptionJobRequest)?.MediaUrl;

        TranscriptionJob job;
        if (mediaUrl is { Length: > 0 })
        {
            job = await TranscriptionJobs.SubmitTranscriptionJobAsync(
                mediaUrl: mediaUrl,
                language: options?.SpeechLanguage is { Length: > 0 } lang
                    ? SubmitTranscriptionJobRequestLanguageExtensions.ToEnum(lang)
                    : null,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        else
        {
            // Upload audio via multipart/form-data manually
            job = await SubmitMultipartTranscriptionJobAsync(
                audioStream: audioSpeechStream,
                language: options?.SpeechLanguage,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        // Poll until job completes
        while (job.Status == TranscriptionJobStatus.InProgress)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken).ConfigureAwait(false);
            job = await TranscriptionJobs.GetTranscriptionJobByIdAsync(
                id: job.Id!,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        if (job.Status == TranscriptionJobStatus.Failed)
        {
            throw new InvalidOperationException(
                $"Rev.ai transcription job {job.Id} failed: {job.FailureDetail ?? job.Failure?.ToValueString() ?? "unknown error"}");
        }

        // Get transcript
        var transcript = await Transcript.GetTranscriptAsync(
            id: job.Id!,
            cancellationToken: cancellationToken).ConfigureAwait(false);

        // Build full text from monologues
        var textBuilder = new StringBuilder();
        if (transcript.Monologues is { Count: > 0 })
        {
            foreach (var monologue in transcript.Monologues)
            {
                if (monologue.Elements is not { Count: > 0 }) continue;
                foreach (var element in monologue.Elements)
                {
                    if (element.Value is { Length: > 0 })
                    {
                        textBuilder.Append(element.Value);
                    }
                }
            }
        }

        TimeSpan? endTime = job.DurationSeconds > 0
            ? TimeSpan.FromSeconds(job.DurationSeconds.Value)
            : null;

        return new SpeechToTextResponse(textBuilder.ToString().Trim())
        {
            RawRepresentation = transcript,
            ResponseId = job.Id,
            StartTime = TimeSpan.Zero,
            EndTime = endTime,
        };
    }

    /// <inheritdoc />
    async IAsyncEnumerable<SpeechToTextResponseUpdate> ISpeechToTextClient.GetStreamingTextAsync(
        Stream audioSpeechStream,
        SpeechToTextOptions? options,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Rev.ai doesn't have a streaming REST API — use the non-streaming path
        var response = await ((ISpeechToTextClient)this).GetTextAsync(
            audioSpeechStream, options, cancellationToken).ConfigureAwait(false);

        yield return new SpeechToTextResponseUpdate
        {
            Kind = SpeechToTextResponseUpdateKind.SessionOpen,
            ResponseId = response.ResponseId,
        };

        yield return new SpeechToTextResponseUpdate(response.Text)
        {
            Kind = SpeechToTextResponseUpdateKind.TextUpdated,
            ResponseId = response.ResponseId,
            StartTime = response.StartTime,
            EndTime = response.EndTime,
            RawRepresentation = response.RawRepresentation,
        };

        yield return new SpeechToTextResponseUpdate
        {
            Kind = SpeechToTextResponseUpdateKind.SessionClose,
            ResponseId = response.ResponseId,
        };
    }

    private async Task<TranscriptionJob> SubmitMultipartTranscriptionJobAsync(
        Stream audioStream,
        string? language,
        CancellationToken cancellationToken)
    {
        using var content = new MultipartFormDataContent();
        using var streamContent = new StreamContent(audioStream);
        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/mpeg");
        content.Add(streamContent, "media", "audio.mp3");

        if (language is { Length: > 0 })
        {
#pragma warning disable CA2000 // MultipartFormDataContent disposes its children
            content.Add(new StringContent($"{{\"language\":\"{language}\"}}",
                Encoding.UTF8, "application/json"), "options");
#pragma warning restore CA2000
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, "/speechtotext/v1/jobs")
        {
            Content = content,
        };

        foreach (var authorization in TranscriptionJobs.Authorizations)
        {
            if (authorization.Type is "Http" or "OAuth2")
            {
                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        authorization.Name, authorization.Value);
            }
        }

        var httpClient = TranscriptionJobs.HttpClient;
        using var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return TranscriptionJob.FromJson(responseContent, TranscriptionJobs.JsonSerializerContext)
               ?? throw new InvalidOperationException("Failed to deserialize transcription job response.");
    }
}
