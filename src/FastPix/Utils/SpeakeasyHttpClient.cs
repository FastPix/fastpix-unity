

#nullable enable
namespace fastpix.io.Utils
{
    using System.Collections.Generic;
    using UnityEngine.Networking;
    using System.Threading.Tasks;

    public interface FastPixHttpClient
    {
        void AddHeader(string key, string value);
        void AddQueryParam(string key, string value);
        Task<UnityWebRequest> SendAsync(UnityWebRequest message);
    }

    public class FastPixHttpClient : FastPixHttpClient
    {
        private FastPixHttpClient? client;

        private Dictionary<string, List<string>> headers { get; } =
            new Dictionary<string, List<string>>();

        private Dictionary<string, List<string>> queryParams { get; } =
            new Dictionary<string, List<string>>();

        internal FastPixHttpClient(FastPixHttpClient? client = null)
        {
            this.client = client;
        }

        public void AddHeader(string key, string value)
        {
            if (headers.ContainsKey(key))
            {
                headers[key].Add(value);
            }
            else
            {
                headers.Add(key, new List<string> { value });
            }
        }

        public void AddQueryParam(string key, string value)
        {
            if (queryParams.ContainsKey(key))
            {
                queryParams[key].Add(value);
            }
            else
            {
                queryParams.Add(key, new List<string> { value });
            }
        }

        public async Task<UnityWebRequest> SendAsync(UnityWebRequest message)
        {
            foreach (var hh in headers)
            {
                foreach (var hv in hh.Value)
                {
                    message.SetRequestHeader(hh.Key, hv);
                }
            }

            var qp = URLBuilder.SerializeQueryParams(queryParams);

            if (qp != "")
            {
                if (message.uri.Query == "")
                {
                    message.url += "?" + qp;
                }
                else
                {
                    message.url += "&" + qp;
                }
            }

            if (client != null)
            {
                return await client.SendAsync(message);
            }

            await message.SendWebRequest();
            return message;
        }
    }
}
