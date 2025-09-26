

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Contains details about the track that was added or updated.
    /// </summary>
    [Serializable]
    public class AddTrackResponse
    {

        /// <summary>
        /// The unique identifier of the track.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Specifies the type of track (audio or subtitle).
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public AddTrackResponseType? Type { get; set; }

        /// <summary>
        /// The direct URL of the track file.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string? Url { get; set; }

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