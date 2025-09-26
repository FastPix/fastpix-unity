

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    /// <summary>
    /// Generates subtitle files for audio/video files.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    [Serializable]
    public class Subtitles
    {

        /// <summary>
        /// Name of the language for the subtitles.
        /// </summary>
        [SerializeField]
        [JsonProperty("languageName")]
        public string? LanguageName { get; set; }

        /// <summary>
        /// Tag a video in &quot;key&quot; : &quot;value&quot; pairs for searchable metadata. Maximum 10 entries, 255 characters each.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        /// <summary>
        /// Language codes (BCP 47 compliant) used for text files.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("languageCode")]
        public fastpix.io.Models.Requests.LanguageCode? LanguageCode { get; set; }
    }
}