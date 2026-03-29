
#nullable enable

namespace RevAI
{
    /// <summary>
    /// Default Value: application/x-subrip
    /// </summary>
    public enum GetCaptionsAccept
    {
        /// <summary>
        /// application/x-subrip for SRT or text/vtt for VTT
        /// </summary>
        ApplicationDividexSubrip,
        /// <summary>
        /// application/x-subrip for SRT or text/vtt for VTT
        /// </summary>
        TextDividevtt,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class GetCaptionsAcceptExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GetCaptionsAccept value)
        {
            return value switch
            {
                GetCaptionsAccept.ApplicationDividexSubrip => "application/x-subrip",
                GetCaptionsAccept.TextDividevtt => "text/vtt",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GetCaptionsAccept? ToEnum(string value)
        {
            return value switch
            {
                "application/x-subrip" => GetCaptionsAccept.ApplicationDividexSubrip,
                "text/vtt" => GetCaptionsAccept.TextDividevtt,
                _ => null,
            };
        }
    }
}