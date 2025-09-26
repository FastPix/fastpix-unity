

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class AddMediaTrackRequestBody
    {

        /// <summary>
        /// Contains details about the track being added to the media file.
        /// </summary>
        [SerializeField]
        [JsonProperty("tracks")]
        public AddTrackRequest? Tracks { get; set; }
    }
}