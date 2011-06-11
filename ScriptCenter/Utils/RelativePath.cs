using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ScriptCenter.Utils
{
    public class RelativePath : IPath, INotifyPropertyChanged
    {
        protected String _path;
        protected IPath _relativeTo;

        /// <summary>
        /// Creates a new RelativePath instance.
        /// </summary>
        /// <param name="path">The relative path to a file or directory.</param>
        /// <param name="relativeTo">The path this path is relative to.</param>
        public RelativePath(String path, IPath relativeTo)
        {
            if (path == null)
                throw new ArgumentNullException("RelativePath parameter cannot be null.");

            if (relativeTo == null)
                throw new ArgumentNullException("RelativeTo parameter cannot be null.");

            if (relativeTo.IsFilePath)
                throw new ArgumentException("Cannot create a path relative to a file path.");

            _relativeTo = relativeTo;

            if (PathHelperMethods.IsAbsolutePath(path))
                this.AbsolutePath = path;
            else
                this.RelativePathComponent = path;
        }

        /// <summary>
        /// The absolute path to the file or directory.
        /// </summary>
        public String AbsolutePath
        {
            get { return PathHelperMethods.GetAbsolutePath(_path, _relativeTo.AbsolutePath); }
            set 
            {
                _path = PathHelperMethods.GetRelativePath(value, _relativeTo.AbsolutePath);
                this.OnPropertyChanged(new PropertyChangedEventArgs("Path"));
            }
        }

        public IList<String> PathComponents
        {
            get 
            {
                return this.AbsolutePath.Split(new char[] {PathHelperMethods.SeparatorChar }, StringSplitOptions.RemoveEmptyEntries).ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// The relative path component.
        /// </summary>
        public String RelativePathComponent
        {
            get { return _path; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("Cannot set RelativePathComponent to null.");

                _path = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("RelativePathComponent"));
            }
        }

        /// <summary>
        /// The path instance this path is relative to.
        /// </summary>
        public IPath RelativeTo
        {
            get { return _relativeTo; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("Cannot set RelativeTo to null.");

                _relativeTo = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("RelativeTo"));
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
