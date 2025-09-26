

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Contains details about the track being added to the media file.
    /// </summary>
    [Serializable]
    public class AddTrackRequest
    {

        /// <summary>
        /// The direct URL of the track file. It should point to a valid audio or subtitle file.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Specifies the type of track being added. It can be either `audio` or `subtitle`.
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public AddTrackRequestType? Type { get; set; }

        /// <summary>
        /// The BCP 47 language code representing the track&apos;s language.
        /// </summary>
        [SerializeField]
        [JsonProperty("languageCode")]
        public string? LanguageCode { get; set; }

        /// <summary>
        /// The full name of the language corresponding to the `languageCode`.
        /// </summary>
        [SerializeField]
        [JsonProperty("languageName")]
        public string? LanguageName { get; set; }
    }
}