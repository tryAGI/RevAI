#nullable enable

namespace RevAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class TranscriptionJobStatusNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::RevAI.TranscriptionJobStatus?>
    {
        /// <inheritdoc />
        public override global::RevAI.TranscriptionJobStatus? Read(
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
                        return global::RevAI.TranscriptionJobStatusExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::RevAI.TranscriptionJobStatus)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::RevAI.TranscriptionJobStatus?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::RevAI.TranscriptionJobStatus? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::RevAI.TranscriptionJobStatusExtensions.ToValueString(value.Value));
            }
        }
    }
}
