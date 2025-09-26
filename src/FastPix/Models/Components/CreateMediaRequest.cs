

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class CreateMediaRequest
    {

        [SerializeField]
        [JsonProperty("inputs")]
        public List<fastpix.io.Models.Components.Input> Inputs { get; set; } = default!;

        /// <summary>
        /// You can search for videos with specific key value pairs using metadata, when you tag a video in &quot;key&quot; : &quot;value&quot; pairs. Dynamic Metadata allows you to define a key that allows any value pair. You can have maximum of 255 characters and upto 10 entries are allowed.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        /// <summary>
        /// Generates subtitle files for audio/video files.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("subtitles")]
        public fastpix.io.Models.Components.Subtitles? Subtitles { get; set; }

        /// <summary>
        /// Determines whether access to the streamed content is kept private or available to all.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("accessPolicy")]
        public CreateMediaRequestAccessPolicy AccessPolicy { get; set; } = default!;

        /// <summary>
        /// &quot;capped_4k&quot;: Generates an mp4 video file up to 4k resolution &quot;audioOnly&quot;: Generates an m4a audio file of the media file &quot;audioOnly,capped_4k&quot;: Generates both video and audio media files for offline viewing<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("mp4Support")]
        public CreateMediaRequestMp4Support? Mp4Support { get; set; }

        /// <summary>
        /// The sourceAccess parameter determines whether the original media file is accessible. Set to true to enable access or false to restrict it
        /// </summary>
        [SerializeField]
        [JsonProperty("sourceAccess")]
        public bool? SourceAccess { get; set; }

        /// <summary>
        /// normalize volume of the audio track. This is available for pre-recorded content only.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("optimizeAudio")]
        public bool? OptimizeAudio { get; set; }

        /// <summary>
        /// The maximum resolution tier determines the highest quality your media will be available in.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("maxResolution")]
        public CreateMediaRequestMaxResolution? MaxResolution { get; set; }

        [SerializeField]
        [JsonProperty("summary")]
        public fastpix.io.Models.Components.Summary? Summary { get; set; }

        /// <summary>
        /// Enable or disable the chapters feature for the media. Set to `true` to enable chapters or `false` to disable.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("chapters")]
        public bool? Chapters { get; set; }

        /// <summary>
        /// Enable or disable named entity extraction. Set to `true` to enable or `false` to disable.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("namedEntities")]
        public bool? NamedEntities { get; set; }

        [SerializeField]
        [JsonProperty("moderation")]
        public Moderation? Moderation { get; set; }

        [SerializeField]
        [JsonProperty("accessRestrictions")]
        public CreateMediaRequestAccessRestrictions? AccessRestrictions { get; set; }
    }
}