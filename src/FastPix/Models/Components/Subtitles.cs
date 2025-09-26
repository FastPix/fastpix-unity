

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
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
        /// Name of the language in which the subtitles will be generated.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
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

        /// <summary>
        /// Language codes are concise, standardized symbols that denote languages, utilizing either two or three characters for identification. The language code must be compliant with the BCP 47 standard to ensure compatibility. (for text only).<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("languageCode")]
        public CreateMediaRequestLanguageCode? LanguageCode { get; set; }
    }
}