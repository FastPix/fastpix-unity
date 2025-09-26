

#nullable enable
namespace fastpix.io.Models.Components
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class Security
    {

        [SerializeField]
        [FastPixMetadata("security:scheme=true,type=http,subType=basic,name=username")]
        public string Username { get; set; } = default!;

        [SerializeField]
        [FastPixMetadata("security:scheme=true,type=http,subType=basic,name=password")]
        public string Password { get; set; } = default!;
    }
}