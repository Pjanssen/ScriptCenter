using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ScriptCenter.Repository
{
    [Serializable]
    [JsonConverter(typeof(ScriptCenter.Utils.StringJsonConverter))]
    public class ScriptId
    {
        public static readonly ScriptId Empty = new ScriptId(String.Empty);
        private String _id;

        /// <summary>
        /// Initializes a new ScriptId.
        /// </summary>
        /// <param name="id">The script id.</param>
        public ScriptId(String id) 
        {
            _id = id;
        }

        /// <summary>
        /// Initializes a new ScriptId.
        /// </summary>
        /// <param name="scriptName">The name of the script.</param>
        /// <param name="authorName">The author of the script.</param>
        public ScriptId(String scriptName, String authorName)
        {
            StringBuilder idBuilder = new StringBuilder();
            idBuilder.Append(Regex.Replace(authorName.ToLower(), @"\s", ""));
            idBuilder.Append('.');
            idBuilder.Append(Regex.Replace(scriptName.ToLower(), @"\s", ""));
            _id = idBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is ScriptId) && _id.Equals(((ScriptId)obj)._id);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override string ToString()
        {
            return _id;
        }
    }
}
