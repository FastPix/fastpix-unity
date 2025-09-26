

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Determines whether access to the streamed content is kept private or available to all.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum CreateMediaRequestAccessPolicy
    {
        [JsonProperty("public")]
        Public,
        [JsonProperty("private")]
        Private,
        [JsonProperty("drm")]
        Drm,
    }

    public static class CreateMediaRequestAccessPolicyExtension
    {
        public static string Value(this CreateMediaRequestAccessPolicy value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static CreateMediaRequestAccessPolicy ToEnum(this string value)
        {
            foreach(var field in typeof(CreateMediaRequestAccessPolicy).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (CreateMediaRequestAccessPolicy)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum CreateMediaRequestAccessPolicy");
        }
    }

}