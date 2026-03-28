
#nullable enable

namespace RevAI
{
    /// <summary>
    /// Topic Extraction Result
    /// </summary>
    public sealed partial class TopicExtractionResult
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("topics")]
        public global::System.Collections.Generic.IList<global::RevAI.Topic>? Topics { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicExtractionResult" /> class.
        /// </summary>
        /// <param name="topics"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TopicExtractionResult(
            global::System.Collections.Generic.IList<global::RevAI.Topic>? topics)
        {
            this.Topics = topics;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicExtractionResult" /> class.
        /// </summary>
        public TopicExtractionResult()
        {
        }
    }
}