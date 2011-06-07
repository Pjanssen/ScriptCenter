using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ScriptCenter.Utils
{
    public class RelativePath : BasePath
    {
        protected BasePath _relativeTo;

        /// <summary>
        /// Creates a new RelativePath instance.
        /// </summary>
        /// <param name="relativePath">The relative path to a file or directory.</param>
        /// <param name="relativeTo">The path this path is relative to.</param>
        public RelativePath(String relativePath, BasePath relativeTo)
        {
            if (relativePath == null)
                throw new ArgumentNullException("RelativePath parameter cannot be null.");

            if (relativeTo == null)
                throw new ArgumentNullException("RelativeTo parameter cannot be null.");

            if (relativeTo.IsFilePath)
                throw new ArgumentException("Cannot create a path relative to a file path.");

            _path = relativePath;
            _relativeTo = relativeTo;
        }

        /// <summary>
        /// The absolute path to the file or directory.
        /// </summary>
        public override String Path
        {
            get { return PathHelperMethods.GetAbsolutePath(_path, _relativeTo.Path); }
            set 
            {
                _path = PathHelperMethods.GetRelativePath(value, _relativeTo.Path);
                this.OnPropertyChanged(new PropertyChangedEventArgs("Path"));
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
        public BasePath RelativeTo
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
    }
}
