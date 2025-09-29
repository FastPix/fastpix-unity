#if !UNITY_5_3_OR_NEWER

using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnityEngine
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class SerializeFieldAttribute : Attribute { }

    public class AsyncOperation
    {
        public Action<AsyncOperation>? completed;
        internal void Complete() => completed?.Invoke(this);
    }
}

namespace UnityEngine.Networking
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public interface IMultipartFormSection { }

    public class MultipartFormDataSection : IMultipartFormSection
    {
        public string SectionName { get; }
        public string SectionData { get; }
        public MultipartFormDataSection(string name, string data)
        {
            SectionName = name; SectionData = data;
        }
    }

    public class MultipartFormFileSection : IMultipartFormSection
    {
        public string FileName { get; }
        public string FieldName { get; }
        public byte[] Data { get; }
        public string ContentType { get; }
        public MultipartFormFileSection(string fieldName, byte[] data, string fileName, string contentType)
        {
            FieldName = fieldName; Data = data; FileName = fileName; ContentType = contentType;
        }
    }

    public class WWWForm
    {
        private readonly List<KeyValuePair<string,string>> fields = new List<KeyValuePair<string,string>>();
        public byte[] data => Encoding.UTF8.GetBytes(Build());
        public void AddField(string name, string value) => fields.Add(new KeyValuePair<string,string>(name, value));
        private string Build()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < fields.Count; i++)
            {
                var kv = fields[i];
                if (i > 0) sb.Append('&');
                sb.Append(Uri.EscapeDataString(kv.Key));
                sb.Append('=');
                sb.Append(Uri.EscapeDataString(kv.Value));
            }
            return sb.ToString();
        }
    }

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
        public static readonly string kHttpVerbGET = "GET";
        public static readonly string kHttpVerbPUT = "PUT";

        public Uri uri { get; private set; }
        public string url { get; set; }
        public long responseCode { get; set; }
        public DownloadHandler? downloadHandler { get; set; }
        public UploadHandler? uploadHandler { get; set; }
        public Result result { get; set; } = Result.Success;

        public UnityWebRequest(string url, string method)
        {
            this.url = url;
            this.uri = new Uri(url);
        }

        public void SetRequestHeader(string? key, string? value) { }
        public Task SendWebRequest() => Task.CompletedTask;
        public string? GetResponseHeader(string name) => null;
        public void Dispose() { }

        public enum Result { Success, ConnectionError, DataProcessingError, ProtocolError }

        public static byte[] GenerateBoundary() => Encoding.ASCII.GetBytes("---------------------------fastpixboundary");
        public static byte[] SerializeFormSections(List<IMultipartFormSection> sections, byte[] boundary)
        {
            return Encoding.UTF8.GetBytes("--" + Encoding.ASCII.GetString(boundary));
        }
    }

    public abstract class DownloadHandler
    {
        public virtual byte[] data => Array.Empty<byte>();
        public virtual string text => System.Text.Encoding.UTF8.GetString(data);
        public virtual string? GetResponseHeader(string name) => null;
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