

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class ListSigningKeysRequest
    {

        /// <summary>
        /// Limit specifies the maximum number of items to display per page.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=limit")]
        public double? Limit { get; set; }

        /// <summary>
        /// It is used for pagination, indicating the starting point for fetching data.  
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=offset")]
        public double? Offset { get; set; }
    }
}