

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    [Serializable]
    public class UpdatedMp4SupportRequestBody
    {

        /// <summary>
        /// Determines the type of MP4 support for the media.   - **none**: Disables MP4 support.   - **capped_4k**: Enables MP4 downloads with resolutions up to 4K.   - **audioOnly**: Provides an MP4 stream containing only the audio.   - **audioOnly,capped_4k**: Enables both MP4 video downloads (up to 4K) and an audio-only stream.  
        /// </summary>
        [SerializeField]
        [JsonProperty("mp4Support")]
        public UpdatedMp4SupportMp4Support? Mp4Support { get; set; }
    }
}