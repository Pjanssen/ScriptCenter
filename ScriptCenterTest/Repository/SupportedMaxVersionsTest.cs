using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;

namespace ScriptCenterTest.Repository
{
    [TestClass]
    public class SupportedMaxVersionsTest
    {
        [TestMethod]
        public void ValueObjectTest()
        {
            SupportedMaxVersions vA = new SupportedMaxVersions(2009, 2010);
            SupportedMaxVersions vB = new SupportedMaxVersions(2009, 2010);
            SupportedMaxVersions vC = new SupportedMaxVersions(2012);

            Assert.IsTrue(vA.Equals(vB), "Same versions should be equal.");
            Assert.IsFalse(vA.Equals(vC), "Different versions should not be equal.");
            Assert.AreEqual(vA.GetHashCode(), vB.GetHashCode(), "Hash codes of same versions should be equal.");
        }

        [TestMethod]
        public void ToStringTest()
        {
            SupportedMaxVersions v = SupportedMaxVersions.All;
            Assert.AreEqual("2008+", v.ToString(), "ToString method for all versions.");

            v = new SupportedMaxVersions(2010);
            Assert.AreEqual("2010", v.ToString(), "ToString with single supported version.");

            v = new SupportedMaxVersions(2009, 2010);
            Assert.AreEqual("2009-2010", v.ToString(), "ToString method for version range.");

            v = new SupportedMaxVersions(SupportedMaxVersions.NoBound, 2010);
            Assert.AreEqual("2008-2010", v.ToString(), "ToString method for no lower bound.");

            v = new SupportedMaxVersions(2010, SupportedMaxVersions.NoBound);
            Assert.AreEqual("2010+", v.ToString(), "ToString method for no upper bound.");
        }

        [TestMethod]
        public void FromStringTest()
        {
            SupportedMaxVersions v = new SupportedMaxVersions("2008+");
            Assert.AreEqual(SupportedMaxVersions.All, v, "All");

            v = new SupportedMaxVersions("2008");
            Assert.AreEqual(new SupportedMaxVersions(2008), v, "2008");

            v = new SupportedMaxVersions("2009-2011");
            Assert.AreEqual(new SupportedMaxVersions(2009, 2011), v, "2009-2011");

            v = new SupportedMaxVersions("2009+");
            Assert.AreEqual(new SupportedMaxVersions(2009, SupportedMaxVersions.NoBound), v, "2009+");

            v = new SupportedMaxVersions("2008-2010");
            Assert.AreEqual(new SupportedMaxVersions(SupportedMaxVersions.NoBound, 2010), v, "2008-2010");
        }

        [TestMethod]
        public void IncludesTest()
        {
            SupportedMaxVersions v = new SupportedMaxVersions(2008, 2010);
            Assert.IsTrue(v.Includes(new SupportedMaxVersions(2009)), "2009 should be included");
            Assert.IsFalse(v.Includes(new SupportedMaxVersions(2011)), "2011 should not be included");

            v = SupportedMaxVersions.All;
            Assert.IsTrue(v.Includes(new SupportedMaxVersions(2009)), "All should include 2009");
            Assert.IsTrue(v.Includes(new SupportedMaxVersions(2020)), "All should include 2020");
        }

        [TestMethod]
        public void LowerUpperBoundTest()
        {
            SupportedMaxVersions v = new SupportedMaxVersions(2009, 2011);
            Assert.AreEqual(2009, v.LowerBound, "Lower bound.");
            Assert.AreEqual(2011, v.UpperBound, "Upper bound.");
        }
    }
}
