

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class MediaClipResponseTrack
    {

        /// <summary>
        /// The unique identifier for the media track.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The type of media track.
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public MediaClipResponseType? Type { get; set; }

        /// <summary>
        /// The width of the video track (applicable to video only).
        /// </summary>
        [SerializeField]
        [JsonProperty("width")]
        public long? Width { get; set; }

        /// <summary>
        /// The height of the video track (applicable to video only).
        /// </summary>
        [SerializeField]
        [JsonProperty("height")]
        public long? Height { get; set; }

        /// <summary>
        /// The current processing status of the track.
        /// </summary>
        [SerializeField]
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The language code of the audio or subtitle track.
        /// </summary>
        [SerializeField]
        [JsonProperty("languageCode")]
        public string? LanguageCode { get; set; }

        /// <summary>
        /// The language name of the audio or subtitle track.
        /// </summary>
        [SerializeField]
        [JsonProperty("languageName")]
        public string? LanguageName { get; set; }
    }
}