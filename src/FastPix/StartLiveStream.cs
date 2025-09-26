

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

    public interface IStartLiveStream
    {

        /// <summary>
        /// Create a new stream
        /// 
        /// <remarks>
        /// Allows you to initiate a new &lt;a href=&quot;https://docs.fastpix.io/docs/get-started-with-live-streaming&quot;&gt;RTMPS&lt;/a&gt; or &lt;a href=&quot;https://docs.fastpix.io/docs/using-srt-to-live-stream&quot;&gt;SRT&lt;/a&gt; live stream on FastPix. Upon creating a stream, FastPix generates a unique `streamKey` and `srtSecret`, which can be used with any broadcasting software (like OBS) to connect to FastPix&apos;s RTMPS or SRT servers.<br/>
        /// Leverage SRT for live streaming in environments with unstable networks, taking advantage of its error correction and encryption features for a resilient and secure broadcast. <br/>
        /// <br/>
        /// &lt;h4&gt;How it works&lt;/h4&gt; <br/>
        /// <br/>
        /// 1. Send a a `POST` request to this endpoint. You can configure the stream settings, including `metadata` (such as stream name and description), `reconnectWindow` (in case of disconnection), and privacy options (`public` or `private`). <br/>
        /// <br/>
        /// 2. FastPix returns the stream details for both RTMPS and SRT configurations. These keys and IDs from the stream details are essential for connecting the broadcasting software to FastPix’s servers and transmitting the live stream to viewers.<br/>
        /// <br/>
        /// 3. Once the live stream is created, we’ll shoot a `POST` message to the address you give us with the webhook event &lt;a href=&quot;https://docs.fastpix.io/docs/live-events#videolive_streamcreated&quot;&gt;video.live_stream.created&lt;/a&gt;.<br/>
        /// <br/>
        /// <br/>
        /// **Example:**<br/>
        /// <br/>
        /// <br/>
        ///   Imagine a gaming platform that allows users to live stream gameplay directly from their dashboard. The API creates a new stream, provides the necessary stream key, and sets it to &quot;private&quot; so that only specific viewers can access it. <br/>
        /// <br/>
        /// <br/>
        /// Related guide: &lt;a href=&quot;https://docs.fastpix.io/docs/how-to-livestream&quot;&gt;How to live stream&lt;/a&gt;
        /// </remarks>
        /// </summary>
        Task<CreateNewStreamResponse> CreateNewStreamAsync(CreateLiveStreamRequest request);
    }

    public class StartLiveStream: IStartLiveStream
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

        public StartLiveStream(FastPixHttpClient defaultClient, Func<Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _defaultClient = defaultClient;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }
        

        
        public async Task<CreateNewStreamResponse> CreateNewStreamAsync(CreateLiveStreamRequest request)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = baseUrl + "/live/streams";

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
            var response = new CreateNewStreamResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 201)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<LiveStreamResponseDTO>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.LiveStreamResponseDTO = obj;
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
                    var obj = JsonConvert.DeserializeObject<UnauthorizedException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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
                    var obj = JsonConvert.DeserializeObject<InvalidPermissionException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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