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
    }
}