

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetMediaClipsRequest
    {

        /// <summary>
        /// The unique identifier of the source media.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=sourceMediaId")]
        public string SourceMediaId { get; set; } = default!;

        /// <summary>
        /// Offset determines the starting point for data retrieval within a paginated list.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=offset")]
        public long? Offset { get; set; }

        /// <summary>
        /// The number of media clips to retrieve per request.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; }

        /// <summary>
        /// The values in the list can be arranged in two ways DESC (Descending) or ASC (Ascending).
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=orderBy")]
        public SortOrder? OrderBy { get; set; }
    }
}