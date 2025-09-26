

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class UpdatedSourceAccessRequestBody
    {

        /// <summary>
        /// The sourceAccess parameter determines whether the original media file is accessible. Set to true to enable access or false to restrict it.
        /// </summary>
        [SerializeField]
        [JsonProperty("sourceAccess")]
        public bool? SourceAccess { get; set; }
    }
}