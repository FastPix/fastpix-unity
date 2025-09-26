

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;
    
    [Serializable]
    public class ListBreakdownValuesRequest
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
        public ListBreakdownValuesMetricId MetricId { get; set; } = default!;

        /// <summary>
        /// This parameter specifies the time span between which the video views list should be retrieved by. You can provide either from and to unix epoch timestamps or time duration. The scope of duration is between 60 minutes to 30 days.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=timespan[]")]
        public ListBreakdownValuesTimespan Timespan { get; set; } = default!;

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

        /// <summary>
        /// Pass the offset value to indicate the page number.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=offset")]
        public long? Offset { get; set; }

        /// <summary>
        /// Pass this value to group the metrics list by.<br/>
        /// 
        /// <remarks>
        /// Possible Values : [&quot;browser_name&quot;, &quot;browser_version&quot;, &quot;os_name&quot;,&quot;os_version&quot; , &quot;device_name&quot;, &quot;device_model&quot;, &quot;device_type&quot;, &quot;device_manufacturer&quot;, &quot;player_remote_played&quot;,player_name&quot;, &quot;player_version&quot;, &quot;player_software_name&quot;, &quot;player_software_version&quot;, &quot;player_resolution&quot;, &quot;fp_sdk&quot;,&quot;fp_sdk_version&quot;, &quot;player_autoplay_on&quot;, &quot;player_preload_on&quot;,&quot;video_title&quot;,  &quot;video_id&quot;, &quot;video_series&quot; ,  &quot;fp_playback_id&quot;,&quot;fp_live_stream_id&quot;, &quot;media_id&quot;,&quot;video_source_stream_type&quot;, &quot;video_source_type&quot;, &quot;video_encoding_variant&quot;, &quot;experiment_name&quot;, &quot;sub_property_id&quot;, &quot;drm_type&quot;,&quot;asn_name&quot;, &quot;cdn&quot;, &quot;video_source_hostname&quot;, &quot;connection_type&quot;, &quot;view_session_id&quot;,&quot;continent&quot;,&quot;country&quot;, &quot;region&quot;,&quot;viewer_id&quot;, &quot;error_code&quot;, &quot;exit_before_video_start&quot;, &quot;view_has_ad&quot;, &quot;video_startup_failed&quot; , &quot;page_context&quot;, &quot;playback_failed&quot;.]<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=groupBy")]
        public string? GroupBy { get; set; }

        /// <summary>
        /// Pass this value to order the metrics list by.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=orderBy")]
        public string? OrderBy { get; set; }

        /// <summary>
        /// The order direction to sort the metrics list by.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=sortOrder")]
        public ListBreakdownValuesSortOrder? SortOrder { get; set; }

        /// <summary>
        /// The measurement for the given metrics.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=measurement")]
        public string? Measurement { get; set; }
    }
}