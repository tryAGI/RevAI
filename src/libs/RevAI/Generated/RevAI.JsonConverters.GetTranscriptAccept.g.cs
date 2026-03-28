#nullable enable

namespace RevAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class GetTranscriptAcceptJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::RevAI.GetTranscriptAccept>
    {
        /// <inheritdoc />
        public override global::RevAI.GetTranscriptAccept Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::RevAI.GetTranscriptAcceptExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::RevAI.GetTranscriptAccept)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::RevAI.GetTranscriptAccept);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::RevAI.GetTranscriptAccept value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::RevAI.GetTranscriptAcceptExtensions.ToValueString(value));
        }
    }
}
