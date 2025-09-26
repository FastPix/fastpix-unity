

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;
    
    [Serializable]
    public class ListOverallValuesRequest
    {

        /// <summary>
        /// Pass metric Id<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=metricId")]
        public ListOverallValuesMetricId MetricId { get; set; } = default!;

        /// <summary>
        /// The measurement for the given metrics.<br/>
        /// 
        /// <remarks>
        /// Possible Values : [95th, median, avg, count or sum]<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=measurement")]
        public string? Measurement { get; set; }

        /// <summary>
        /// This parameter specifies the time span between which the video views list should be retrieved by. You can provide either from and to unix epoch timestamps or time duration. The scope of duration is between 60 minutes to 30 days.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=timespan[]")]
        public ListOverallValuesTimespan Timespan { get; set; } = default!;

        /// <summary>
        /// Pass the dimensions and their corresponding values you want to filter the views by. For excluding the values in the filter we can pass &apos;!&apos; before the filter value. The list of filters can be obtained from list of dimensions endpoint.<br/>
        /// 
        /// <remarks>
        /// Example Values : [ browser_name:Chrome , os_name:macOS , device_name:Galaxy ]<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=filterby[]")]
        public string? Filterby { get; set; }
    }
}