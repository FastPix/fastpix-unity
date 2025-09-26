

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Utils;
    

    public class SegmentUnionType
    {
        private SegmentUnionType(string value) { Value = value; }

        public string Value { get; private set; }
        public static SegmentUnionType Segment1 { get { return new SegmentUnionType("segment_1"); } }
        public static SegmentUnionType Segment2 { get { return new SegmentUnionType("segment_2"); } }
        public static SegmentUnionType Null { get { return new SegmentUnionType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(SegmentUnionType v) { return v.Value; }
        public static SegmentUnionType FromString(string v) {
            switch(v) {
                case "segment_1": return Segment1;
                case "segment_2": return Segment2;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for SegmentUnionType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((SegmentUnionType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    

    [JsonConverter(typeof(SegmentUnion.SegmentUnionConverter))]
    public class SegmentUnion {
        public SegmentUnion(SegmentUnionType type) {
            Type = type;
        }
        public Segment1? Segment1 { get; set; } 
        public Segment2? Segment2 { get; set; } 

        public SegmentUnionType Type {get; set; }


        public static SegmentUnion CreateSegment1(Segment1 segment1) {
            SegmentUnionType typ = SegmentUnionType.Segment1;

            SegmentUnion res = new SegmentUnion(typ);
            res.Segment1 = segment1;
            return res;
        }

        public static SegmentUnion CreateSegment2(Segment2 segment2) {
            SegmentUnionType typ = SegmentUnionType.Segment2;

            SegmentUnion res = new SegmentUnion(typ);
            res.Segment2 = segment2;
            return res;
        }

        public static SegmentUnion CreateNull() {
            SegmentUnionType typ = SegmentUnionType.Null;
            return new SegmentUnion(typ);
        }

        public class SegmentUnionConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(SegmentUnion);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                }
                try
                {
                    Segment1? segment1 = JsonConvert.DeserializeObject<Segment1>(json, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Error, Converters = Utilities.GetJsonDeserializers(typeof(Segment1))});
                    return new SegmentUnion(SegmentUnionType.Segment1) {
                        Segment1 = segment1
                    };
                }
                catch (Exception ex)
                {
                    if (!(ex is Newtonsoft.Json.JsonReaderException || ex is Newtonsoft.Json.JsonSerializationException)) {
                        throw ex;
                    }
                }
                try
                {
                    Segment2? segment2 = JsonConvert.DeserializeObject<Segment2>(json, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Error, Converters = Utilities.GetJsonDeserializers(typeof(Segment2))});
                    return new SegmentUnion(SegmentUnionType.Segment2) {
                        Segment2 = segment2
                    };
                }
                catch (Exception ex)
                {
                    if (!(ex is Newtonsoft.Json.JsonReaderException || ex is Newtonsoft.Json.JsonSerializationException)) {
                        throw ex;
                    }
                }

                throw new InvalidOperationException("Could not deserialize into any supported types.");
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value == null) {
                    writer.WriteRawValue("null");
                    return;
                }
                SegmentUnion res = (SegmentUnion)value;
                if (SegmentUnionType.FromString(res.Type).Equals(SegmentUnionType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Segment1 != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Segment1));
                    return;
                }
                if (res.Segment2 != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Segment2));
                    return;
                }

            }
        }

    }

}