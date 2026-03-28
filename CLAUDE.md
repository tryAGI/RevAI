# CLAUDE.md — Rev.ai SDK

## Overview

Auto-generated C# SDK for [Rev.ai](https://www.rev.ai/) — speech-to-text transcription, sentiment analysis, topic extraction, and language identification.
OpenAPI spec from `https://raw.githubusercontent.com/APIs-guru/openapi-directory/main/APIs/rev.ai/v1/openapi.yaml` (manually extended with sentiment/topics/lang-id).

## Build & Test

```bash
dotnet build RevAI.slnx
dotnet test src/tests/IntegrationTests/
```

## Auth

Bearer token auth:

```csharp
var client = new RevAIClient(apiKey); // REVAI_API_KEY env var
```

## Key Files

- `src/libs/RevAI/openapi.yaml` — OpenAPI spec (manually extended from APIs-guru base)
- `src/libs/RevAI/generate.sh` — Runs autosdk on local spec
- `src/libs/RevAI/Generated/` — **Never edit** — auto-generated code
- `src/libs/RevAI/Extensions/RevAIClient.SpeechToTextClient.cs` — MEAI `ISpeechToTextClient` implementation
- `src/libs/RevAI/Extensions/RevAIClient.Tools.cs` — MEAI `AIFunction` tools
- `src/tests/IntegrationTests/Tests.cs` — Test helper with bearer auth
- `src/tests/IntegrationTests/Examples/` — Example tests (also generate docs)

## Sub-client Pattern

```csharp
var client = new RevAIClient(apiKey);

// Transcription jobs
client.TranscriptionJobs.SubmitTranscriptionJobAsync(...)
client.TranscriptionJobs.GetTranscriptionJobByIdAsync(...)
client.TranscriptionJobs.GetListOfTranscriptionJobsAsync(...)
client.TranscriptionJobs.DeleteTranscriptionJobAsync(...)

// Transcript retrieval
client.Transcript.GetTranscriptAsync(...)

// Captions
client.Captions.GetCaptionsAsync(...)

// Account
client.Account.GetAccountAsync(...)

// Sentiment analysis
client.SentimentAnalysisJobs.SubmitSentimentAnalysisJobAsync(...)

// Topic extraction
client.TopicExtractionJobs.SubmitTopicExtractionJobAsync(...)

// Language identification
client.LanguageIdentificationJobs.SubmitLanguageIdentificationJobAsync(...)
```

## MEAI Integration

`ISpeechToTextClient` — submit transcription job (URL or file upload), poll for completion, return transcript:
```csharp
ISpeechToTextClient sttClient = client;
var response = await sttClient.GetTextAsync(audioStream, options);
```

AIFunction tools for use with any `IChatClient`:
- `AsTranscribeUrlTool(defaultLanguage)` — Transcribe audio/video from URL (submit + poll + get transcript)
- `AsGetJobStatusTool()` — Get transcription job status and details
- `AsListJobsTool(defaultLimit)` — List recent transcription jobs

## Spec Notes

- Base URL: `https://api.rev.ai`
- Spec manually extended to include sentiment analysis, topic extraction, and language identification APIs
- Multipart file upload handled manually in ISpeechToTextClient (AutoSDK generates JSON-only paths)
- 31 languages supported for transcription
