

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;
    
    [Serializable]
    public class ListByTopContentRequest
    {

        /// <summary>
        /// This parameter specifies the time span between which the video views list should be retrieved by. You can provide either from and to unix epoch timestamps or time duration. The scope of duration is between 60 minutes to 30 days.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=timespan[]")]
        public ListByTopContentTimespan Timespan { get; set; } = default!;

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

        /// <summary>
        /// Pass the limit to display only the rows specified by the value.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; }
    }
}