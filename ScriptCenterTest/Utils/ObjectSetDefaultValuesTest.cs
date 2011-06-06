using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Utils
{
    [TestClass]
    public class ObjectSetDefaultValuesTest
    {
        private class TestClass
        {
            [DefaultValue(2)]
            public Int32 anInteger { get; set; }

            [DefaultValue("StringValue")]
            public String aString { get; set; }
        }

        [TestMethod]
        public void SetDefaultValuesTest()
        {
            TestClass t = new TestClass();
            Assert.AreEqual(default(Int32), t.anInteger);
            Assert.IsNull(t.aString);
            t.SetDefaultValues();
            Assert.AreEqual(2, t.anInteger);
            Assert.AreEqual("StringValue", t.aString);
        }
    }
}
