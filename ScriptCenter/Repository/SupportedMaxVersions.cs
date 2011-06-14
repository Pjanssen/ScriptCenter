using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ScriptCenter.Utils;
using System.Text.RegularExpressions;

namespace ScriptCenter.Repository
{
    [Serializable]
    [JsonConverter(typeof(StringJsonConverter))]
    public class SupportedMaxVersions
    {
        public static readonly SupportedMaxVersions All = new SupportedMaxVersions(NoBound, NoBound);
        public const Int32 NoBound = -1;

        private const Int32 minLowerBound = 2008;
        private const String singleVersionFormat = "{0}";
        private const String rangeFormat = "{0}-{1}";
        private const String noUpperBoundFormat = "{0}+";

        private Int32 _lowerBound;
        private Int32 _upperBound;

        /// <summary>
        /// Initializes a new SupportedMaxVersions object with a single supported version.
        /// </summary>
        /// <param name="version">The supported 3dsmax version.</param>
        public SupportedMaxVersions(Int32 version) : this(version, version) { }

        /// <summary>
        /// Initializes a new SupportedMaxVersions object with a range of supported versions.
        /// </summary>
        /// <param name="lowerBound">The lower bound to be included.</param>
        /// <param name="upperBound">The upper bound to be included.</param>
        public SupportedMaxVersions(Int32 lowerBound, Int32 upperBound)
        {
            if (lowerBound > upperBound && upperBound != SupportedMaxVersions.NoBound)
                throw new ArgumentException("Lower bound must be smaller than or equal to upper bound");

            if (lowerBound < minLowerBound)
                lowerBound = minLowerBound;

            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        /// <summary>
        /// Initializes a new SupportedMaxVersions object from a String.
        /// </summary>
        public SupportedMaxVersions(String versionsString)
        {
            if (Regex.IsMatch(versionsString, @"^\d{4}$")) //matches "2008", "2009", etc.
            {
                _lowerBound = _upperBound = Int32.Parse(versionsString.Substring(0, 4));
            }
            else if (Regex.IsMatch(versionsString, @"^\d{4}[+]$")) //matches "2008+", "2009+", etc.
            {
                _lowerBound = Int32.Parse(versionsString.Substring(0, 4));
                _upperBound = NoBound;
            }
            else if (Regex.IsMatch(versionsString, @"^\d{4}-\d{4}$")) //matches "2008-2010", "2009-2011", etc.
            {
                _lowerBound = Int32.Parse(versionsString.Substring(0, 4));
                _upperBound = Int32.Parse(versionsString.Substring(5, 4));
            }
            else
                throw new ArgumentException("Supplied String was not in the correct format.");
        }

        public Int32 LowerBound
        {
            get { return _lowerBound; }
        }

        public Int32 UpperBound
        {
            get { return _upperBound; }
        }

        /// <summary>
        /// Returns true if the supplied object is within the bounds of this SupportedMaxVersions object.
        /// </summary>
        /// <param name="versions">The SupportedMaxVersions to test for.</param>
        public Boolean Includes(SupportedMaxVersions versions)
        {
            return (_lowerBound <= versions._lowerBound) && ((_upperBound >= versions._upperBound) || (_upperBound == NoBound));
        }



        public override bool Equals(object obj)
        {
            if (!(obj is SupportedMaxVersions))
                return false;

            SupportedMaxVersions compareTo = (SupportedMaxVersions)obj;
            return (compareTo._lowerBound == _lowerBound) && (compareTo._upperBound == _upperBound);
        }

        public override int GetHashCode()
        {
            int hash = 31;
            hash += 7 * _lowerBound;
            hash += 11 * _upperBound;
            return hash;
        }

        public override string ToString()
        {
            if (_lowerBound == _upperBound)
                return String.Format(singleVersionFormat, _lowerBound);

            if (_upperBound == NoBound)
                return String.Format(noUpperBoundFormat, _lowerBound);

            return String.Format(rangeFormat, _lowerBound, _upperBound);
        }
    }
}
