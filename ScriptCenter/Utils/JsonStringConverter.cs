using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;

namespace ScriptCenter.Utils
{
    /// <summary>
    /// A general purpose JsonConverter to convert an object from and to a String, using the ToString method and ctor(String).
    /// </summary>
    public class JsonStringConverter : JsonConverter
    {
        private ConstructorInfo _constructor;

        public override bool CanConvert(Type objectType)
        {
            _constructor = objectType.GetConstructor(new Type[] { typeof(String) });
            return _constructor != null;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (_constructor == null)
                return null;

            String str = (String)serializer.Deserialize(reader, typeof(String));
            return _constructor.Invoke(new object[] { str });
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
