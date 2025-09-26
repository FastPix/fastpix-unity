

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

    public interface IPlayback
    {

        /// <summary>
        /// Create a playback ID
        /// 
        /// <remarks>
        /// You can create a new playback ID for a specific media asset. If you have already retrieved an existing `playbackId` using the &lt;a href=&quot;https://docs.fastpix.io/reference/get-media&quot;&gt;Get Media by ID&lt;/a&gt; endpoint for a media asset, you can use this endpoint to generate a new playback ID with a specified access policy. <br/>
        /// <br/>
        /// <br/>
        /// <br/>
        /// If you want to create a private playback ID for a media asset that already has a public playback ID, this endpoint also allows you to do so by specifying the desired access policy. <br/>
        /// <br/>
        /// #### How it works<br/>
        /// <br/>
        /// 1. Make a `POST` request to this endpoint, replacing `&lt;mediaId&gt;` with the `uploadId` or `id` of the media asset. <br/>
        /// <br/>
        /// 2. Include the `accessPolicy` in the request body with `private` or `public` as the value. <br/>
        /// <br/>
        /// 3. Receive a response containing the newly created playback ID with the requested access level. <br/>
        /// <br/>
        /// <br/>
        /// #### Example<br/>
        /// A video streaming service generates playback IDs for each media file when users request to view specific content. The playback ID is then used by the video player to stream the video.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<CreateMediaPlaybackIdResponse> CreateMediaPlaybackIdAsync(string mediaId, CreateMediaPlaybackIdRequestBody? requestBody = null);

        /// <summary>
        /// Delete a playback ID
        /// 
        /// <remarks>
        /// This endpoint allows you to remove a specific playback ID associated with a media asset. Deleting a `playbackId` will revoke access to the media content linked to that ID. <br/>
        /// <br/>
        /// <br/>
        /// #### How it works<br/>
        /// <br/>
        /// 1. Make a `DELETE` request to this endpoint, replacing `&lt;mediaId&gt;` with the unique ID of the media asset from which you want to delete the playback ID. <br/>
        /// <br/>
        /// 2. Specify the `playbackId` you wish to delete in the request body. <br/>
        /// <br/>
        /// #### Example<br/>
        /// <br/>
        /// Your platform offers limited-time access to premium content. When the subscription expires, you can revoke access to the content by deleting the associated playback ID, preventing users from streaming the video further.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<DeleteMediaPlaybackIdResponse> DeleteMediaPlaybackIdAsync(string mediaId, string playbackId);

        /// <summary>
        /// Get a playback ID
        /// 
        /// <remarks>
        /// This endpoint retrieves details about a specific playback ID associated with a media asset. This endpoint is commonly used to check the access policy (e.g., public or private) with the specific playback ID.<br/>
        /// <br/>
        /// **How it works:**<br/>
        /// 1. Make a GET request to the endpoint, replacing `{mediaId}` with the `id` of the media, and `{playbackId}` with the specific playback ID.<br/>
        /// 2. Useful for auditing or validation before granting playback access in your application.<br/>
        /// <br/>
        /// **Example:**<br/>
        /// A media platform might use this endpoint to verify if a playback ID is public or private before embedding the video in a frontend player or allowing access to a restricted group.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<GetPlaybackIdResponse> GetPlaybackIdAsync(string mediaId, string playbackId);
    }

    public class Playback: IPlayback
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

        public Playback(FastPixHttpClient defaultClient, Func<Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _defaultClient = defaultClient;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }
        

        
        public async Task<CreateMediaPlaybackIdResponse> CreateMediaPlaybackIdAsync(string mediaId, CreateMediaPlaybackIdRequestBody? requestBody = null)
        {
            var request = new CreateMediaPlaybackIdRequest()
            {
                MediaId = mediaId,
                RequestBody = requestBody,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/on-demand/{mediaId}/playback-ids", request);

            var httpRequest = new UnityWebRequest(urlString, UnityWebRequest.kHttpVerbPOST);
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

            var serializedBody = RequestBodySerializer.Serialize(request, "RequestBody", "json", false, true);
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
            var response = new CreateMediaPlaybackIdResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 201)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<CreateMediaPlaybackIdResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.Object = obj;
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
            else if (httpCode == 404)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<MediaNotFoundException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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

        

        
        public async Task<DeleteMediaPlaybackIdResponse> DeleteMediaPlaybackIdAsync(string mediaId, string playbackId)
        {
            var request = new DeleteMediaPlaybackIdRequest()
            {
                MediaId = mediaId,
                PlaybackId = playbackId,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/on-demand/{mediaId}/playback-ids", request);

            var httpRequest = new UnityWebRequest(urlString, "DELETE");
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

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
            var response = new DeleteMediaPlaybackIdResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<DeleteMediaPlaybackIdResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.Object = obj;
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
            else if (httpCode == 404)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<MediaOrPlaybackNotFoundException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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

        

        
        public async Task<GetPlaybackIdResponse> GetPlaybackIdAsync(string mediaId, string playbackId)
        {
            var request = new GetPlaybackIdRequest()
            {
                MediaId = mediaId,
                PlaybackId = playbackId,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/on-demand/{mediaId}/playback-ids/{playbackId}", request);

            var httpRequest = new UnityWebRequest(urlString, UnityWebRequest.kHttpVerbGET);
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

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
            var response = new GetPlaybackIdResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<GetPlaybackIdResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.Object = obj;
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
            else if (httpCode == 404)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<MediaOrPlaybackNotFoundException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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