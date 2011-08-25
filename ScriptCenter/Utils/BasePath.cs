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
        protected List<String> _components;

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
            /*
            get 
            {
                String r = "";
                foreach (String s in _components)
                    r += s + PathHelperMethods.SeparatorChar;
                return r; 
            }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("AbsolutePath value cannot be null.");
                _components = value.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
             */
        }

        public IList<String> PathComponents
        {
            get { return _path.Split(new char[] { PathHelperMethods.SeparatorChar }, StringSplitOptions.RemoveEmptyEntries).ToList().AsReadOnly(); }
            //get { return _components.AsReadOnly(); }
        }

        /// <summary>
        /// True if the path is a path to a file.
        /// </summary>
        public Boolean IsFilePath
        {
            get { return PathHelperMethods.IsFilePath(_path); }
            //get { return PathHelperMethods.IsFilePath(_components.Last()); }
        }

        /// <summary>
        /// True if the path is a path to a directory.
        /// </summary>
        public Boolean IsDirectoryPath
        {
            get { return !PathHelperMethods.IsFilePath(_path); }
            //get { return !PathHelperMethods.IsFilePath(_components.Last()); }
        }

        /// <summary>
        /// Returns a new IPath instance that is a combination of this IPath object and the supplied path String.
        /// </summary>
        public IPath Combine(String path)
        {
            if (path.StartsWith(".."))
                return new RelativePath(path, this);
            else
                return new BasePath(this.AbsolutePath + path);
        }

        /// <summary>
        /// Converts the path to a Uri.
        /// </summary>
        public Uri ToUri()
        {
            return new Uri(this.AbsolutePath);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
    }
}
