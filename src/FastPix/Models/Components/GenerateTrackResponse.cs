

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Represents the response for a successfully generated subtitle track.
    /// </summary>
    [Serializable]
    public class GenerateTrackResponse
    {

        /// <summary>
        /// A unique identifier for the generated track.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The type of track generated (&quot;subtitle&quot;).
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public GenerateTrackResponseType? Type { get; set; }

        /// <summary>
        /// The BCP 47 language code representing the language of the generated track.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("languageCode")]
        public GenerateTrackResponseLanguageCode? LanguageCode { get; set; }

        /// <summary>
        /// The full name of the language for the generated track.
        /// </summary>
        [SerializeField]
        [JsonProperty("languageName")]
        public string? LanguageName { get; set; }

        /// <summary>
        /// You can search for videos with specific key value pairs using metadata, when you tag a video in &quot;key&quot; : &quot;value&quot; pairs. Dynamic Metadata allows you to define a key that allows any value pair. You can have maximum of 255 characters and upto 10 entries are allowed.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }
    }
}