

#nullable enable
namespace fastpix.io.Utils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using UnityEngine;
    using UnityEngine.Networking;

    internal class RequestBodySerializer
    {
        internal class SerializedRequestBody
        {
            public string ContentType { get; set; }
            public byte[] Body { get; set; }

            public SerializedRequestBody(string contentType, byte[] body)
            {
                ContentType = contentType;
                Body = body;
            }
        }

        public static SerializedRequestBody? Serialize(
            object? request,
            string requestFieldName,
            string serializationMethod,
            bool nullable = false,
            bool optional = false,
            string format = ""
        )
        {
            if (request == null)
            {
                if (!nullable && !optional)
                {
                    throw new ArgumentNullException("request body is required");
                }
                else if (nullable && serializationMethod == "json")
                {
                    return new SerializedRequestBody("application/json", System.Text.Encoding.UTF8.GetBytes("null"));
                }

                return null;
            }

            if (Utilities.IsClass(request))
            {
                var prop = GetPropertyInfo(request, requestFieldName);

                if (prop != null)
                {
                    var metadata = prop.GetCustomAttribute<FastPixMetadata>()
                        ?.GetRequestMetadata();
                    if (metadata != null)
                    {
                        var fieldValue = prop.GetValue(request);
                        if (fieldValue == null)
                        {
                            return null;
                        }

                        return TrySerialize(
                            fieldValue,
                            requestFieldName,
                            serializationMethod,
                            metadata.MediaType ?? ""
                        );
                    }
                }
            }

            // Not an object or flattened request
            return TrySerialize(request, requestFieldName, serializationMethod, "", format);
        }

        private static SerializedRequestBody? TrySerialize(
            object request,
            string requestFieldName,
            string serializationMethod,
            string mediaType = "",
            string format = ""
        )
        {
            if (mediaType == "")
            {
                mediaType = new Dictionary<string, string>()
                {
                    { "json", "application/json" },
                    { "form", "application/x-www-form-urlencoded" },
                    { "multipart", "multipart/form-data" },
                    { "raw", "application/octet-stream" },
                    { "string", "text/plain" },
                }[serializationMethod];
            }

            switch (serializationMethod)
            {
                case "json":
                    return SerializeJson(request, mediaType, format);
                case "form":
                    return SerializeForm(request, requestFieldName, mediaType);
                case "multipart":
                    return SerializeMultipart(request, mediaType);
                default:
                    // if request is a byte array, use it directly otherwise encode
                    if (request.GetType() == typeof(byte[]))
                    {
                        return SerializeRaw((byte[])request, mediaType);
                    }
                    else if (request.GetType() == typeof(string))
                    {
                        return SerializeString((string)request, mediaType);
                    }
                    else
                    {
                        throw new Exception(
                            "Cannot serialize request body of type "
                                + request.GetType().Name
                                + " with serialization method "
                                + serializationMethod
                                + ""
                        );
                    }
            }
        }

        private static SerializedRequestBody SerializeJson(object request, string mediaType, string format = "")
        {
            return new SerializedRequestBody(
                mediaType,
                System.Text.Encoding.UTF8.GetBytes(Utilities.SerializeJSON(request, format))
            );
        }

        private static SerializedRequestBody SerializeForm(
            object request,
            string requestFieldName,
            string mediaType
        )
        {
            WWWForm form = new WWWForm();

            if (Utilities.IsClass(request))
            {
                var props = request.GetType().GetProperties();

                foreach (var prop in props)
                {
                    var val = prop.GetValue(request);
                    if (val == null)
                    {
                        continue;
                    }

                    var metadata = prop.GetCustomAttribute<FastPixMetadata>()?.GetFormMetadata();
                    if (metadata == null)
                    {
                        continue;
                    }

                    if (metadata.Json)
                    {
                        form.AddField(metadata.Name ?? prop.Name, Utilities.SerializeJSON(val));
                    }
                    else
                    {
                        switch (metadata.Style)
                        {
                            case "form":
                                SerializeFormValue(
                                    metadata.Name ?? prop.Name,
                                    metadata.Explode,
                                    val,
                                    ref form
                                );
                                break;
                            default:
                                throw new Exception("Unsupported form style " + metadata.Style);
                        }
                    }
                }
            }
            else if (Utilities.IsDictionary(request))
            {
                foreach (var key in ((IDictionary)request).Keys)
                {
                    form.AddField(
                        key.ToString(),
                        Utilities.ValueToString(((IDictionary)request)[key])
                    );
                }
            }
            else if (Utilities.IsList(request))
            {
                foreach (var item in (IList)request)
                {
                    form.AddField(requestFieldName, Utilities.ValueToString(item));
                }
            }
            else
            {
                throw new Exception(
                    "Cannot serialize form data from type " + request.GetType().Name
                );
            }

            return new SerializedRequestBody(mediaType, form.data);
        }

        private static SerializedRequestBody SerializeMultipart(object request, string mediaType)
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

            var properties = request.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(request);
                if (value == null)
                {
                    continue;
                }

                var metadata = prop.GetCustomAttribute<FastPixMetadata>()
                    ?.GetMultipartFormMetadata();
                if (metadata == null)
                {
                    continue;
                }

                if (metadata.File)
                {
                    if (Utilities.IsList(value))
                    {
                        // Handle array/list of files - similar to how normal lists are handled
                        foreach (var fileItem in (IList)value)
                        {
                            if (!Utilities.IsClass(fileItem))
                            {
                                throw new Exception(
                                    "Cannot serialize multipart file from type " + fileItem.GetType().Name
                                );
                            }

                            var fileProps = fileItem.GetType().GetProperties();
                            var (fileName, content) = ExtractFileProperties(fileProps, fileItem);
                            string fieldName = (metadata.Name ?? prop.Name) + "[]";

                            formData.Add(
                                new MultipartFormFileSection(
                                    fieldName,
                                    content,
                                    fileName,
                                    "application/octet-stream"
                                )
                            );
                        }
                    }
                    else if (Utilities.IsClass(value))
                    {
                        // Handle single file
                        var fileProps = value.GetType().GetProperties();
                        var (fileName, content) = ExtractFileProperties(fileProps, value);
                        string fieldName = metadata.Name ?? prop.Name;

                        formData.Add(
                            new MultipartFormFileSection(
                                fieldName,
                                content,
                                fileName,
                                "application/octet-stream"
                            )
                        );
                    }
                    else
                    {
                        throw new Exception(
                            "Cannot serialize multipart file from type " + value.GetType().Name
                        );
                    }
                }
                else if (metadata.Json)
                {
                    formData.Add(
                        new MultipartFormDataSection(
                            metadata.Name ?? prop.Name,
                            Utilities.SerializeJSON(value)
                        )
                    );
                }
                else if (Utilities.IsList(value))
                {
                    var values = new List<string>();

                    foreach (var item in (IList)value)
                    {
                        values.Add(Utilities.ValueToString(item));
                    }

                    foreach (var val in values)
                    {
                        formData.Add(
                            new MultipartFormDataSection($"{metadata.Name ?? prop.Name}[]", val)
                        );
                    }
                }
                else
                {
                    formData.Add(
                        new MultipartFormDataSection(
                            metadata.Name ?? prop.Name,
                            Utilities.ValueToString(value)
                        )
                    );
                }
            }

            var boundary = UnityWebRequest.GenerateBoundary();

            var parts = mediaType.Split(';');

            return new SerializedRequestBody(
                $"{parts[0]}; boundary={Encoding.ASCII.GetString(boundary)}",
                UnityWebRequest.SerializeFormSections(formData, boundary)
            );
        }

        private static SerializedRequestBody SerializeRaw(byte[] request, string mediaType)
        {
            return new SerializedRequestBody(mediaType, request);
        }

        private static SerializedRequestBody SerializeString(string request, string mediaType)
        {
            return new SerializedRequestBody(
                mediaType,
                System.Text.Encoding.UTF8.GetBytes(request)
            );
        }

        private static void SerializeFormValue(
            string fieldName,
            bool explode,
            object value,
            ref WWWForm form
        )
        {
            if (Utilities.IsClass(value))
            {
                if (Utilities.IsDate(value))
                {
                    form.AddField(fieldName, Utilities.ValueToString(value));
                }
                else
                {
                    var props = value.GetType().GetProperties();

                    var items = new List<string>();

                    foreach (var prop in props)
                    {
                        var val = prop.GetValue(value);
                        if (val == null)
                        {
                            continue;
                        }

                        var metadata = prop.GetCustomAttribute<FastPixMetadata>()
                            ?.GetFormMetadata();
                        if (metadata == null || metadata.Name == null)
                        {
                            continue;
                        }

                        if (explode)
                        {
                            form.AddField(metadata.Name, Utilities.ValueToString(val));
                        }
                        else
                        {
                            items.Add($"{metadata.Name},{Utilities.ValueToString(val)}");
                        }
                    }

                    if (items.Count > 0)
                    {
                        form.AddField(fieldName, String.Join(",", items));
                    }
                }
            }
            else if (Utilities.IsDictionary(value))
            {
                var items = new List<string>();

                foreach (var key in ((IDictionary)value).Keys)
                {
                    if (explode)
                    {
                        form.AddField(
                            key.ToString(),
                            Utilities.ValueToString(((IDictionary)value)[key])
                        );
                    }
                    else
                    {
                        items.Add($"{key},{Utilities.ValueToString(((IDictionary)value)[key])}");
                    }
                }

                if (items.Count > 0)
                {
                    form.AddField(fieldName, String.Join(",", items));
                }
            }
            else if (Utilities.IsList(value))
            {
                var values = new List<string>();
                var items = new List<string>();

                foreach (var item in (IList)value)
                {
                    if (explode)
                    {
                        values.Add(Utilities.ValueToString(item));
                    }
                    else
                    {
                        items.Add(Utilities.ValueToString(item));
                    }
                }

                if (items.Count > 0)
                {
                    values.Add(string.Join(",", items));
                }

                foreach (var val in values)
                {
                    form.AddField(fieldName, val);
                }
            }
            else
            {
                form.AddField(fieldName, Utilities.ValueToString(value));
            }
        }

        private static (string fileName, byte[] content) ExtractFileProperties(PropertyInfo[] fileProps, object fileObject)
        {
            byte[]? content = null;
            string fileName = "";

            foreach (var fileProp in fileProps)
            {
                var fileMetadata = fileProp
                    .GetCustomAttribute<FastPixMetadata>()
                    ?.GetMultipartFormMetadata();
                if (
                    fileMetadata == null
                    || (!fileMetadata.Content && fileMetadata.Name == "")
                )
                {
                    continue;
                }

                if (fileMetadata.Content)
                {
                    content = (byte[]?)fileProp.GetValue(fileObject);
                }
                else
                {
                    fileName = fileProp.GetValue(fileObject)?.ToString() ?? "";
                }
            }

            if (fileName == "" || content == null)
            {
                throw new Exception("Invalid multipart/form-data file");
            }

            return (fileName, content);
        }

        private static PropertyInfo? GetPropertyInfo(object value, string propertyName)
        {
            try
            {
                return value.GetType().GetProperty(propertyName);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
