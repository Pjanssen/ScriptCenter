﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace ScriptCenter.Xml
{
    public class WebFileHandler<T>
    {
        private WebClient client;
        private XmlSerializer serializer;

        public event LoadErrorEventHandler LoadError;
        public delegate void LoadErrorEventHandler(object sender, LoadErrorEventArgs args);
        public event LoadCompletedEventHandler LoadCompleted;
        public delegate void LoadCompletedEventHandler(object sender, LoadCompleteEventArgs<T> args);

        public WebFileHandler() : base()
        {
            this.client = new WebClient();
            this.client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(_client_DownloadStringCompleted);
            this.serializer = new XmlSerializer(typeof(T));
        }

        private void _client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (e.Error != null)
            {
                this.OnLoadError(new LoadErrorEventArgs(e.Error));
                return;
            }

            try
            {
                StringReader str = new StringReader(e.Result);
                T data = (T)this.serializer.Deserialize(str);
                this.OnLoadCompleted(new LoadCompleteEventArgs<T>(data));
            }
            catch (Exception exc)
            {
                this.OnLoadError(new LoadErrorEventArgs(exc));
            }
        }


        protected virtual void OnLoadError(LoadErrorEventArgs args)
        {
            if (this.LoadError != null)
                this.LoadError(this, args);
        }

        protected virtual void OnLoadCompleted(LoadCompleteEventArgs<T> args)
        {
            if (this.LoadCompleted != null)
                this.LoadCompleted(this, args);
        }

        public void Load(String address)
        {
            try
            {
                this.client.DownloadStringAsync(new Uri(address));
            }
            catch (Exception e)
            {
                this.OnLoadError(new LoadErrorEventArgs(e));
            }
        }
    }


    public class LoadErrorEventArgs : EventArgs
    {
        public Exception Error { get; private set; }
        public LoadErrorEventArgs(Exception error)
        {
            this.Error = error;
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

    
}
