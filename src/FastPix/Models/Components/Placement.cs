

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class Placement
    {

        /// <summary>
        /// Horizontal alignment of the watermark.
        /// </summary>
        [SerializeField]
        [JsonProperty("xAlign")]
        public XAlign? XAlign { get; set; }

        /// <summary>
        /// Horizontal margin from the edge of the video.
        /// </summary>
        [SerializeField]
        [JsonProperty("xMargin")]
        public string? XMargin { get; set; }

        /// <summary>
        /// Vertical alignment of the watermark.
        /// </summary>
        [SerializeField]
        [JsonProperty("yAlign")]
        public YAlign? YAlign { get; set; }

        /// <summary>
        /// Vertical margin from the edge of the video.
        /// </summary>
        [SerializeField]
        [JsonProperty("yMargin")]
        public string? YMargin { get; set; }
    }
}