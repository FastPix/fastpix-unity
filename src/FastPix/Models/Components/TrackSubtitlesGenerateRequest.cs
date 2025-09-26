

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Contains details for generating subtitle tracks for a media file.
    /// </summary>
    [Serializable]
    public class TrackSubtitlesGenerateRequest
    {

        /// <summary>
        /// The full name of the language in which subtitles will be generated.
        /// </summary>
        [SerializeField]
        [JsonProperty("languageName")]
        public string LanguageName { get; set; } = default!;

        /// <summary>
        /// You can search for videos with specific key value pairs using metadata, when you tag a video in &quot;key&quot; : &quot;value&quot; pairs. Dynamic Metadata allows you to define a key that allows any value pair. You can have maximum of 255 characters and upto 10 entries are allowed.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        /// <summary>
        /// Language code for content localization
        /// </summary>
        [SerializeField]
        [JsonProperty("languageCode")]
        public fastpix.io.Models.Components.LanguageCode LanguageCode { get; set; } = default!;
    }
}