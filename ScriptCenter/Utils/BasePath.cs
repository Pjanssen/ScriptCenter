using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ScriptCenter.Utils
{
    public class BasePath : INotifyPropertyChanged
    {
        protected String _path;

        protected BasePath() { }

        /// <summary>
        /// Creates a new BasePath instance from the supplied path.
        /// </summary>
        /// <param name="path">Path to a file or directory.</param>
        public BasePath(String path)
        {
            this.Path = path;
        }

        /// <summary>
        /// The absolute path to the file or directory.
        /// </summary>
        public virtual String Path
        {
            get { return _path; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("Cannot set Path to null.");

                _path = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Path"));
            }
        }

        /// <summary>
        /// True if the path is a path to a file.
        /// </summary>
        public Boolean IsFilePath
        {
            get { return PathHelperMethods.IsFilePath(_path); }
        }

        /// <summary>
        /// True if the path is a path to a directory.
        /// </summary>
        public Boolean IsDirectoryPath
        {
            get { return !PathHelperMethods.IsFilePath(_path); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
    }
}
