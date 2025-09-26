

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

    public interface IViews
    {

        /// <summary>
        /// List video views
        /// 
        /// <remarks>
        /// Retrieves a list of video views that fall within the specified filters and have been completed within a defined timespan. It allows you to analyse viewer interactions with your video content effectively. <br/>
        /// <br/>
        /// <br/>
        /// #### How it works<br/>
        /// <br/>
        ///   1. Make a `GET` request to this endpoint with the desired query parameters. <br/>
        /// <br/>
        ///   2. Specify the timespan for which you want to retrieve the video views using the `timespan[]` parameter. <br/>
        /// <br/>
        ///   3. Filter the views based on dimensions such as browser, device, video title, viewer ID, etc., using the `filterby[]` parameter. Get the dimensions by calling &lt;a href=&quot;https://docs.fastpix.io/reference/list_dimensions&quot;&gt;list the dimensions&lt;/a&gt; endpoint. <br/>
        /// <br/>
        ///   4. Paginate the results using the `limit` and `offset` parameters. <br/>
        /// <br/>
        ///   5. Optionally, filter by `viewerId`, `errorCode`, `orderBy` a specific field, and sort in ascending or descending order. <br/>
        /// <br/>
        ///   6. Receive a response containing the list of video views matching the specified criteria.<br/>
        /// <br/>
        /// Each view in the response will include a unique `viewId`. You can use this `viewId` to call the &lt;a href=&quot;https://docs.fastpix.io/reference/get_video_view_details&quot;&gt;get details of video view&lt;/a&gt; endpoint to retrieve more detailed information about that specific view. <br/>
        /// <br/>
        /// <br/>
        /// #### Example<br/>
        /// <br/>
        /// Suppose you&apos;re managing a video streaming service and need to analyze how the content performs across different devices and browsers. By calling the List Video Views endpoint with filters like `browser_name` and `device_type`, you can get insights into which platforms are most popular with the audience. This data will help you optimize content for the most-used platforms and troubleshoot any playback issues on less common devices.<br/>
        /// <br/>
        /// <br/>
        ///   Related guide: &lt;a href=&quot;https://docs.fastpix.io/docs/audience-metrics&quot;&gt;Audience metrics&lt;/a&gt;, &lt;a href=&quot;https://docs.fastpix.io/docs/understand-dashboard-ui#1-views-dashboard&quot;&gt;Views dashboard&lt;/a&gt;
        /// </remarks>
        /// </summary>
        Task<ListVideoViewsResponse> ListVideoViewsAsync(ListVideoViewsRequest request);

        /// <summary>
        /// Get details of video view
        /// 
        /// <remarks>
        /// Allows you to retrieve detailed information about a specific video view using its unique `viewId`. This is useful for getting insights into individual viewer interactions with your video content. This detailed information is valuable for enhancing user experience and improving engagement with your video assets. <br/>
        /// <br/>
        /// Make a `GET` request to this endpoint and you will receive a response containing detailed information about the specified video view, including metrics and attributes related to that view. <br/>
        /// <br/>
        /// <br/>
        /// #### Example<br/>
        /// <br/>
        /// Suppose a developer receives a report of a poor viewing experience for a specific user. By using this endpoint with the user&apos;s `viewId`, the developer can retrieve metrics like buffering duration, playback errors, and session length. This data allows the developer to pinpoint issues (such as poor connectivity or a browser-specific problem) and take steps to improve the user experience.<br/>
        /// <br/>
        /// <br/>
        /// Related guide: &lt;a href=&quot;https://docs.fastpix.io/page/what-video-data-do-we-capture#/&quot;&gt;What Video Data do we capture?&lt;/a&gt;
        /// </remarks>
        /// </summary>
        Task<GetVideoViewDetailsResponse> GetVideoViewDetailsAsync(string viewId);

        /// <summary>
        /// List by top content
        /// 
        /// <remarks>
        /// Retrieves a list of the top video views that fall within the specified filters and have been completed within a defined timespan. It allows you to identify the most popular content based on viewer interactions. <br/>
        /// <br/>
        /// #### How it works<br/>
        /// <br/>
        ///   1. Make a `GET` request to this endpoint with the desired query parameters. <br/>
        /// <br/>
        ///   2. Specify the timespan for which you want to retrieve the top content using the `timespan[]` parameter. <br/>
        /// <br/>
        ///   3. Filter the views based on dimensions such as browser, device, video title, etc., using the `filterby[]` parameter. <br/>
        /// <br/>
        ///   4. `Limit` the results to control the number of top views returned. <br/>
        /// <br/>
        ///   5. Receive a response containing the list of top video views matching the specified criteria.<br/>
        /// <br/>
        /// <br/>
        ///   Related guide: &lt;a href=&quot;https://docs.fastpix.io/page/how-to-get-top-performing-content&quot;&gt;Get top-performing content&lt;/a&gt;<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<ListByTopContentResponse> ListByTopContentAsync(ListByTopContentTimespan timespan, string? filterby = null, long? limit = null);

        /// <summary>
        /// Get concurrent viewers timeseries
        /// 
        /// <remarks>
        /// Retrieves a time series of the number of concurrent viewers, providing a real-time snapshot of audience activity over the last 30 minutes. This endpoint is essential for monitoring live events, gauging audience reaction to new content releases, or understanding immediate engagement trends.<br/>
        /// <br/>
        /// #### How it works<br/>
        /// <br/>
        ///   1. Make a simple `GET` request to this endpoint. No query parameters are needed. <br/>
        /// <br/>
        ///   2. The API automatically gathers data for the **last 30 minutes**, calculating the number of concurrent viewers at regular intervals within that window.<br/>
        /// <br/>
        ///   3. Receive a response containing a `data` array, where each object represents a specific point in time.<br/>
        /// <br/>
        ///   4. Each object in the array includes the `intervalTime` (the timestamp of the measurement) and `numberOfViews` (the count of concurrent viewers at that instant), allowing you to easily plot viewer activity over time.<br/>
        /// <br/>
        /// #### Example<br/>
        /// <br/>
        /// Imagine you are streaming a major live event, such as a product launch, a sports game, or a webinar. You need to monitor audience engagement in real-time to see if viewership is increasing, decreasing, or holding steady.<br/>
        /// <br/>
        /// By calling this endpoint periodically (e.g., every minute), you can plot a live graph of your viewership. This allows you to identify peak moments of interest, see the immediate impact of social media promotions, or detect potential technical issues if there&apos;s a sudden, unexpected drop in viewers<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<GetDataViewlistCurrentViewsGetTimeseriesViewsResponse> GetDataViewlistCurrentViewsGetTimeseriesViewsAsync();

        /// <summary>
        /// Get concurrent viewers breakdown by dimension
        /// 
        /// <remarks>
        /// Retrieves a real-time breakdown of present concurrent viewers, grouped by a chosen dimension. This endpoint allows you to see how your audience is distributed across different categories like geography, content, or technology, based on activity in the last 30 minutes. <br/>
        /// <br/>
        /// For example, you can see how many viewers are currently watching from the US vs. India, or which video titles are most popular right now.<br/>
        /// <br/>
        /// #### How it works<br/>
        /// <br/>
        /// 1. Make a `GET` request to this endpoint.<br/>
        /// <br/>
        /// 2. Specify the `dimension` you want to group by in the query parameters (e.g., `dimension=country` or `dimension=video_title`). This is the most important parameter as it defines how the data is categorized.<br/>
        /// <br/>
        /// 3. Optionally, use the `limit` parameter to control the number of results returned (e.g., `limit=5` to get the top 5 countries).<br/>
        /// <br/>
        /// 4. The API analyzes viewer data from the last 30 minutes and aggregates the viewer counts for each unique value within the chosen dimension.<br/>
        /// <br/>
        /// 5. Receive a response containing a `data` array, where each object represents a specific group (e.g., a country or a video title) and its corresponding number of `concurrent_viewers`.<br/>
        /// <br/>
        /// #### Example<br/>
        /// <br/>
        /// Imagine you are running a global streaming platform and have just launched a new original series. You want to see, in real-time, which regions are engaging most with the new content versus your older library content.<br/>
        /// <br/>
        /// By calling this endpoint with `dimension=video_title`, you can immediately see a list of your most-watched videos right now and their respective viewer counts. Then, by calling it again with `dimension=country`, you can get a live breakdown of your audience&apos;s geographic distribution. This helps you confirm if your marketing efforts in specific countries are paying off instantly and allows you to make data-driven decisions during live events.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<GetDataViewlistCurrentViewsFilterResponse> GetDataViewlistCurrentViewsFilterAsync(GetDataViewlistCurrentViewsFilterDimension? dimension = null, long? limit = null);
    }

    public class Views: IViews
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

        public Views(FastPixHttpClient defaultClient, Func<Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _defaultClient = defaultClient;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }
        

        
        public async Task<ListVideoViewsResponse> ListVideoViewsAsync(ListVideoViewsRequest request)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/data/viewlist", request);

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
            var response = new ListVideoViewsResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ListVideoViewsResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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

        

        
        public async Task<GetVideoViewDetailsResponse> GetVideoViewDetailsAsync(string viewId)
        {
            var request = new GetVideoViewDetailsRequest()
            {
                ViewId = viewId,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/data/viewlist/{viewId}", request);

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
            var response = new GetVideoViewDetailsResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<GetVideoViewDetailsResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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

        

        
        public async Task<ListByTopContentResponse> ListByTopContentAsync(ListByTopContentTimespan timespan, string? filterby = null, long? limit = null)
        {
            var request = new ListByTopContentRequest()
            {
                Timespan = timespan,
                Filterby = filterby,
                Limit = limit,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/data/viewlist/top-content", request);

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
            var response = new ListByTopContentResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ListByTopContentResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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

        

        
        public async Task<GetDataViewlistCurrentViewsGetTimeseriesViewsResponse> GetDataViewlistCurrentViewsGetTimeseriesViewsAsync()
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = baseUrl + "/data/viewlist/current-views/getTimeseriesViews";

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
            var response = new GetDataViewlistCurrentViewsGetTimeseriesViewsResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<GetDataViewlistCurrentViewsGetTimeseriesViewsResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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
            else if (httpCode >= 400 && httpCode < 500)
            {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else if (httpCode == 500 || httpCode >= 500 && httpCode < 600)
            {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else
            {
                throw new APIException("unknown status code received", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            return response;
        }

        

        
        public async Task<GetDataViewlistCurrentViewsFilterResponse> GetDataViewlistCurrentViewsFilterAsync(GetDataViewlistCurrentViewsFilterDimension? dimension = null, long? limit = null)
        {
            var request = new GetDataViewlistCurrentViewsFilterRequest()
            {
                Dimension = dimension,
                Limit = limit,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/data/viewlist/current-views/filter", request);

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
            var response = new GetDataViewlistCurrentViewsFilterResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<GetDataViewlistCurrentViewsFilterResponseBody>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
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
            else if (httpCode >= 400 && httpCode < 500)
            {
                throw new APIException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else if (httpCode == 500 || httpCode >= 500 && httpCode < 600)
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