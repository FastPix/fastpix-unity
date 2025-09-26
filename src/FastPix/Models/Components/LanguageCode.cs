

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Language code for content localization
    /// </summary>
    public enum LanguageCode
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
        [JsonProperty("ms-MY")]
        MsMY,
        [JsonProperty("nb-NO")]
        NbNO,
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
        [JsonProperty("te-IN")]
        TeIN,
        [JsonProperty("th-TH")]
        Thth,
        [JsonProperty("tr-TR")]
        Trtr,
        [JsonProperty("uk-UA")]
        UkUA,
        [JsonProperty("vi-VN")]
        ViVN,
        [JsonProperty("bg-BG")]
        Bgbg,
        [JsonProperty("zh-CN")]
        ZhCN,
        [JsonProperty("zh-HK")]
        ZhHK,
        [JsonProperty("zh-TW")]
        ZhTW,
    }

    public static class LanguageCodeExtension
    {
        public static string Value(this LanguageCode value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static LanguageCode ToEnum(this string value)
        {
            foreach(var field in typeof(LanguageCode).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (LanguageCode)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum LanguageCode");
        }
    }

}