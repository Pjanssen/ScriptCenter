//  Copyright 2011 P.J. Janssen
//  This file is part of ScriptCenter.

//  ScriptCenter is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

//  ScriptCenter is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.

//  You should have received a copy of the GNU General Public License
//  along with ScriptCenter.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ScriptCenter.Package
{
    public static class InstallerLog
    {
        public const string DefaultLineFormat = "{0}";
        public const string TimeStampedLineFormat = "{1} | {0}";

        private static Dictionary<TextWriter, String> _writers = new Dictionary<TextWriter,String>();
        
        /// <summary>
        /// Adds a TextWriter to the log using the default line formatting.
        /// </summary>
        /// <param name="writer">The TextWriter to add.</param>
        public static void AddWriter(TextWriter writer)
        {
            InstallerLog.AddWriter(writer, InstallerLog.DefaultLineFormat);
        }
        /// <summary>
        /// Adds a TextWriter to the log.
        /// </summary>
        /// <param name="stream">The TextWriter to add.</param>
        /// <param name="lineFormat">The line formatting string to use when writing to the stream.</param>
        public static void AddWriter(TextWriter writer, String lineFormat)
        {
            if (!InstallerLog._writers.ContainsKey(writer))
                InstallerLog._writers.Add(writer, lineFormat);
        }

        /// <summary>
        /// Removes a writer from the log and closes it.
        /// </summary>
        public static void RemoveWriter(TextWriter writer)
        {
            InstallerLog.RemoveWriter(writer, true);
        }
        /// <summary>
        /// Removes a writer from the log.
        /// </summary>
        public static void RemoveWriter(TextWriter writer, Boolean close)
        {
            if (close)
                writer.Dispose();

            InstallerLog._writers.Remove(writer);
        }

        /// <summary>
        /// Removes all writers from the log.
        /// </summary>
        public static void RemoveAllWriters()
        {
            InstallerLog.RemoveAllWriters(true);
        }
        /// <summary>
        /// Removes all writers from the log.
        /// </summary>
        public static void RemoveAllWriters(Boolean close)
        {
            if (close)
            {
                foreach (KeyValuePair<TextWriter, String> writer in InstallerLog._writers)
                    writer.Key.Dispose();
            }

            InstallerLog._writers.Clear();
        }

        /// <summary>
        /// Writes an object to all registered output streams.
        /// </summary>
        /// <param name="str">The String to write.</param>
        public static void Write(Object value)
        {
            foreach (KeyValuePair<TextWriter, String> writer in InstallerLog._writers)
            {
                try
                {
                    writer.Key.Write(value.ToString());
                }
                catch { }
            }
        }

        /// <summary>
        /// Writes a line to all registered output streams using the associated line formatting.
        /// </summary>
        /// <param name="value">The line to write.</param>
        public static void WriteLine(Object value)
        {
            foreach (KeyValuePair<TextWriter, String> writer in InstallerLog._writers)
            {
                try
                {
                    writer.Key.WriteLine(writer.Value, value.ToString(), DateTime.Now.ToString());
                }
                catch { }
            }
        }
    }
}