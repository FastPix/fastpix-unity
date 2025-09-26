

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

    public interface IErrors
    {

        /// <summary>
        /// List errors
        /// 
        /// <remarks>
        /// This endpoint returns the total number of playback errors that occurred, along with the total number of views captured, based on the specified timespan and filters. It provides insights into the overall playback quality and helps identify potential issues that may impact viewer experience. <br/>
        /// <br/>
        /// <br/>
        /// #### Key fields in response<br/>
        /// <br/>
        /// * **percentage:** The percentage of views affected by the specific error. <br/>
        /// * **uniqueViewersEffectedPercentage:** The percentage of unique viewers affected by the specific error (available only in the topErrors section). <br/>
        /// * **notes:** Additional notes or information about the specific error. <br/>
        /// * **message:** The error message or description. <br/>
        /// * **lastSeen:** The timestamp of when the error was last observed. <br/>
        /// * **id:** The unique identifier for the specific error. <br/>
        /// * **description:** A description of the specific error. <br/>
        /// * **count:** The number of occurrences of the specific error. <br/>
        /// * **code:** The error code associated with the specific error. <br/>
        /// <br/>
        /// <br/>
        /// Related guide: &lt;a href=&quot;https://docs.fastpix.io/docs/track-playback-errors&quot;&gt;Troubleshoot errors&lt;/a&gt;<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<ListErrorsResponse> ListErrorsAsync(ListErrorsTimespan timespan, string? filterby = null, long? limit = null);
    }

    public class Errors: IErrors
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

        public Errors(FastPixHttpClient defaultClient, Func<Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _defaultClient = defaultClient;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }
        

        
        public async Task<ListErrorsResponse> ListErrorsAsync(ListErrorsTimespan timespan, string? filterby = null, long? limit = null)
        {
            var request = new ListErrorsRequest()
            {
                Timespan = timespan,
                Filterby = filterby,
                Limit = limit,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/data/errors", request);

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
            var response = new ListErrorsResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ListErrorsResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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
            else if (httpCode == 404)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ViewNotFoundException>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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