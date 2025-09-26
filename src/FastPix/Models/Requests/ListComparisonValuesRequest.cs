

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;
    
    [Serializable]
    public class ListComparisonValuesRequest
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
        public ListComparisonValuesTimespan Timespan { get; set; } = default!;

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
        /// The dimension id in which the views are watched.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=dimension")]
        public ListComparisonValuesDimension? Dimension { get; set; }

        /// <summary>
        /// The value for the selected dimension. <br/>
        /// 
        /// <remarks>
        /// For example:<br/>
        ///  If `dimension` is `browser_name`, the value could be  `Chrome` `,` `Firefox` `etc` .<br/>
        ///  If `dimension` is `os_name`, the value could be `macOS` `,` `Windows` `etc` .<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=value")]
        public string? Value { get; set; }
    }
}