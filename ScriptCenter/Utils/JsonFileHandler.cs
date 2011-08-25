using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace ScriptCenter.Utils
{
    /// <summary>
    /// A generic file handler class to read and write JSON files.
    /// </summary>
    /// <typeparam name="T">The type of object to read/write.</typeparam>
    public class JsonFileHandler<T>
    {
        private JsonSerializer serializer;

        public event ReadCompleteEventHandler ReadComplete;
        public delegate void ReadCompleteEventHandler(object sender, ReadCompleteEventArgs<T> e);
        protected void OnReadComplete(ReadCompleteEventArgs<T> args)
        {
            if (this.ReadComplete != null)
                this.ReadComplete(this, args);
        }

        public event ErrorEventHandler ReadError;
        public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);
        protected void OnReadError(ErrorEventArgs args)
        {
            if (this.ReadError != null)
                this.ReadError(this, args);
        }

        public event ErrorEventHandler SerializationError;
        protected void OnSerializationError(ErrorEventArgs args)
        {
            if (this.SerializationError != null)
                this.SerializationError(this, args);
        }

        public JsonFileHandler()
        {
            this.serializer = new JsonSerializer();
            this.serializer.Converters.Add(new StringEnumConverter());
            this.serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
            this.serializer.NullValueHandling = NullValueHandling.Ignore;
            this.serializer.TypeNameHandling = TypeNameHandling.Auto;
        }


        /// <summary>
        /// Reads and parses a file to an object.
        /// </summary>
        /// <param name="path">The file to read.</param>
        public T Read(IPath path)
        {
            T data = default(T);

            using (StreamReader sr = new StreamReader(path.AbsolutePath))
            using (JsonTextReader jr = new JsonTextReader(sr))
            {
                data = this.serializer.Deserialize<T>(jr);
            }

            return data;
        }

        /// <summary>
        /// Reads and parses a file asynchronously.
        /// </summary>
        /// <param name="path">The file to read.</param>
        public void ReadAsync(IPath path)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += this.client_DownloadStringCompleted;
            try
            {
                client.DownloadStringAsync(path.ToUri());
            }
            catch (Exception e)
            {
                this.OnReadError(new ErrorEventArgs(e));
            }
        }
        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.OnReadError(new ErrorEventArgs(e.Error));
                return;
            }

            StringReader str = new StringReader(e.Result);
            try
            {
                T data = (T)this.serializer.Deserialize(str, typeof(T));
                this.OnReadComplete(new ReadCompleteEventArgs<T>(data));
            }
            catch (Exception exception)
            {
                this.OnSerializationError(new ErrorEventArgs(exception));
            }
        }


        /// <summary>
        /// Serializes and writes an object to a file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="obj">The object to serialize and write.</param>
        public void Write(IPath path, T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Object to serialize cannot be null.");

            String dir = new FileInfo(path.AbsolutePath).DirectoryName;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (StreamWriter streamWriter = new StreamWriter(path.AbsolutePath))
            {
                this.Write(streamWriter, obj);
            }
        }

        public void Write(TextWriter writer, T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Object to serialize cannot be null.");

            using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
            {
                jsonWriter.Formatting = Formatting.Indented;
                this.serializer.Serialize(jsonWriter, obj);
            }
        }
    }

    public class ReadCompleteEventArgs<T> : EventArgs
    {
        public T Data { get; private set; }
        public ReadCompleteEventArgs(T data)
        {
            this.Data = data;
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }
        public ErrorEventArgs(Exception exception)
        {
            this.Exception = exception;
        }
    }
}
