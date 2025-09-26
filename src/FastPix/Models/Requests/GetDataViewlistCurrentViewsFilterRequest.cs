

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetDataViewlistCurrentViewsFilterRequest
    {

        /// <summary>
        /// The dimension to group and breakdown the concurrent viewers data by.<br/>
        /// 
        /// <remarks>
        /// This determines how the results will be categorized and aggregated.<br/>
        /// Choose from geographic, content, technical, or behavioral dimensions.<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=dimension")]
        public GetDataViewlistCurrentViewsFilterDimension? Dimension { get; set; }

        /// <summary>
        /// Maximum number of results to return. Controls the number of dimension values<br/>
        /// 
        /// <remarks>
        /// that will be included in the response. Useful for pagination and performance.<br/>
        /// Higher limits provide more detailed breakdowns but may impact response time.<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; }
    }
}