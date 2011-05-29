using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;

namespace ScriptCenterTest
{
    [TestClass]
    public class ScriptVersionNumberTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            ScriptVersionNumber version = new ScriptVersionNumber(2, 5, 3);
            version.ReleaseStage = ScriptReleaseStage.Alpha;
            Assert.AreEqual("2.5.3 alpha", version.ToString());

            version.ReleaseStage = ScriptReleaseStage.Beta;
            Assert.AreEqual("2.5.3 beta", version.ToString());

            version.ReleaseStage = ScriptReleaseStage.Release;
            Assert.AreEqual("2.5.3", version.ToString());
        }

        [TestMethod]
        public void FromStringTest()
        {
            ScriptVersionNumber version = new ScriptVersionNumber("2.5.3 alpha");
            Assert.AreEqual(version.Major, 2);
            Assert.AreEqual(version.Minor, 5);
            Assert.AreEqual(version.Revision, 3);
            Assert.AreEqual(version.ReleaseStage, ScriptReleaseStage.Alpha);

            version = new ScriptVersionNumber("2.5.3 beta");
            Assert.AreEqual(version.Major, 2);
            Assert.AreEqual(version.Minor, 5);
            Assert.AreEqual(version.Revision, 3);
            Assert.AreEqual(version.ReleaseStage, ScriptReleaseStage.Beta);

            version = new ScriptVersionNumber("2.5.3");
            Assert.AreEqual(version.Major, 2);
            Assert.AreEqual(version.Minor, 5);
            Assert.AreEqual(version.Revision, 3);
            Assert.AreEqual(version.ReleaseStage, ScriptReleaseStage.Release);

            version = new ScriptVersionNumber("2.5.3 release");
            Assert.AreEqual(version.Major, 2);
            Assert.AreEqual(version.Minor, 5);
            Assert.AreEqual(version.Revision, 3);
            Assert.AreEqual(version.ReleaseStage, ScriptReleaseStage.Release);

            version = new ScriptVersionNumber("2");
            Assert.AreEqual(version.Major, 2);

            version = new ScriptVersionNumber("2.5");
            Assert.AreEqual(version.Major, 2);
            Assert.AreEqual(version.Minor, 5);

            try
            {
                version = new ScriptVersionNumber("2..something");
                Assert.Fail("Supplying incorrect version string should throw exception.");
            }
            catch (ArgumentException e) { }
        }

        [TestMethod]
        public void CompareToTest()
        {
            ScriptVersionNumber a = new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta);

            Assert.AreEqual(0, a.CompareTo(new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta)));
            Assert.AreEqual(1, a.CompareTo(new ScriptVersionNumber(1, 3, 6, ScriptReleaseStage.Beta)));
            Assert.AreEqual(-1, a.CompareTo(new ScriptVersionNumber(3, 3, 6, ScriptReleaseStage.Beta)));

            Assert.AreEqual(1, a.CompareTo(new ScriptVersionNumber(2, 2, 6, ScriptReleaseStage.Beta)));
            Assert.AreEqual(-1, a.CompareTo(new ScriptVersionNumber(2, 4, 6, ScriptReleaseStage.Beta)));

            Assert.AreEqual(1, a.CompareTo(new ScriptVersionNumber(2, 3, 5, ScriptReleaseStage.Beta)));
            Assert.AreEqual(-1, a.CompareTo(new ScriptVersionNumber(2, 3, 7, ScriptReleaseStage.Beta)));

            Assert.AreEqual(1, a.CompareTo(new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Alpha)));
            Assert.AreEqual(-1, a.CompareTo(new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Release)));
        }

        [TestMethod]
        public void OperatorsTest()
        {
            ScriptVersionNumber a = new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta);

            //Smaller than operator.
            Assert.IsTrue(a < new ScriptVersionNumber(3, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsTrue(a < new ScriptVersionNumber(2, 4, 6, ScriptReleaseStage.Beta));
            Assert.IsTrue(a < new ScriptVersionNumber(2, 3, 7, ScriptReleaseStage.Beta));
            Assert.IsTrue(a < new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Release));
            Assert.IsFalse(a < new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsFalse(a < new ScriptVersionNumber(1, 3, 6, ScriptReleaseStage.Beta));

            //Smaller than / equals operator.
            Assert.IsTrue(a <= new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsTrue(a <= new ScriptVersionNumber(3, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsFalse(a <= new ScriptVersionNumber(1, 3, 6, ScriptReleaseStage.Beta));

            //Larger than operator.
            Assert.IsTrue(a > new ScriptVersionNumber(1, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsTrue(a > new ScriptVersionNumber(2, 2, 6, ScriptReleaseStage.Beta));
            Assert.IsTrue(a > new ScriptVersionNumber(2, 3, 5, ScriptReleaseStage.Beta));
            Assert.IsTrue(a > new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Alpha));
            Assert.IsFalse(a > new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsFalse(a > new ScriptVersionNumber(3, 3, 6, ScriptReleaseStage.Beta));

            //Larger than / equals operator.
            Assert.IsTrue(a >= new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsTrue(a >= new ScriptVersionNumber(1, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsFalse(a >= new ScriptVersionNumber(3, 3, 6, ScriptReleaseStage.Beta));

            //Equality operator.
            Assert.IsTrue(a == new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsFalse(a == new ScriptVersionNumber(1, 3, 6, ScriptReleaseStage.Beta));

            //Inequality operator.
            Assert.IsTrue(a != new ScriptVersionNumber(1, 3, 6, ScriptReleaseStage.Beta));
            Assert.IsFalse(a != new ScriptVersionNumber(2, 3, 6, ScriptReleaseStage.Beta));
        }
    }
}