

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Displays the result of the request.
    /// </summary>
    [Serializable]
    public class GetPublicPemUsingSigningKeyIdResponseDTOData
    {

        /// <summary>
        /// FastPix generates a unique identifier for each workspace.
        /// </summary>
        [SerializeField]
        [JsonProperty("workspaceId")]
        public string? WorkspaceId { get; set; }

        [SerializeField]
        [JsonProperty("signingKeyId")]
        public string? SigningKeyId { get; set; }

        /// <summary>
        /// A public key is a byte encoded key used to create a signed JSON Web Token (JWT) for authentication.
        /// </summary>
        [SerializeField]
        [JsonProperty("publicKey")]
        public string? PublicKey { get; set; }
    }
}