

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The BCP 47 language code representing the language of the generated track.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum GenerateTrackResponseLanguageCode
    {
        [JsonProperty("ar-SA")]
        ArSA,
        [JsonProperty("bn-BD")]
        BnBD,
        [JsonProperty("bn-IN")]
        BnIN,
        [JsonProperty("ca-ES")]
        CaES,
        [JsonProperty("cs-CZ")]
        CsCZ,
        [JsonProperty("da-DK")]
        DaDK,
        [JsonProperty("de-AT")]
        DeAT,
        [JsonProperty("de-CH")]
        DeCH,
        [JsonProperty("de-DE")]
        Dede,
        [JsonProperty("el-GR")]
        ElGR,
        [JsonProperty("en-AU")]
        EnAU,
        [JsonProperty("en-CA")]
        EnCA,
        [JsonProperty("en-GB")]
        EnGB,
        [JsonProperty("en-IE")]
        EnIE,
        [JsonProperty("en-IN")]
        EnIN,
        [JsonProperty("en-NZ")]
        EnNZ,
        [JsonProperty("en-US")]
        EnUS,
        [JsonProperty("en-ZA")]
        EnZA,
        [JsonProperty("es-AR")]
        EsAR,
        [JsonProperty("es-CL")]
        EsCL,
        [JsonProperty("es-CO")]
        EsCO,
        [JsonProperty("es-ES")]
        Eses,
        [JsonProperty("es-MX")]
        EsMX,
        [JsonProperty("es-US")]
        EsUS,
        [JsonProperty("fi-FI")]
        Fifi,
        [JsonProperty("fr-BE")]
        FrBE,
        [JsonProperty("fr-CA")]
        FrCA,
        [JsonProperty("fr-CH")]
        FrCH,
        [JsonProperty("fr-FR")]
        Frfr,
        [JsonProperty("he-IL")]
        HeIL,
        [JsonProperty("hi-IN")]
        HiIN,
        [JsonProperty("hr-HR")]
        Hrhr,
        [JsonProperty("hu-HU")]
        Huhu,
        [JsonProperty("id-ID")]
        Idid,
        [JsonProperty("it-CH")]
        ItCH,
        [JsonProperty("it-IT")]
        Itit,
        [JsonProperty("ja-JP")]
        JaJP,
        [JsonProperty("ko-KR")]
        KoKR,
        [JsonProperty("nl-BE")]
        NlBE,
        [JsonProperty("nl-NL")]
        Nlnl,
        [JsonProperty("no-NO")]
        Nono,
        [JsonProperty("pl-PL")]
        Plpl,
        [JsonProperty("pt-BR")]
        PtBR,
        [JsonProperty("pt-PT")]
        Ptpt,
        [JsonProperty("ro-RO")]
        Roro,
        [JsonProperty("ru-RU")]
        Ruru,
        [JsonProperty("sk-SK")]
        Sksk,
        [JsonProperty("sv-SE")]
        SvSE,
        [JsonProperty("ta-IN")]
        TaIN,
        [JsonProperty("ta-LK")]
        TaLK,
        [JsonProperty("th-TH")]
        Thth,
        [JsonProperty("tr-TR")]
        Trtr,
        [JsonProperty("uk-UA")]
        UkUA,
        [JsonProperty("bg-BG")]
        Bgbg,
        [JsonProperty("zh-CN")]
        ZhCN,
        [JsonProperty("zh-HK")]
        ZhHK,
        [JsonProperty("zh-TW")]
        ZhTW,
    }

    public static class GenerateTrackResponseLanguageCodeExtension
    {
        public static string Value(this GenerateTrackResponseLanguageCode value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static GenerateTrackResponseLanguageCode ToEnum(this string value)
        {
            foreach(var field in typeof(GenerateTrackResponseLanguageCode).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (GenerateTrackResponseLanguageCode)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum GenerateTrackResponseLanguageCode");
        }
    }

}