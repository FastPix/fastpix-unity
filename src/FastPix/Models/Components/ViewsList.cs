

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class ViewsList
    {

        /// <summary>
        /// The unique identifier for the viewing session of the user.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewId")]
        public string ViewId { get; set; } = default!;

        /// <summary>
        /// Operating System signifies the software platform utilized by the viewer<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("operatingSystem", NullValueHandling = NullValueHandling.Include)]
        public string? OperatingSystem { get; set; } = default!;

        /// <summary>
        /// The browser name of the viewer.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("application", NullValueHandling = NullValueHandling.Include)]
        public string? Application { get; set; } = default!;

        /// <summary>
        /// The start timestamp of the video view.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewStartTime", NullValueHandling = NullValueHandling.Include)]
        public string? ViewStartTime { get; set; } = default!;

        /// <summary>
        /// The end timestamp of the video view.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewEndTime", NullValueHandling = NullValueHandling.Include)]
        public string? ViewEndTime { get; set; } = default!;

        /// <summary>
        /// The title of the Video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoTitle", NullValueHandling = NullValueHandling.Include)]
        public string? VideoTitle { get; set; } = default!;

        /// <summary>
        /// The code which represents specific issues or failures that occur during playback. These can be implementation specific.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("errorCode")]
        public string? ErrorCode { get; set; }

        /// <summary>
        /// The notifications or messages that inform users or developers about issues or failures that have occurred during the playback representing error codes.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("errorMessage")]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// The unique identifier which identifies each type of error that occurs.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("errorId")]
        public long? ErrorId { get; set; }

        /// <summary>
        /// Country of the viewer.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("country", NullValueHandling = NullValueHandling.Include)]
        public string? Country { get; set; } = default!;

        /// <summary>
        /// The watch time represents the time spent watching the video including staruptime, playback time ,buffering time.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewWatchTime")]
        public double? ViewWatchTime { get; set; }

        /// <summary>
        /// The viewer experience encapsulated in the form of score while watching the video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("QoeScore")]
        public double? QoeScore { get; set; }
    }
}