

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Utils;
    

    public class InputType
    {
        private InputType(string value) { Value = value; }

        public string Value { get; private set; }
        public static InputType VideoInput { get { return new InputType("VideoInput"); } }
        public static InputType WatermarkInput { get { return new InputType("WatermarkInput"); } }
        public static InputType AudioInput { get { return new InputType("AudioInput"); } }
        public static InputType SubtitleInput { get { return new InputType("SubtitleInput"); } }
        public static InputType Null { get { return new InputType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(InputType v) { return v.Value; }
        public static InputType FromString(string v) {
            switch(v) {
                case "VideoInput": return VideoInput;
                case "WatermarkInput": return WatermarkInput;
                case "AudioInput": return AudioInput;
                case "SubtitleInput": return SubtitleInput;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for InputType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((InputType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    

    [JsonConverter(typeof(Input.InputConverter))]
    public class Input {
        public Input(InputType type) {
            Type = type;
        }
        public VideoInput? VideoInput { get; set; } 
        public WatermarkInput? WatermarkInput { get; set; } 
        public AudioInput? AudioInput { get; set; } 
        public SubtitleInput? SubtitleInput { get; set; } 

        public InputType Type {get; set; }


        public static Input CreateVideoInput(VideoInput videoInput) {
            InputType typ = InputType.VideoInput;

            Input res = new Input(typ);
            res.VideoInput = videoInput;
            return res;
        }

        public static Input CreateWatermarkInput(WatermarkInput watermarkInput) {
            InputType typ = InputType.WatermarkInput;

            Input res = new Input(typ);
            res.WatermarkInput = watermarkInput;
            return res;
        }

        public static Input CreateAudioInput(AudioInput audioInput) {
            InputType typ = InputType.AudioInput;

            Input res = new Input(typ);
            res.AudioInput = audioInput;
            return res;
        }

        public static Input CreateSubtitleInput(SubtitleInput subtitleInput) {
            InputType typ = InputType.SubtitleInput;

            Input res = new Input(typ);
            res.SubtitleInput = subtitleInput;
            return res;
        }

        public static Input CreateNull() {
            InputType typ = InputType.Null;
            return new Input(typ);
        }

        public class InputConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(Input);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                }
                try
                {
                    AudioInput? audioInput = JsonConvert.DeserializeObject<AudioInput>(json, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Error, Converters = Utilities.GetJsonDeserializers(typeof(AudioInput))});
                    return new Input(InputType.AudioInput) {
                        AudioInput = audioInput
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
                    SubtitleInput? subtitleInput = JsonConvert.DeserializeObject<SubtitleInput>(json, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Error, Converters = Utilities.GetJsonDeserializers(typeof(SubtitleInput))});
                    return new Input(InputType.SubtitleInput) {
                        SubtitleInput = subtitleInput
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
                    WatermarkInput? watermarkInput = JsonConvert.DeserializeObject<WatermarkInput>(json, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Error, Converters = Utilities.GetJsonDeserializers(typeof(WatermarkInput))});
                    return new Input(InputType.WatermarkInput) {
                        WatermarkInput = watermarkInput
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
                    VideoInput? videoInput = JsonConvert.DeserializeObject<VideoInput>(json, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Error, Converters = Utilities.GetJsonDeserializers(typeof(VideoInput))});
                    return new Input(InputType.VideoInput) {
                        VideoInput = videoInput
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
                Input res = (Input)value;
                if (InputType.FromString(res.Type).Equals(InputType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.VideoInput != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.VideoInput));
                    return;
                }
                if (res.WatermarkInput != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.WatermarkInput));
                    return;
                }
                if (res.AudioInput != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.AudioInput));
                    return;
                }
                if (res.SubtitleInput != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.SubtitleInput));
                    return;
                }

            }
        }

    }

}