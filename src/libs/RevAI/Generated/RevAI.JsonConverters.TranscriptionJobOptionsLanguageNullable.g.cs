#nullable enable

namespace RevAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class TranscriptionJobOptionsLanguageNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::RevAI.TranscriptionJobOptionsLanguage?>
    {
        /// <inheritdoc />
        public override global::RevAI.TranscriptionJobOptionsLanguage? Read(
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
                        return global::RevAI.TranscriptionJobOptionsLanguageExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::RevAI.TranscriptionJobOptionsLanguage)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::RevAI.TranscriptionJobOptionsLanguage?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::RevAI.TranscriptionJobOptionsLanguage? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::RevAI.TranscriptionJobOptionsLanguageExtensions.ToValueString(value.Value));
            }
        }
    }
}
