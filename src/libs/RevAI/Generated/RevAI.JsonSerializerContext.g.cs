
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace RevAI
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::RevAI.JsonConverters.TranscriptionJobOptionsLanguageJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptionJobOptionsLanguageNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.SubmitTranscriptionJobRequestLanguageJsonConverter),

            typeof(global::RevAI.JsonConverters.SubmitTranscriptionJobRequestLanguageNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptionJobStatusJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptionJobStatusNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptionJobTypeJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptionJobTypeNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptionJobFailureJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptionJobFailureNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptElementTypeJsonConverter),

            typeof(global::RevAI.JsonConverters.TranscriptElementTypeNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.SentimentAnalysisJobStatusJsonConverter),

            typeof(global::RevAI.JsonConverters.SentimentAnalysisJobStatusNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.SentimentMessageSentimentJsonConverter),

            typeof(global::RevAI.JsonConverters.SentimentMessageSentimentNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.TopicExtractionJobStatusJsonConverter),

            typeof(global::RevAI.JsonConverters.TopicExtractionJobStatusNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.LanguageIdentificationJobStatusJsonConverter),

            typeof(global::RevAI.JsonConverters.LanguageIdentificationJobStatusNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.GetTranscriptAcceptJsonConverter),

            typeof(global::RevAI.JsonConverters.GetTranscriptAcceptNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.GetCaptionsAcceptJsonConverter),

            typeof(global::RevAI.JsonConverters.GetCaptionsAcceptNullableJsonConverter),

            typeof(global::RevAI.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.ErrorResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.ValidationErrorResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IList<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.Account))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TranscriptionJobOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TranscriptionJobOptionsLanguage), TypeInfoPropertyName = "TranscriptionJobOptionsLanguage2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.CustomVocabulary>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.CustomVocabulary))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SubmitTranscriptionJobRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SubmitTranscriptionJobRequestLanguage), TypeInfoPropertyName = "SubmitTranscriptionJobRequestLanguage2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TranscriptionJob))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TranscriptionJobStatus), TypeInfoPropertyName = "TranscriptionJobStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TranscriptionJobType), TypeInfoPropertyName = "TranscriptionJobType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TranscriptionJobFailure), TypeInfoPropertyName = "TranscriptionJobFailure2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.Transcript))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.Monologue>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.Monologue))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.TranscriptElement>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TranscriptElement))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TranscriptElementType), TypeInfoPropertyName = "TranscriptElementType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SubmitSentimentAnalysisJobRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SentimentAnalysisJob))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SentimentAnalysisJobStatus), TypeInfoPropertyName = "SentimentAnalysisJobStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SentimentAnalysisResult))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.SentimentMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SentimentMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SentimentMessageSentiment), TypeInfoPropertyName = "SentimentMessageSentiment2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SubmitTopicExtractionJobRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TopicExtractionJob))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TopicExtractionJobStatus), TypeInfoPropertyName = "TopicExtractionJobStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TopicExtractionResult))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.Topic>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.Topic))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.TopicInformant>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.TopicInformant))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.LanguageIdentificationJobOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SubmitLanguageIdentificationJobRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.LanguageIdentificationJob))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.LanguageIdentificationJobStatus), TypeInfoPropertyName = "LanguageIdentificationJobStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.LanguageIdentificationResult))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.LanguageConfidence>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.LanguageConfidence))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SubmitTranscriptionJobRequest2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(byte[]))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.SubmitLanguageIdentificationJobRequest2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.GetTranscriptAccept), TypeInfoPropertyName = "GetTranscriptAccept2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::RevAI.GetCaptionsAccept), TypeInfoPropertyName = "GetCaptionsAccept2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.TranscriptionJob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.SentimentAnalysisJob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.TopicExtractionJob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::RevAI.LanguageIdentificationJob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.CustomVocabulary>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.Monologue>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.TranscriptElement>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.SentimentMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.Topic>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.TopicInformant>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.LanguageConfidence>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.TranscriptionJob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.SentimentAnalysisJob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.TopicExtractionJob>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::RevAI.LanguageIdentificationJob>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}