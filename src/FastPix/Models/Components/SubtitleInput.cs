

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Generates subtitle files for audio/video files.
    /// </summary>
    [Serializable]
    public class SubtitleInput
    {

        /// <summary>
        /// Defines the type of input.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        /// <summary>
        /// The direct URL of the subtitle file.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string Url { get; set; } = default!;

        /// <summary>
        /// Name of the language in which the subtitles will be generated.
        /// </summary>
        [SerializeField]
        [JsonProperty("languageName")]
        public string LanguageName { get; set; } = default!;

        /// <summary>
        /// Language code for content localization
        /// </summary>
        [SerializeField]
        [JsonProperty("languageCode")]
        public fastpix.io.Models.Components.LanguageCode LanguageCode { get; set; } = default!;
    }
}