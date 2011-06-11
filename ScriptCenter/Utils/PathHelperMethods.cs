using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter.Utils
{
    internal static class PathHelperMethods
    {
        internal const char SeparatorChar = '/';
        internal const char ReplaceSeparatorChar = '\\';

        /// <summary>
        /// Returns true if the given path is an absolute path (e.g. C:/, or http://).
        /// </summary>
        /// <param name="path">The path to test.</param>
        internal static bool IsAbsolutePath(String path)
        {
            if (path == null || path == String.Empty)
                return false;

            String[] splitPath = path.Split(new char[] { '/', '\\'}, StringSplitOptions.RemoveEmptyEntries);
            if (splitPath.Length == 0)
                return false;
            else
                return splitPath[0][splitPath[0].Length - 1] == ':';
        }

        /// <summary>
        /// Returns true if the given path is a path to a file, otherwise false.
        /// </summary>
        /// <param name="path">The path to test.</param>
        internal static bool IsFilePath(String path)
        {
            if (path == null)
                return false;

            path = path.Trim();

            if (path == String.Empty)
                return false;

            return !path.EndsWith("/") && !path.EndsWith("\\");
        }

        /// <summary>
        /// Converts an absolute path to a relative path.
        /// </summary>
        /// <param name="absolutePath">The absolute path to convert.</param>
        /// <param name="basePath">The base path the new path should be relative to.</param>
        internal static string GetRelativePath(String absolutePath, String basePath)
        {
            StringBuilder newPath = new StringBuilder();

            String[] baseComponents = basePath.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            String[] pathComponents = absolutePath.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);

            if (baseComponents.Length == 0 || pathComponents.Length == 0)
                return absolutePath;

            //If non-common base, return absolute path.
            if (baseComponents[0] != pathComponents[0])
                return absolutePath;

            Int32 findCommonBaseLoopLen = Math.Min(baseComponents.Length, pathComponents.Length);
            Int32 commonBaseIndex = 0;
            while (commonBaseIndex < findCommonBaseLoopLen && baseComponents[commonBaseIndex] == pathComponents[commonBaseIndex])
            {
                commonBaseIndex++;
            }


            //Append starting / if basepath doesn't end with one.
            if (!basePath.EndsWith("/") && !basePath.EndsWith("\\"))
                newPath.Append("/");

            //Given path is not a subfolder of base -> create base from ../'s
            if (commonBaseIndex < baseComponents.Length)
            {
                for (Int32 i = 0; i < baseComponents.Length - commonBaseIndex; i++)
                    newPath.Append("../");
            }

            //Append the remaining path components.
            for (Int32 i = commonBaseIndex; i < pathComponents.Length; i++)
            {
                newPath.Append(pathComponents[i]);
                newPath.Append("/");
            }

            //Remove trailing slash if it wasn't in the supplied relative path.
            if (PathHelperMethods.IsFilePath(absolutePath) && newPath.Length > 0)
                newPath.Remove(newPath.Length - 1, 1);

            return newPath.ToString();
        }

        /// <summary>
        /// Converts a relative path to an absolute path.
        /// </summary>
        /// <param name="relativePath">The relative path to convert.</param>
        /// <param name="relativeTo">The base path the first path is relative to.</param>
        internal static string GetAbsolutePath(String relativePath, String basePath)
        {
            if (PathHelperMethods.IsAbsolutePath(relativePath))
                return relativePath;

            StringBuilder newPath = new StringBuilder();

            //Split the strings into uri components.
            String[] baseComponents = basePath.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            String[] relativeComponents = relativePath.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);

            Int32 numBaseComponents = baseComponents.Length;
            Int32 numRelativeComponents = relativeComponents.Length;
            Int32 folderUpCount = relativeComponents.Count(s => s == "..");

            // Loop through base components and construct new path up to the required base folder.
            for (Int32 i = 0; i < numBaseComponents - folderUpCount; i++)
            {
                String component = baseComponents[i];
                newPath.Append(component);

                String slash = "/";
                if (component.EndsWith(":"))
                {
                    Int32 index = basePath.IndexOf(component) + component.Length;
                    if (basePath.Length > index + 1)
                        if ((basePath[index] == '/' || basePath[index] == '\\') && (basePath[index + 1] == '/' || basePath[index + 1] == '\\'))
                            slash += "/";
                }
                newPath.Append(slash);
            }
            
            //Loop through relative components and append to new path.
            for (Int32 i = folderUpCount; i < numRelativeComponents; i++)
            {
                newPath.Append(relativeComponents[i]);
                newPath.Append("/");
            }

            //Remove trailing slash if it wasn't in the supplied relative path.
            if (PathHelperMethods.IsFilePath(relativePath))
                newPath.Remove(newPath.Length - 1, 1);
            
            return newPath.ToString();
        }
    }
}
