#if !UNITY_5_3_OR_NEWER

using System;
using System.Threading.Tasks;

namespace UnityEngine
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class SerializeFieldAttribute : Attribute { }
}

namespace UnityEngine.Networking
{
    using System;

    public enum UnityWebRequestResult
    {
        Success,
        ConnectionError,
        DataProcessingError,
        ProtocolError
    }

    public class UnityWebRequest : IDisposable
    {
        public static readonly string kHttpVerbPOST = "POST";

        public Uri uri { get; private set; }
        public string url { get; set; }
        public long responseCode { get; set; }
        public DownloadHandler downloadHandler { get; set; }
        public UploadHandler uploadHandler { get; set; }
        public UnityWebRequestResult result { get; set; } = UnityWebRequestResult.Success;

        public UnityWebRequest(string url, string method)
        {
            this.url = url;
            this.uri = new Uri(url);
        }

        public void SetRequestHeader(string key, string value) { }
        public Task SendWebRequest() => Task.CompletedTask;
        public string GetResponseHeader(string name) => null;
        public void Dispose() { }

        public enum Result { Success, ConnectionError, DataProcessingError, ProtocolError }
    }

    public abstract class DownloadHandler
    {
        public virtual byte[] data => Array.Empty<byte>();
        public virtual string text => System.Text.Encoding.UTF8.GetString(data);
        public virtual string GetResponseHeader(string name) => null;
    }

    public class UploadHandler { }

    public class UploadHandlerRaw : UploadHandler
    {
        public UploadHandlerRaw(byte[] body) { }
    }

    public class DownloadHandlerScript : DownloadHandler
    {
        protected DownloadHandlerScript(byte[] buffer) { }

        protected virtual byte[] GetData() => Array.Empty<byte>();
        protected virtual string GetText() => string.Empty;
        protected virtual bool ReceiveData(byte[] data, int dataLength) => true;
        protected virtual void CompleteContent() { }
        protected virtual void ReceiveContentLengthHeader(ulong contentLength) { }
    }
}

#endif 