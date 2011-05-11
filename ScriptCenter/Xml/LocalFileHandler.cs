using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ScriptCenter.Xml
{
    public class LocalFileHandler<T>
    {
        private JsonSerializer serializer;

        public LocalFileHandler()
        {
            this.serializer = new JsonSerializer();
            this.serializer.Converters.Add(new StringEnumConverter());
            this.serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
            this.serializer.NullValueHandling = NullValueHandling.Ignore;
            this.serializer.TypeNameHandling = TypeNameHandling.Auto;
            
        }

        public T Load(String address)
        {
            T data = default(T);

            try
            {
                using (StreamReader sr = new StreamReader(address))
                using (JsonTextReader jr = new JsonTextReader(sr))
                {
                    data = this.serializer.Deserialize<T>(jr);
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }

        public Boolean Write(String address, T data)
        {
            Boolean success = false;

            try
            {
                String dir = new FileInfo(address).DirectoryName;
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                using (StreamWriter sw = new StreamWriter(address))
                using (JsonTextWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    this.serializer.Serialize(jw, data);
                }

                success = true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }

            return success;
        }
    }
}
