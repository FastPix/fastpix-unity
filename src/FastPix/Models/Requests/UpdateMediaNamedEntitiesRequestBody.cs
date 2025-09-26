

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class UpdateMediaNamedEntitiesRequestBody
    {

        /// <summary>
        /// Enable or disable named entity extraction. Set to `true` to enable or `false` to disable.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("namedEntities")]
        public bool NamedEntities { get; set; } = default!;
    }
}