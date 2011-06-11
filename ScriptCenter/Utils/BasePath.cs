using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ScriptCenter.Utils
{
    public class BasePath : IPath, INotifyPropertyChanged
    {
        protected String _path;

        protected BasePath() { }

        /// <summary>
        /// Creates a new BasePath instance from the supplied path.
        /// </summary>
        /// <param name="path">Path to a file or directory.</param>
        public BasePath(String path)
        {
            this.AbsolutePath = path;
        }

        /// <summary>
        /// The absolute path to the file or directory.
        /// </summary>
        public String AbsolutePath
        {
            get { return _path; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("Cannot set Path to null.");

                _path = value.Replace(PathHelperMethods.ReplaceSeparatorChar, PathHelperMethods.SeparatorChar);
                this.OnPropertyChanged(new PropertyChangedEventArgs("Path"));
            }
        }

        public IList<String> PathComponents
        {
            get { return _path.Split(new char[] { PathHelperMethods.SeparatorChar }, StringSplitOptions.RemoveEmptyEntries).ToList().AsReadOnly(); }
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
