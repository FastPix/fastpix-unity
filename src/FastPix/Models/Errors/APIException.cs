


#nullable enable
namespace fastpix.io.Models.Errors
{
    using System;
    using System.Net.Http;
    using UnityEngine.Networking;

    public class APIException : Exception
    {
        public int StatusCode { get; set; }

        public override string Message { get; }
        public string Body { get; set; }

        public UnityWebRequest RawResponse { get; set; } = default!;

        public APIException(string message, int statusCode, string body, UnityWebRequest rawResponse)
        {
            Message = message;
            StatusCode = statusCode;
            Body = body;
            RawResponse = rawResponse;
        }

        public override string ToString(){
            var body = "";
            if (Body.Length > 0)
            {
                body += $"\n{Body}";
            }

            return Message + ": Status " + StatusCode + body;
        }

    }
}
