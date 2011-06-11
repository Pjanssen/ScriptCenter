using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ScriptCenter.Utils
{
    public class BasePathJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(BasePath))
                return true;

            if (objectType == typeof(RelativePath))
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            String path = (String)serializer.Deserialize(reader, typeof(String));

            if (objectType == typeof(BasePath))
                return new BasePath(path);

            if (objectType == typeof(RelativePath) && existingValue != null)
                ((RelativePath)existingValue).RelativePathComponent = path;

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            String path = null;

            if (value.GetType() == typeof(BasePath))
                path = ((BasePath)value).AbsolutePath;

            if (value.GetType() == typeof(RelativePath))
                path = ((RelativePath)value).RelativePathComponent;

            if (path != null)
                serializer.Serialize(writer, path);
        }
    }
}
