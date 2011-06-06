using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ScriptCenter.Repository
{
    public class ScriptManifestReferenceConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(ScriptManifestReference))
                return true;

            return false;
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            String uriValue = (String)serializer.Deserialize(reader, typeof(String));
            return new ScriptManifestReference(uriValue);
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((ScriptManifestReference)value).Uri);
        }
    }
}
