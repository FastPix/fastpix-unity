

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class Event
    {

        /// <summary>
        /// Name of the event.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("event_name")]
        public string? EventName { get; set; }

        /// <summary>
        /// The unix epoch timestamp when the event was captured.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("event_time")]
        public EventTime? EventTime { get; set; }

        /// <summary>
        /// The unix epoch timestamp which represents the actual time the event has occured.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewer_time")]
        public long? ViewerTime { get; set; }

        /// <summary>
        /// The player_playhead_time represents the current position of the playhead (the point in the video that is being watched) on the video seekbar, measured in milliseconds. This value indicates how far into the video playback has progressed at any given moment.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("player_playhead_time")]
        public long? PlayerPlayheadTime { get; set; }

        [SerializeField]
        [JsonProperty("details")]
        public Details? Details { get; set; }
    }
}