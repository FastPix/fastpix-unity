

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

    public interface IDRMConfigurations
    {

        /// <summary>
        /// Get list of DRM configuration IDs
        /// 
        /// <remarks>
        /// <br/>
        /// This endpoint retrieves the DRM configuration (DRM ID) associated with a workspace. It returns a list of DRM configurations, identified by a unique DRM ID, which is used for creating DRM encrypted asset.<br/>
        /// <br/>
        /// **How it works:**<br/>
        /// 1. Make a GET request to this endpoint.  <br/>
        /// 2. Optionally use the `offset` and `limit` query parameters to paginate through the list of DRM configurations.  <br/>
        /// 3. The response includes a list of DRM IDs and pagination metadata.<br/>
        /// <br/>
        /// **Example:**  <br/>
        /// A media service provider may retrieve DRM configuration for a workspace to create DRM content.<br/>
        /// <br/>
        /// Related guide: &lt;a href=&quot;https://docs.fastpix.io/docs/secure-playback-with-drm&quot;&gt;Manage DRM configuration&lt;/a&gt;<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<GetDrmConfigurationResponse> GetDrmConfigurationAsync(long? offset = null, long? limit = null);

        /// <summary>
        /// Get DRM configuration by ID
        /// 
        /// <remarks>
        /// <br/>
        /// This endpoint retrieves a DRM configuration ID. It is used to fetch the DRM-related ID for a workspace, typically required when validating or applying DRM policies to video assets.<br/>
        /// <br/>
        /// **How it works:**<br/>
        /// 1. Make a GET request to this endpoint, replacing `{drmConfigurationId}` with the UUID of the DRM configuration.  <br/>
        /// 2. The response will contain the associated DRM configuration ID.<br/>
        /// <br/>
        /// Related guide: &lt;a href=&quot;https://docs.fastpix.io/docs/secure-playback-with-drm&quot;&gt;Manage DRM configuration&lt;/a&gt;<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<GetDrmConfigurationByIdResponse> GetDrmConfigurationByIdAsync(string drmConfigurationId);
    }

    public class DRMConfigurations: IDRMConfigurations
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

        public DRMConfigurations(FastPixHttpClient defaultClient, Func<Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _defaultClient = defaultClient;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }
        

        
        public async Task<GetDrmConfigurationResponse> GetDrmConfigurationAsync(long? offset = null, long? limit = null)
        {
            var request = new GetDrmConfigurationRequest()
            {
                Offset = offset,
                Limit = limit,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/on-demand/drm-configurations", request);

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
            var response = new GetDrmConfigurationResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<GetDrmConfigurationResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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

        

        
        public async Task<GetDrmConfigurationByIdResponse> GetDrmConfigurationByIdAsync(string drmConfigurationId)
        {
            var request = new GetDrmConfigurationByIdRequest()
            {
                DrmConfigurationId = drmConfigurationId,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/on-demand/drm-configurations/{drmConfigurationId}", request);

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
            var response = new GetDrmConfigurationByIdResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<GetDrmConfigurationByIdResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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

        
    }
}