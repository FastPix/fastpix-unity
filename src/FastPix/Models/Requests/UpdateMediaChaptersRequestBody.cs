

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class UpdateMediaChaptersRequestBody
    {

        /// <summary>
        /// Enable or disable the chapters feature for the media. Set to `true` to enable chapters or `false` to disable.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("chapters")]
        public bool Chapters { get; set; } = default!;
    }
}