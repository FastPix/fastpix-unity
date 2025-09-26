

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class SigningKeyWorkspaceDTO
    {

        /// <summary>
        /// FastPix generates a unique identifier for each workspace.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Designated title for the workspace.
        /// </summary>
        [SerializeField]
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Describes the type of a workspace.  Possible value: QA, staging, production, or development.
        /// </summary>
        [SerializeField]
        [JsonProperty("workspaceType")]
        public string? WorkspaceType { get; set; }
    }
}