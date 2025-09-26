

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Displays the result of the request.
    /// </summary>
    [Serializable]
    public class Views
    {

        /// <summary>
        /// The Name associated with the asnId.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("asnName")]
        public string? AsnName { get; set; }

        /// <summary>
        /// The unique identifier assigned to an Autonomous System (AS) on the Internet. The ASN is used to identify and exchange routing information between different networks.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("asnId")]
        public long? AsnId { get; set; }

        /// <summary>
        /// The media Id value if the video asset is internal to FastPix.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("mediaId")]
        public string? MediaId { get; set; }

        /// <summary>
        /// Buffer Count represents the number of rebuffering events occurring during the video view.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("bufferCount")]
        public long? BufferCount { get; set; }

        /// <summary>
        /// Buffer Fill indicates the total time, in milliseconds, that viewers wait for rebuffering per video view.         <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("bufferFill")]
        public long? BufferFill { get; set; }

        /// <summary>
        /// Buffer Frequency measures the rate at which rebuffering events occur, expressed as events per millisecond.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("BufferFrequency")]
        public double? BufferFrequency { get; set; }

        /// <summary>
        /// Content Delivery Network (CDN) refers to the network infrastructure responsible for delivering the video content to the viewer.        <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("cdn")]
        public string? Cdn { get; set; }

        /// <summary>
        /// City indicates the geographical location of the viewer accessing the video content.        <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("city")]
        public string? City { get; set; }

        /// <summary>
        /// Continent represents the continent name of the viewer accessing the video content.    <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("continent")]
        public string? Continent { get; set; }

        /// <summary>
        /// Country Code denotes the two-letter ISO code representing the country of origin for the viewer accessing the video content.      <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("countryCode")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Country represents the coded text that represents the country name of viewer accessing the video content.      <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("country")]
        public string? Country { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom1")]
        public string? Custom1 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom2")]
        public string? Custom2 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom3")]
        public string? Custom3 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom4")]
        public string? Custom4 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom5")]
        public string? Custom5 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom6")]
        public string? Custom6 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom7")]
        public string? Custom7 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom8")]
        public string? Custom8 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom9")]
        public string? Custom9 { get; set; }

        /// <summary>
        /// User defined metadata. Only accessible once it is enabled in the organization settings.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("custom10")]
        public string? Custom10 { get; set; }

        /// <summary>
        /// It is a unique identifier associated with a specific workspace within the FastPix platform.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("workspaceId")]
        public string? WorkspaceId { get; set; }

        /// <summary>
        /// Events specifies the order of events journey of the video playback <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("events")]
        public List<Event>? Events { get; set; }

        /// <summary>
        /// Exit Before Video Start indicates whether a viewer abandoned the video before it started playing, typically due to long loading times.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("exitBeforeVideoStart")]
        public bool? ExitBeforeVideoStart { get; set; }

        /// <summary>
        /// Experiment Name is used in A/B testing scenarios to categorize video views into different experiments.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("experimentName")]
        public string? ExperimentName { get; set; }

        /// <summary>
        /// Insert Timestamp refers to the time instance when the view is started.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("insertTimestamp")]
        public string? InsertTimestamp { get; set; }

        /// <summary>
        /// Latitude refers to the geographical coordinate representing the north-south position of the viewer&apos;s location, truncated to one decimal place.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("latitude")]
        public string? Latitude { get; set; }

        /// <summary>
        /// FastPix Live Stream ID is the unique identifier associated with a live stream video media within the FastPix Video platform.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("fpLiveStreamId")]
        public string? FpLiveStreamId { get; set; }

        /// <summary>
        /// Live Stream Latency measures the average time taken from the point of ingest to the point of display for live stream video views.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("liveStreamLatency")]
        public double? LiveStreamLatency { get; set; }

        /// <summary>
        /// Longitude denotes the geographical coordinate representing the east-west position of the viewer&apos;s location, truncated to one decimal place.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("longitude")]
        public string? Longitude { get; set; }

        /// <summary>
        /// Page Load Time measures the time from when the user initiates loading the page to when all resources are loaded on the page.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("pageLoadTime")]
        public long? PageLoadTime { get; set; }

        /// <summary>
        /// Page Context provides contextual information about the type of page being accessed.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("pageContext")]
        public string? PageContext { get; set; }

        /// <summary>
        /// View Page URL denotes the URL address of the web page where the video content is being accessed.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewPageUrl")]
        public string? ViewPageUrl { get; set; }

        /// <summary>
        /// FastPix Playback ID refers to the unique identifier associated with the playback instance of a video, particularly used in FastPix Video platform.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("fpPlaybackId")]
        public string? FpPlaybackId { get; set; }

        /// <summary>
        /// Playback Success Score represents a numerical value indicating the success or quality of the video playback experience.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playbackScore")]
        public float? PlaybackScore { get; set; }

        /// <summary>
        /// Player Autoplay On indicates whether the video player automatically initiated playback of the video content.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerAutoplayOn")]
        public bool? PlayerAutoplayOn { get; set; }

        /// <summary>
        /// Error Code is an identifier representing a specific type of error that occurred during video playback, potentially leading to playback failure.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("errorCode")]
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Error Message is a descriptive message generated by the video player when an error occurs during playback, associated with an error code.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("errorMessage")]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Player Height refers to the vertical dimension, measured in pixels, of the video player as it appears on the webpage.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerHeight")]
        public PlayerHeight? PlayerHeight { get; set; }

        /// <summary>
        /// Player Instance ID is a unique identifier that distinguishes each instance of the Player class created when initializing a video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerInstanceId")]
        public string? PlayerInstanceId { get; set; }

        /// <summary>
        /// Player Language indicates the language used for text elements within the video player interface.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerLanguage")]
        public string? PlayerLanguage { get; set; }

        /// <summary>
        /// FastPix SDK Name identifies the name of the FastPix Player SDK utilized within the player workspace.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("fpSdk")]
        public string? FpSDK { get; set; }

        /// <summary>
        /// FastPix SDK Version specifies the version of the FastPix Player SDK integrated into the player.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("fpSdkVersion")]
        public string? FpSDKVersion { get; set; }

        /// <summary>
        /// Player Name serves to differentiate various configurations or types of players used across the website or application.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerName")]
        public string? PlayerName { get; set; }

        /// <summary>
        /// Player Poster refers to the image displayed as a preview before the video playback begins.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerPoster")]
        public string? PlayerPoster { get; set; }

        /// <summary>
        /// Player Preload On indicates whether the player is configured to preload the video content upon page load.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerPreloadOn")]
        public bool? PlayerPreloadOn { get; set; }

        /// <summary>
        /// Player Remote Played specifies if the video is being remotely played to devices such as AirPlay or Chromecast, obtained from the SDK.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerRemotePlayed")]
        public bool? PlayerRemotePlayed { get; set; }

        /// <summary>
        /// Player Software Version indicates the version number of the player software installed.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerSoftwareVersion")]
        public string? PlayerSoftwareVersion { get; set; }

        /// <summary>
        /// Player Software Name denotes the software utilized for video playback within the player workspace.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerSoftwareName")]
        public string? PlayerSoftwareName { get; set; }

        /// <summary>
        /// Video Source Domain identifies the domain from which the video source originates.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoSourceDomain")]
        public string? VideoSourceDomain { get; set; }

        /// <summary>
        /// Video Source Duration represents the duration of the video source content, measured in milliseconds.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoSourceDuration")]
        public long? VideoSourceDuration { get; set; }

        /// <summary>
        /// Player Source Height denotes the vertical dimension, measured in pixels, of the source video content being transmitted to the player.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerSourceHeight")]
        public long? PlayerSourceHeight { get; set; }

        /// <summary>
        /// Video Source Hostname represents the hostname of the video<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoSourceHostname")]
        public string? VideoSourceHostname { get; set; }

        /// <summary>
        /// Video Source Stream Type denotes the type of stream used by the player, although it is currently unused.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoSourceStreamType")]
        public string? VideoSourceStreamType { get; set; }

        /// <summary>
        /// Video Source Type denotes the format of the video source as determined by the player, including formats<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoSourceType")]
        public string? VideoSourceType { get; set; }

        /// <summary>
        /// Player Source URL refers to the URL of the video source accessed by the player.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoSourceUrl")]
        public string? VideoSourceUrl { get; set; }

        /// <summary>
        /// Source Width represents the width of the source video as perceived by the player, typically measured in pixels.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerSourceWidth")]
        public long? PlayerSourceWidth { get; set; }

        /// <summary>
        /// Player Initialisation Time measures the duration, in milliseconds, from the initialization of the player within the webpage to its readiness to receive further instructions.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerInitializationTime")]
        public long? PlayerInitializationTime { get; set; }

        /// <summary>
        /// Player Version indicates the version of the player used to render the video content. It is often utilized for performance comparison between different player versions.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerVersion")]
        public string? PlayerVersion { get; set; }

        /// <summary>
        /// Player Width refers to the width of the player displayed within the webpage, measured in pixels.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerWidth")]
        public PlayerWidth? PlayerWidth { get; set; }

        /// <summary>
        /// Render Quality Score is a decimal value representing the score indicating the perceived quality of the video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("renderQualityScore")]
        public float? RenderQualityScore { get; set; }

        /// <summary>
        /// Buffer Ratio refers to the percentage of time during video playback where the viewer experiences buffering or rebuffering events.  <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("bufferRatio")]
        public float? BufferRatio { get; set; }

        /// <summary>
        /// Stability Score quantifies the smoothness of video playback, typically represented as a decimal value.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("stabilityScore")]
        public float? StabilityScore { get; set; }

        /// <summary>
        /// Region denotes the geographical region of the viewer accessing the video content.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("region")]
        public string? Region { get; set; }

        /// <summary>
        /// Session ID refers to the unique identifier tracking a viewer&apos;s session within the FastPix platform.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("sessionId")]
        public string? SessionId { get; set; }

        /// <summary>
        /// Startup Time Score evaluates the startup performance of the player, usually represented as a decimal value      <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("startupScore")]
        public float? StartupScore { get; set; }

        /// <summary>
        /// Sub Property ID denotes the unique identifier assigned to FastPix properties, previously linked with a specific workspace.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("subPropertyId")]
        public string? SubPropertyId { get; set; }

        /// <summary>
        /// Video Startup Time measures the duration, in milliseconds, from the initialization of the player within the webpage to its readiness to receive further instructions.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoStartupTime")]
        public long? VideoStartupTime { get; set; }

        /// <summary>
        /// Updated Timestamp refers to when the record is updated to a particular Video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("updatedTimestamp")]
        public string? UpdatedTimestamp { get; set; }

        /// <summary>
        /// Used Fullscreen denotes whether the viewer utilized the full-screen mode while watching the video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("usedFullScreen")]
        public bool? UsedFullScreen { get; set; }

        /// <summary>
        /// Video Content Type specifies the classification of the video content.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoContentType")]
        public string? VideoContentType { get; set; }

        /// <summary>
        /// Video Duration represents the length of the video, provided in milliseconds, typically supplied to FastPix via custom metadata.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoDuration")]
        public long? VideoDuration { get; set; }

        /// <summary>
        /// Video ID refers to an internal identifier assigned by the user or system to uniquely identify a particular video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoId")]
        public string? VideoId { get; set; }

        /// <summary>
        /// Video Language denotes the primary audio language of the video content, assuming it remains unchanged after playback initiation.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoLanguage")]
        public string? VideoLanguage { get; set; }

        /// <summary>
        /// Video Series denotes the name of a series to which the video content belongs.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoSeries")]
        public string? VideoSeries { get; set; }

        /// <summary>
        /// Video Startup Failure is a boolean metric indicating whether a viewer encountered an error before the first frame of the video commenced playback.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoStartupFailed")]
        public bool? VideoStartupFailed { get; set; }

        /// <summary>
        /// Video Title refers to the title of the video content being viewed.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoTitle")]
        public string? VideoTitle { get; set; }

        /// <summary>
        /// Average Request Latency average time it takes for a request to be made and processed during video playback<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("avgRequestLatency")]
        public float? AvgRequestLatency { get; set; }

        /// <summary>
        /// Average Request Throughput refers to the average throughput or data transfer rate of HTTP requests made during video playback<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("avgRequestThroughput")]
        public float? AvgRequestThroughput { get; set; }

        /// <summary>
        /// DRM Type indicates the type of Digital Rights Management (DRM) utilized during video playback<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("drmType")]
        public string? DrmType { get; set; }

        /// <summary>
        /// Dropped Frame Count represents the number of frames dropped by the video player during playback.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("droppedFrameCount")]
        public long? DroppedFrameCount { get; set; }

        /// <summary>
        /// View End refers to the date and time, in Coordinated Universal Time (UTC), when the video viewing session concluded.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewEnd")]
        public string? ViewEnd { get; set; }

        /// <summary>
        /// View Has Ad is a boolean metric indicating whether an advertisement played or attempted to play during the video view.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewHasAd")]
        public bool? ViewHasAd { get; set; }

        /// <summary>
        /// View ID is a unique identifier assigned to each individual video viewing session.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewId")]
        public string? ViewId { get; set; }

        /// <summary>
        /// Maximum Downscale Percentage represents the highest percentage of downscaling applied to the video during the view.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("maxDownscaling")]
        public float? MaxDownscaling { get; set; }

        /// <summary>
        /// View Max Playhead Position represents the furthest point reached by the playhead during the video view, measured in milliseconds.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewMaxPlayheadPosition")]
        public long? ViewMaxPlayheadPosition { get; set; }

        /// <summary>
        /// Max request Latency refers to the maximum rate of data transfer (throughput) during requests made by the playback.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("maxRequestLatency")]
        public float? MaxRequestLatency { get; set; }

        /// <summary>
        /// Maximum Upscale Percentage represents the highest percentage of upscaling applied to the video during the view.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("maxUpscaling")]
        public float? MaxUpscaling { get; set; }

        /// <summary>
        /// Playing Time denotes the total duration of time the video content was actively playing during the view, excluding time spent buffering, seeking, or joining.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewPlayingTime")]
        public long? ViewPlayingTime { get; set; }

        /// <summary>
        /// View Seeked Count signifies the number of times the viewer attempted to seek to a new location within the video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewSeekedCount")]
        public long? ViewSeekedCount { get; set; }

        /// <summary>
        /// View Seeked Duration indicates the total duration of time spent waiting for playback to resume after the viewer seeks to a new location. Seek Latency metric in the Dashboard is derived by dividing this value by the view_seek_count.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewSeekedDuration")]
        public long? ViewSeekedDuration { get; set; }

        /// <summary>
        /// View Start refers to the date and time, in Coordinated Universal Time (UTC), when the video viewing session commenced.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewStart")]
        public string? ViewStart { get; set; }

        /// <summary>
        /// View Total content Playback Time represents the cumulative duration of video content watched by the viewer, measured in milliseconds. This metric is internally utilized to calculate upscale and downscale percentages.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewTotalContentPlaybackTime")]
        public long? ViewTotalContentPlaybackTime { get; set; }

        /// <summary>
        /// Average Downscaling refers to the average reduction in video resolution or quality during the playback of video content.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("avgDownscaling")]
        public float? AvgDownscaling { get; set; }

        /// <summary>
        /// Average Upscaling refers to the average resolution of the video source is lower than the resolution of the playback device or screen.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("avgUpscaling")]
        public float? AvgUpscaling { get; set; }

        /// <summary>
        /// Browser denotes the software application utilized by the viewer to access and watch the video content<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("browserName")]
        public string? BrowserName { get; set; }

        /// <summary>
        /// Browser version signifies the specific version of the browser software employed by the viewer<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("browserVersion")]
        public string? BrowserVersion { get; set; }

        /// <summary>
        /// Connection Type signifies the type of network connection utilized by the viewer&apos;s device<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("connectiontype")]
        public string? Connectiontype { get; set; }

        /// <summary>
        /// Device Type denotes the classification of the device used by the viewer<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("deviceType")]
        public string? DeviceType { get; set; }

        /// <summary>
        /// Device Manufacturer indicates the brand or manufacturer of the device used by the viewer.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("deviceManufacturer")]
        public string? DeviceManufacturer { get; set; }

        /// <summary>
        /// Device Model represents the specific model of the device used by the viewer.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("deviceModel")]
        public string? DeviceModel { get; set; }

        /// <summary>
        /// Device Name refers to the name or label assigned to the device used by the viewer.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("deviceName")]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Quality Of Experience Score quantifies the overall viewer experience based on various metrics, providing a decimal score to assess the quality of the viewing experience.        <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("qualityOfExperienceScore")]
        public float? QualityOfExperienceScore { get; set; }

        /// <summary>
        /// Operating System signifies the name of software platform utilized by the viewer.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("osName")]
        public string? OsName { get; set; }

        /// <summary>
        /// Operating System Version specifies the specific version of the operating system being used by the viewer<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("osVersion")]
        public string? OsVersion { get; set; }

        /// <summary>
        /// User Agent represents the user agent string transmitted by the viewer&apos;s device to identify itself to the server, typically including information about the device and browser.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("userAgent")]
        public string? UserAgent { get; set; }

        /// <summary>
        /// Viewer ID refers to a customer-defined identifier representing the viewer who is watching the video stream. It should be anonymized and not contain any personally identifiable information.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("viewerId")]
        public string? ViewerId { get; set; }

        /// <summary>
        /// Total Watch Time denotes the total duration of video content watched by the viewer, encompassing startup time, playing time, and potential rebuffering time, measured in milliseconds.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("totalWatchTime")]
        public long? TotalWatchTime { get; set; }

        /// <summary>
        /// Average Bitrate represents the average bitrate of the video content watched by the viewer, expressed in bits per second (bps). This metric provides insight into the quality of the video stream.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("averageBitrate")]
        public float? AverageBitrate { get; set; }

        /// <summary>
        /// Jump Latency refers to the delay or latency experienced when there is a jump or seek action performed by the viewer while watching a video. <br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("jumpLatency")]
        public float? JumpLatency { get; set; }

        /// <summary>
        /// Player Resolution refers to the resolution of the video player window or viewport where the video content is being displayed.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerResolution")]
        public string? PlayerResolution { get; set; }

        /// <summary>
        /// videoResolution refers to the resolution of the video being played.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("videoResolution")]
        public string? VideoResolution { get; set; }
    }
}