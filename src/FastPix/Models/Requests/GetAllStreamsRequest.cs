

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetAllStreamsRequest
    {

        /// <summary>
        /// Limit specifies the maximum number of items to display per page.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; }

        /// <summary>
        /// Offset determines the starting point for data retrieval within a paginated list.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=offset")]
        public long? Offset { get; set; }

        /// <summary>
        /// The list of value can be order in two ways DESC (Descending) or ASC (Ascending). In case not specified, by default it will be DESC.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=orderBy")]
        public OrderBy? OrderBy { get; set; }
    }
}