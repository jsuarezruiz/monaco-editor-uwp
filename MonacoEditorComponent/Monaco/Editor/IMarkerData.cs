﻿using Newtonsoft.Json;

namespace Monaco.Editor
{
    /// <summary>
    /// https://microsoft.github.io/monaco-editor/api/interfaces/monaco.editor.imarkerdata.html
    /// </summary>
    public interface IMarkerData : IRange
    {
        [JsonProperty("code")]
        string Code { get; }

        [JsonProperty("message")]
        string Message { get; }

        [JsonProperty("severity")]
        Severity Severity { get; }

        [JsonProperty("source")]
        string Source { get; }
    }
}
