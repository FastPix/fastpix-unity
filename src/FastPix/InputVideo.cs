

#nullable enable
namespace fastpix.io
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System;
    using UnityEngine.Networking;
    using fastpix.io.Models.Components;
    using fastpix.io.Models.Errors;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;

    public interface IInputVideo
    {

        /// <summary>
        /// Create media from URL
        /// 
        /// <remarks>
        /// This endpoint allows developers or users to create a new video or audio media in FastPix using a publicly accessible URL. FastPix will fetch the media from the provided URL, process it, and store it on the platform for use. <br/>
        /// <br/>
        /// <br/>
        /// <br/>
        /// #### Public URL requirement:<br/>
        /// <br/>
        /// <br/>
        ///   The provided URL must be publicly accessible and should point to a video stored in one of the following supported formats: .m4v, .ogv, .mpeg, .mov, .3gp, .f4v, .rm, .ts, .wtv, .avi, .mp4, .wmv, .webm, .mts, .vob, .mxf, asf, m2ts <br/>
        /// <br/>
        /// <br/>
        /// <br/>
        /// #### Supported storage types:<br/>
        /// <br/>
        /// The URL can originate from various cloud storage services or content delivery networks (CDNs) such as: <br/>
        /// <br/>
        /// <br/>
        /// * **Amazon S3:** URLs from Amazon&apos;s Simple Storage Service. <br/>
        /// <br/>
        /// * **Google Cloud Storage:** URLs from Google Cloud&apos;s storage solution. <br/>
        /// <br/>
        /// * **Azure Blob Storage:** URLs from Microsoft&apos;s Azure storage. <br/>
        /// <br/>
        /// * **Public CDNs:** URLs from public content delivery networks that host video files. <br/>
        /// <br/>
        /// Upon successful creation, the API returns an `id` that should be retained for future operations related to this media. <br/>
        /// <br/>
        /// #### How it works<br/>
        /// <br/>
        /// <br/>
        /// 1. Send a POST request to this endpoint with the media URL (typically a video or audio file) and optional media settings. <br/>
        /// <br/>
        /// 2. FastPix uploads the video from the provided URL to its storage. <br/>
        /// <br/>
        /// 3. Receive a response containing the unique id for the newly created media item. <br/>
        /// <br/>
        /// 4. Use the id in subsequent API calls, such as checking the status of the media with the &lt;a href=&quot;https://docs.fastpix.io/reference/get-media&quot;&gt;Get Media by ID&lt;/a&gt; endpoint to determine when the media is ready for playback. <br/>
        /// <br/>
        /// FastPix uses webhooks to tell your application about things that happen in the background, outside of the API regular request flow. For instance, once the media file is created (but not yet processed or encoded), we&apos;ll shoot a `POST` message to the address you give us with the webhook event &lt;a href=&quot;https://docs.fastpix.io/docs/media-events#videomediacreated&quot;&gt;video.media.created&lt;/a&gt;. <br/>
        /// <br/>
        /// <br/>
        /// Once processing is done you can look for the events &lt;a href=&quot;https://docs.fastpix.io/docs/media-events#/videomediaready&quot;&gt;video.media.ready&lt;a/&gt; and &lt;a href=&quot;https://docs.fastpix.io/docs/media-events#videomediafailed&quot;&gt;video.media.failed&lt;/a&gt; to see the status of your new media file.<br/>
        /// <br/>
        /// Related guide: &lt;a href=&quot;https://docs.fastpix.io/docs/upload-videos-from-url&quot;&gt;Upload videos from URL&lt;/a&gt;<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<fastpix.io.Models.Requests.CreateMediaResponse> CreateMediaAsync(CreateMediaRequest request);

        /// <summary>
        /// Upload media from device
        /// 
        /// <remarks>
        /// This endpoint enables accelerated uploads of large media files directly from your local device to FastPix for processing and storage.<br/>
        /// <br/>
        /// &gt; **PLEASE NOTE**<br/>
        /// &gt;<br/>
        /// &gt; This version now supports uploads with no file size limitations and offers faster uploads. The previous endpoint (which had a 500MB size limit) is now deprecated. You can find details in the <a href="https://docs.fastpix.io/changelog/api-update-direct-upload-media-from-device">changelog</a>.<br/>
        /// <br/>
        /// #### How it works<br/>
        /// <br/>
        /// 1. Send a POST request to this endpoint with optional media settings.  <br/>
        /// <br/>
        /// 2. The response includes an `uploadId` and a signed `url` for direct video file upload.<br/>
        /// <br/>
        /// 3. Upload your video file to the provided `url` by making `PUT` request. The API accepts the media file from the device and uploads it to the FastPix platform. <br/>
        /// <br/>
        /// 4. Once uploaded, the media undergoes processing and is assigned a unique ID for tracking. Retain this `uploadId` for any future operations related to this upload. <br/>
        /// <br/>
        /// <br/>
        /// <br/>
        /// <br/>
        /// After uploading, you can use the &lt;a href=&quot;https://docs.fastpix.io/reference/get-media&quot;&gt;Get Media by ID&lt;/a&gt; endpoint to check the status of the uploaded media asset and see if it has transitioned to a `ready` status for playback. <br/>
        /// <br/>
        /// To notify your application about the status of this API request check for the webhooks for &lt;a href=&quot;https://docs.fastpix.io/docs/webhooks-collection#media-related-events&quot;&gt;media related events&lt;/a&gt;.  <br/>
        /// <br/>
        /// <br/>
        /// #### Example<br/>
        /// <br/>
        /// A social media platform allows users to upload video content directly from their phones or computers. This endpoint facilitates the upload process. For example, if you are developing a video-sharing app where users can upload short clips from their mobile devices, this endpoint enables them to select a video, upload it to the platform.<br/>
        /// <br/>
        /// Related guide: &lt;a href=&quot;https://docs.fastpix.io/docs/upload-videos-directly&quot;&gt;Upload videos directly&lt;/a&gt;<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<DirectUploadVideoMediaResponse> DirectUploadVideoMediaAsync(DirectUploadVideoMediaRequest? request = null);
    }

    public class InputVideo: IInputVideo
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _target = "unity";
        private const string _sdkVersion = "0.1.0";
        private const string _sdkGenVersion = "2.714.0";
        private const string _openapiDocVersion = "1.0.0";
        private const string _userAgent = "fastpix-sdk/unity 0.1.0 2.714.0 1.0.0 fastpix.io";
        private string _serverUrl = "";
        private FastPixHttpClient _defaultClient;
        private Func<Security>? _securitySource;

        public InputVideo(FastPixHttpClient defaultClient, Func<Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _defaultClient = defaultClient;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }
        

        
        public async Task<fastpix.io.Models.Requests.CreateMediaResponse> CreateMediaAsync(CreateMediaRequest request)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = baseUrl + "/on-demand";

            var httpRequest = new UnityWebRequest(urlString, UnityWebRequest.kHttpVerbPOST);
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

            var serializedBody = RequestBodySerializer.Serialize(request, "Request", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.uploadHandler = new UploadHandlerRaw(serializedBody.Body);
                httpRequest.SetRequestHeader("Content-Type", serializedBody.ContentType);
            }

            var client = _defaultClient;
            if (_securitySource != null)
            {
                client = SecuritySerializer.Apply(_defaultClient, _securitySource);
            }

            var httpResponse = await client.SendAsync(httpRequest);
            int? errorCode = null;
            string? contentType = null;
            switch (httpResponse.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    errorCode = (int)httpRequest.responseCode;
                    contentType = httpRequest.GetResponseHeader("Content-Type");
                    httpRequest.Dispose();
                    break;
                case UnityWebRequest.Result.Success:
                    break;
            }

            if (contentType == null)
            {
                contentType = httpResponse.GetResponseHeader("Content-Type") ?? "application/octet-stream";
            }
            int httpCode = errorCode ?? (int)httpResponse.responseCode;
            var response = new fastpix.io.Models.Requests.CreateMediaResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 201)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<CreateMediaSuccessResponse>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.CreateMediaSuccessResponse = obj;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode == 400)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<BadRequestException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    obj!.RawResponse = httpResponse;
                    throw obj!;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode == 401)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<InvalidPermissionException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    obj!.RawResponse = httpResponse;
                    throw obj!;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode == 403)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ForbiddenException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    obj!.RawResponse = httpResponse;
                    throw obj!;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode == 422)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ValidationErrorResponse>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    obj!.RawResponse = httpResponse;
                    throw obj!;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode >= 400 && httpCode < 500)
            {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else if (httpCode >= 500 && httpCode < 600)
            {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else
            {
                throw new APIException("unknown status code received", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            return response;
        }

        

        
        public async Task<DirectUploadVideoMediaResponse> DirectUploadVideoMediaAsync(DirectUploadVideoMediaRequest? request = null)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = baseUrl + "/on-demand/upload";

            var httpRequest = new UnityWebRequest(urlString, UnityWebRequest.kHttpVerbPOST);
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

            var serializedBody = RequestBodySerializer.Serialize(request, "Request", "json", false, true);
            if (serializedBody != null)
            {
                httpRequest.uploadHandler = new UploadHandlerRaw(serializedBody.Body);
                httpRequest.SetRequestHeader("Content-Type", serializedBody.ContentType);
            }

            var client = _defaultClient;
            if (_securitySource != null)
            {
                client = SecuritySerializer.Apply(_defaultClient, _securitySource);
            }

            var httpResponse = await client.SendAsync(httpRequest);
            int? errorCode = null;
            string? contentType = null;
            switch (httpResponse.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    errorCode = (int)httpRequest.responseCode;
                    contentType = httpRequest.GetResponseHeader("Content-Type");
                    httpRequest.Dispose();
                    break;
                case UnityWebRequest.Result.Success:
                    break;
            }

            if (contentType == null)
            {
                contentType = httpResponse.GetResponseHeader("Content-Type") ?? "application/octet-stream";
            }
            int httpCode = errorCode ?? (int)httpResponse.responseCode;
            var response = new DirectUploadVideoMediaResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 201)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<DirectUploadVideoMediaResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.Object = obj;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode == 400)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<BadRequestException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    obj!.RawResponse = httpResponse;
                    throw obj!;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode == 401)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<InvalidPermissionException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    obj!.RawResponse = httpResponse;
                    throw obj!;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode == 403)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ForbiddenException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    obj!.RawResponse = httpResponse;
                    throw obj!;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode == 422)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ValidationErrorResponse>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    obj!.RawResponse = httpResponse;
                    throw obj!;
                }
                else
                {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode >= 400 && httpCode < 500)
            {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else if (httpCode >= 500 && httpCode < 600)
            {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else
            {
                throw new APIException("unknown status code received", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            return response;
        }

        
    }
}