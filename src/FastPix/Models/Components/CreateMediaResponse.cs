

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class CreateMediaResponse
    {

        /// <summary>
        /// The Media is assigned a universal unique identifier, which can contain a maximum of 255 characters.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// FastPix allows for a free trial. Create as many media files as you like during the trial period. Remember, each clip can only be 10 seconds long and will be deleted after 24 hours. Also, all trial content will have the FastPix logo watermark.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("trial")]
        public bool? Trial { get; set; }

        /// <summary>
        /// Determines the media&apos;s status, which can be one of the possible values.
        /// </summary>
        [SerializeField]
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Time the media was created, defined as a localDateTime (UTC Time).
        /// </summary>
        [SerializeField]
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Time the media was updated, defined as a localDateTime (UTC Time).
        /// </summary>
        [SerializeField]
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// A collection of Playback ID objects utilized for crafting HLS playback URLs.
        /// </summary>
        [SerializeField]
        [JsonProperty("playbackIds")]
        public List<PlaybackId>? PlaybackIds { get; set; }

        /// <summary>
        /// You can search for videos with specific key value pairs using metadata, when you tag a video in &quot;key&quot; : &quot;value&quot; pairs. Dynamic Metadata allows you to define a key that allows any value pair. You can have maximum of 255 characters and upto 10 entries are allowed.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        /// <summary>
        /// The maximum resolution tier determines the highest quality your media will be available in.
        /// </summary>
        [SerializeField]
        [JsonProperty("maxResolution")]
        public CreateMediaResponseMaxResolution? MaxResolution { get; set; }
    }
}