

#nullable enable
namespace fastpix.io
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System;
    using fastpix.io.Models.Components;
    using fastpix.io.Models.Errors;
    using fastpix.io.Utils;

    /// <summary>
    /// FASTPIX API&apos;S: FastPix provides a comprehensive set of APIs that enable developers to manage both **on-demand media (video/audio)** and **live streaming experiences**, with built-in security features through **cryptographic signing keys**. These APIs cover the full lifecycle of content creation, management, distribution, playback, and secure access, making them ideal for building scalable video-first applications.<br/>
    /// 
    /// <remarks>
    /// ### Media APIs (Video &amp; Audio on Demand)<br/>
    /// The **Media APIs** allow developers to create, retrieve, update, and delete media files, as well as manage metadata, playback settings, and additional tracks such as audio or subtitles. With these endpoints, developers can:<br/>
    /// - Upload videos directly or create media from URLs.   - Manage playback permissions and configure playback IDs.   - Add multilingual audio or subtitle tracks for global audiences.   - Build robust video-on-demand (VOD) and audio-on-demand (AOD) libraries.  <br/>
    /// **Use case scenarios**   - **Video-on-Demand Platforms:** Manage large content libraries for streaming services.   - **E-Learning Solutions:** Upload and organize lecture videos, metadata, and playback settings.   - **Multilingual Content Delivery:** Add multiple language tracks or subtitles to serve global users.  <br/>
    /// ### Live Stream APIs<br/>
    /// The **Live Stream APIs** simplify the process of creating, managing, and distributing live content. Developers can initiate broadcasts, configure stream settings, and extend streams to external platforms through simulcasting. These endpoints also support real-time interaction and customization of live events.<br/>
    /// - Start and manage live broadcasts programmatically.   - Control stream metadata, privacy, and playback options.   - Simulcast to platforms like YouTube, Facebook, or Twitch.   - Update stream details and manage live playback IDs in real time.  <br/>
    /// **Use case scenarios**   - **Event Broadcasting:** Enable organizers to set up live streams for conferences, concerts, or webinars.   - **Creator Platforms:** Provide streamers with tools for broadcasting gameplay, tutorials, or vlogs with simulcasting support.   - **Corporate Streaming:** Deliver secure internal town halls or meetings with privacy and playback controls.  <br/>
    /// ### Video Data APIs<br/>
    /// The **Video Data APIs** Provide insights into viewer interactions, performance metrics, and playback errors to optimize content delivery and user experience.<br/>
    /// <br/>
    ///  - Track video views, unique viewers, and engagement metrics<br/>
    ///  - Identify top-performing content and usage patterns<br/>
    ///  - Break down data by browser, device, or geography<br/>
    ///  - Detect playback errors and performance issues<br/>
    ///  - Enable data-driven content strategy decisions<br/>
    ///  <br/>
    ///  **Use case scenarios** <br/>
    ///  - Analytics Dashboards: Monitor performance across content libraries<br/>
    ///  - Quality Monitoring: Diagnose and resolve playback issues<br/>
    ///  - Content Strategy Optimization: Identify high-value content<br/>
    ///  - User Behavior Insights: Understand audience interactions<br/>
    /// <br/>
    /// ### Signing Keys<br/>
    /// FastPix also provides endpoints for managing **cryptographic signing keys**, which are essential for securely signing and verifying tokens, such as JSON Web Tokens (JWTs). These keys are critical for authenticating and authorizing API requests, as well as for protecting access to media assets.<br/>
    /// - **Private key:** Used to create digital signatures (kept secret).   - **Public key:** Used to verify digital signatures (shared for verification).  <br/>
    /// By rotating and managing signing keys regularly, developers can maintain strong security practices and prevent unauthorized access.  <br/>
    /// **Use case scenarios**   - **Token-based authentication:** Validate user access to premium or subscription-based content.   - **Key rotation:** Regularly rotate keys to reduce risk of compromise.   - **Protect intellectual property:** Prevent unauthorized distribution of valuable media assets.   - **Control usage:** Restrict access to specific users, groups, or contexts.   - **Prevent tampering:** Ensure requested assets have not been modified.   - **Time-bound access:** Enable signed URLs with expiration for controlled viewing windows.  
    /// </remarks>
    /// </summary>
    public interface IFastpix
    {
        public IInputVideo InputVideo { get; }
        public IManageVideos ManageVideos { get; }
        public IInVideoAIFeatures InVideoAIFeatures { get; }
        public IPlayback Playback { get; }
        public IPlaylist Playlist { get; }
        public IDRMConfigurations DRMConfigurations { get; }
        public IStartLiveStream StartLiveStream { get; }
        public IManageLiveStream ManageLiveStream { get; }
        public ILivePlayback LivePlayback { get; }
        public ISimulcastStream SimulcastStream { get; }
        public ISigningKeys SigningKeys { get; }
        public IViews Views { get; }
        public IDimensions Dimensions { get; }
        public IMetrics Metrics { get; }
        public IErrors Errors { get; }
    }
    

    public class SDKConfig
    {
        /// <summary>
        /// List of server URLs available to the SDK.
        /// </summary>
        public static readonly string[] ServerList = {
            "https://api.fastpix.io/v1/",
        };

        public string serverUrl = "";
        public int serverIndex = 0;

        public string GetTemplatedServerDetails()
        {
            if (!String.IsNullOrEmpty(this.serverUrl))
            {
                return Utilities.TemplateUrl(Utilities.RemoveSuffix(this.serverUrl, "/"), new Dictionary<string, string>());
            }
            return Utilities.TemplateUrl(SDKConfig.ServerList[this.serverIndex], new Dictionary<string, string>());
        }
    }

    /// <summary>
    /// FASTPIX API&apos;S: FastPix provides a comprehensive set of APIs that enable developers to manage both **on-demand media (video/audio)** and **live streaming experiences**, with built-in security features through **cryptographic signing keys**. These APIs cover the full lifecycle of content creation, management, distribution, playback, and secure access, making them ideal for building scalable video-first applications.<br/>
    /// 
    /// <remarks>
    /// ### Media APIs (Video &amp; Audio on Demand)<br/>
    /// The **Media APIs** allow developers to create, retrieve, update, and delete media files, as well as manage metadata, playback settings, and additional tracks such as audio or subtitles. With these endpoints, developers can:<br/>
    /// - Upload videos directly or create media from URLs.   - Manage playback permissions and configure playback IDs.   - Add multilingual audio or subtitle tracks for global audiences.   - Build robust video-on-demand (VOD) and audio-on-demand (AOD) libraries.  <br/>
    /// **Use case scenarios**   - **Video-on-Demand Platforms:** Manage large content libraries for streaming services.   - **E-Learning Solutions:** Upload and organize lecture videos, metadata, and playback settings.   - **Multilingual Content Delivery:** Add multiple language tracks or subtitles to serve global users.  <br/>
    /// ### Live Stream APIs<br/>
    /// The **Live Stream APIs** simplify the process of creating, managing, and distributing live content. Developers can initiate broadcasts, configure stream settings, and extend streams to external platforms through simulcasting. These endpoints also support real-time interaction and customization of live events.<br/>
    /// - Start and manage live broadcasts programmatically.   - Control stream metadata, privacy, and playback options.   - Simulcast to platforms like YouTube, Facebook, or Twitch.   - Update stream details and manage live playback IDs in real time.  <br/>
    /// **Use case scenarios**   - **Event Broadcasting:** Enable organizers to set up live streams for conferences, concerts, or webinars.   - **Creator Platforms:** Provide streamers with tools for broadcasting gameplay, tutorials, or vlogs with simulcasting support.   - **Corporate Streaming:** Deliver secure internal town halls or meetings with privacy and playback controls.  <br/>
    /// ### Video Data APIs<br/>
    /// The **Video Data APIs** Provide insights into viewer interactions, performance metrics, and playback errors to optimize content delivery and user experience.<br/>
    /// <br/>
    ///  - Track video views, unique viewers, and engagement metrics<br/>
    ///  - Identify top-performing content and usage patterns<br/>
    ///  - Break down data by browser, device, or geography<br/>
    ///  - Detect playback errors and performance issues<br/>
    ///  - Enable data-driven content strategy decisions<br/>
    ///  <br/>
    ///  **Use case scenarios** <br/>
    ///  - Analytics Dashboards: Monitor performance across content libraries<br/>
    ///  - Quality Monitoring: Diagnose and resolve playback issues<br/>
    ///  - Content Strategy Optimization: Identify high-value content<br/>
    ///  - User Behavior Insights: Understand audience interactions<br/>
    /// <br/>
    /// ### Signing Keys<br/>
    /// FastPix also provides endpoints for managing **cryptographic signing keys**, which are essential for securely signing and verifying tokens, such as JSON Web Tokens (JWTs). These keys are critical for authenticating and authorizing API requests, as well as for protecting access to media assets.<br/>
    /// - **Private key:** Used to create digital signatures (kept secret).   - **Public key:** Used to verify digital signatures (shared for verification).  <br/>
    /// By rotating and managing signing keys regularly, developers can maintain strong security practices and prevent unauthorized access.  <br/>
    /// **Use case scenarios**   - **Token-based authentication:** Validate user access to premium or subscription-based content.   - **Key rotation:** Regularly rotate keys to reduce risk of compromise.   - **Protect intellectual property:** Prevent unauthorized distribution of valuable media assets.   - **Control usage:** Restrict access to specific users, groups, or contexts.   - **Prevent tampering:** Ensure requested assets have not been modified.   - **Time-bound access:** Enable signed URLs with expiration for controlled viewing windows.  
    /// </remarks>
    /// </summary>
    public class Fastpix: IFastpix
    {
        public SDKConfig SDKConfiguration { get; private set; }

        private const string _target = "unity";
        private const string _sdkVersion = "0.1.0";
        private const string _sdkGenVersion = "2.714.0";
        private const string _openapiDocVersion = "1.0.0";
        private const string _userAgent = "fastpix-sdk/unity 0.1.0 2.714.0 1.0.0 fastpix.io";
        private string _serverUrl = "";
        private int _serverIndex = 0;
        private FastPixHttpClient _defaultClient;
        private Func<Security>? _securitySource;
        public IInputVideo InputVideo { get; private set; }
        public IManageVideos ManageVideos { get; private set; }
        public IInVideoAIFeatures InVideoAIFeatures { get; private set; }
        public IPlayback Playback { get; private set; }
        public IPlaylist Playlist { get; private set; }
        public IDRMConfigurations DRMConfigurations { get; private set; }
        public IStartLiveStream StartLiveStream { get; private set; }
        public IManageLiveStream ManageLiveStream { get; private set; }
        public ILivePlayback LivePlayback { get; private set; }
        public ISimulcastStream SimulcastStream { get; private set; }
        public ISigningKeys SigningKeys { get; private set; }
        public IViews Views { get; private set; }
        public IDimensions Dimensions { get; private set; }
        public IMetrics Metrics { get; private set; }
        public IErrors Errors { get; private set; }

        public Fastpix(Security? security = null, Func<Security>? securitySource = null, int? serverIndex = null, string? serverUrl = null, Dictionary<string, string>? urlParams = null, FastPixHttpClient? client = null)
        {
            if (serverIndex != null)
            {
                if (serverIndex.Value < 0 || serverIndex.Value >= SDKConfig.ServerList.Length)
                {
                    throw new Exception($"Invalid server index {serverIndex.Value}");
                }
                _serverIndex = serverIndex.Value;
            }

            if (serverUrl != null)
            {
                if (urlParams != null)
                {
                    serverUrl = Utilities.TemplateUrl(serverUrl, urlParams);
                }
                _serverUrl = serverUrl;
            }

            _defaultClient = new FastPixHttpClient(client);

            if(securitySource != null)
            {
                _securitySource = securitySource;
            }
            else if(security != null)
            {
                _securitySource = () => security;
            }
            else
            {
                throw new Exception("security and securitySource cannot both be null");
            }

            SDKConfiguration = new SDKConfig()
            {
                serverIndex = _serverIndex,
                serverUrl = _serverUrl
            };

            InputVideo = new InputVideo(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            ManageVideos = new ManageVideos(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            InVideoAIFeatures = new InVideoAIFeatures(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            Playback = new Playback(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            Playlist = new Playlist(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            DRMConfigurations = new DRMConfigurations(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            StartLiveStream = new StartLiveStream(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            ManageLiveStream = new ManageLiveStream(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            LivePlayback = new LivePlayback(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            SimulcastStream = new SimulcastStream(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            SigningKeys = new SigningKeys(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            Views = new Views(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            Dimensions = new Dimensions(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            Metrics = new Metrics(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
            Errors = new Errors(_defaultClient, _securitySource, _serverUrl, SDKConfiguration);
        }
    }
}
