﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace ScriptCenter.Repository
{
    /// <summary>
    /// A generic file handler class to read and write JSON files.
    /// </summary>
    /// <typeparam name="T">The type of object to read/write.</typeparam>
    public class FileHandler<T>
    {
        private JsonSerializer serializer;

        public event LoadCompletedEventHandler LoadComplete;
        public delegate void LoadCompletedEventHandler(object sender, LoadCompleteEventArgs<T> e);
        protected void OnLoadComplete(LoadCompleteEventArgs<T> args)
        {
            if (this.LoadComplete != null)
                this.LoadComplete(this, args);
        }

        public event ErrorEventHandler LoadError;
        public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);
        protected void OnLoadError(ErrorEventArgs args)
        {
            if (this.LoadError != null)
                this.LoadError(this, args);
        }

        public event ErrorEventHandler SerializationError;
        protected void OnSerializationError(ErrorEventArgs args)
        {
            if (this.SerializationError != null)
                this.SerializationError(this, args);
        }

        public FileHandler()
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
        public T Read(String path)
        {
            T data = default(T);

            using (StreamReader sr = new StreamReader(path))
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
        public void ReadAsync(String path)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += this.client_DownloadStringCompleted;
            try
            {
                client.DownloadStringAsync(new Uri(path));
            }
            catch (Exception e)
            {
                this.OnLoadError(new ErrorEventArgs(e));
            }
        }
        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.OnLoadError(new ErrorEventArgs(e.Error));
                return;
            }

            StringReader str = new StringReader(e.Result);
            try
            {
                T data = (T)this.serializer.Deserialize(str, typeof(T));
                this.OnLoadComplete(new LoadCompleteEventArgs<T>(data));
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
        public void Write(String path, T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Object to serialize cannot be null.");

            String dir = new FileInfo(path).DirectoryName;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonTextWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                this.serializer.Serialize(jw, obj);
            }
        }
    }

    public class LoadCompleteEventArgs<T> : EventArgs
    {
        public T Data { get; private set; }
        public LoadCompleteEventArgs(T data)
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
