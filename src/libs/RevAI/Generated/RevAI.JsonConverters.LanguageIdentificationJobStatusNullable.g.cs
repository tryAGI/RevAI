#nullable enable

namespace RevAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class LanguageIdentificationJobStatusNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::RevAI.LanguageIdentificationJobStatus?>
    {
        /// <inheritdoc />
        public override global::RevAI.LanguageIdentificationJobStatus? Read(
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
                        return global::RevAI.LanguageIdentificationJobStatusExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::RevAI.LanguageIdentificationJobStatus)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::RevAI.LanguageIdentificationJobStatus?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::RevAI.LanguageIdentificationJobStatus? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::RevAI.LanguageIdentificationJobStatusExtensions.ToValueString(value.Value));
            }
        }
    }
}
