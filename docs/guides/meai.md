# Microsoft.Extensions.AI Integration

!!! tip "Cross-SDK comparison"
    See the [centralized MEAI documentation](https://tryagi.github.io/docs/meai/) for feature matrices and comparisons across all tryAGI SDKs.

The RevAI SDK implements `ISpeechToTextClient` from [Microsoft.Extensions.AI](https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai) for speech-to-text transcription, plus `AIFunction` tool wrappers for use with any `IChatClient`.

## Installation

```bash
dotnet add package tryAGI.RevAI
```

## ISpeechToTextClient

The `RevAIClient` implements `ISpeechToTextClient` for speech-to-text transcription.
It supports both file upload and URL-based transcription, with automatic polling until the job completes.

### File-Based Transcription

Transcribe an audio file to text. The client uploads the audio via multipart form data, submits a transcription job, and polls until completion:

```csharp
using Microsoft.Extensions.AI;
using RevAI;

using var client = new RevAIClient(
    apiKey: Environment.GetEnvironmentVariable("REVAI_API_KEY")!);
ISpeechToTextClient sttClient = client;

using var audioStream = File.OpenRead("audio.mp3");
var response = await sttClient.GetTextAsync(audioStream);

Console.WriteLine(response.Text);
Console.WriteLine($"Duration: {response.StartTime} - {response.EndTime}");
```

### Transcription with Language Hint

Specify a language code for more accurate transcription (31 languages supported):

```csharp
ISpeechToTextClient sttClient = client;

using var audioStream = File.OpenRead("spanish-audio.mp3");
var response = await sttClient.GetTextAsync(audioStream, new SpeechToTextOptions
{
    SpeechLanguage = "es",
});

Console.WriteLine(response.Text);
```

### URL-Based Transcription with RawRepresentationFactory

Use `RawRepresentationFactory` to transcribe audio from a URL instead of uploading a file:

```csharp
ISpeechToTextClient sttClient = client;

var response = await sttClient.GetTextAsync(Stream.Null, new SpeechToTextOptions
{
    RawRepresentationFactory = _ => new SubmitTranscriptionJobRequest
    {
        MediaUrl = "https://example.com/meeting-recording.mp3",
    },
});

Console.WriteLine(response.Text);

// Access full Rev.ai transcript for advanced features (monologues, speaker info)
var raw = (Transcript)response.RawRepresentation!;
Console.WriteLine($"Monologues: {raw.Monologues?.Count}");
```

### Accessing the Underlying Client

Retrieve the `RevAIClient` from the MEAI interface:

```csharp
ISpeechToTextClient sttClient = client;

var metadata = sttClient.GetService<SpeechToTextClientMetadata>();
Console.WriteLine($"Provider: {metadata?.ProviderName}"); // "rev.ai"

var revClient = sttClient.GetService<RevAIClient>();
// Use revClient for Rev.ai-specific APIs (captions, sentiment analysis, topic extraction, etc.)
```

## Available Tools

| Method | Tool Name | Description |
|--------|-----------|-------------|
| `AsTranscribeUrlTool()` | `RevAI_TranscribeUrl` | Transcribe audio/video from URL |
| `AsGetJobStatusTool()` | `RevAI_GetJobStatus` | Get transcription job status |
| `AsListJobsTool()` | `RevAI_ListJobs` | List recent transcription jobs |

## Usage

```csharp
using Microsoft.Extensions.AI;
using RevAI;

var client = new RevAIClient(
    apiKey: Environment.GetEnvironmentVariable("REVAI_API_KEY")!);

var options = new ChatOptions
{
    Tools = [client.AsTranscribeUrlTool()],
};

IChatClient chatClient = /* your chat client */;

var messages = new List<ChatMessage>
{
    new(ChatRole.User, "Transcribe the audio at https://example.com/meeting.mp3"),
};

while (true)
{
    var response = await chatClient.GetResponseAsync(messages, options);
    messages.AddRange(response.ToChatMessages());

    if (response.FinishReason == ChatFinishReason.ToolCalls)
    {
        var results = await response.CallToolsAsync(options);
        messages.AddRange(results);
        continue;
    }

    Console.WriteLine(response.Text);
    break;
}
```
