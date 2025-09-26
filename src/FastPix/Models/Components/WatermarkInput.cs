

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class WatermarkInput
    {

        /// <summary>
        /// Type of overlay (currently only supports &apos;watermark&apos;).
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public WatermarkInputType? Type { get; set; }

        /// <summary>
        /// URL of the watermark image.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string? Url { get; set; }

        [SerializeField]
        [JsonProperty("placement")]
        public Placement? Placement { get; set; }

        /// <summary>
        /// Width of the watermark in percentage or pixels.
        /// </summary>
        [SerializeField]
        [JsonProperty("width")]
        public string? Width { get; set; }

        /// <summary>
        /// Height of the watermark in percentage or pixels.
        /// </summary>
        [SerializeField]
        [JsonProperty("height")]
        public string? Height { get; set; }

        /// <summary>
        /// Opacity of the watermark in percentage.
        /// </summary>
        [SerializeField]
        [JsonProperty("opacity")]
        public string? Opacity { get; set; }
    }
}