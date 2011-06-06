﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Utils
{
    internal class TestClass
    {
        [DefaultValue(2)]
        public Int32 anInteger { get; set; }

        [DefaultValue("StringValue")]
        public String aString { get; set; }

        #pragma warning disable 0649
        [DefaultValue("test")]
        private String aPrivateProperty;
        #pragma warning restore 0649

        public String APrivatePropertyAccessor
        {
            get { return aPrivateProperty; }
        }
    }

    [TestClass]
    public class ObjectSetDefaultValuesTest
    {
        [TestMethod]
        public void SetDefaultValuesTest()
        {
            TestClass t = new TestClass();
            Assert.AreEqual(default(Int32), t.anInteger);
            Assert.IsNull(t.aString);
            Assert.IsNull(t.APrivatePropertyAccessor);
            t.SetDefaultValues();
            Assert.AreEqual(2, t.anInteger);
            Assert.AreEqual("StringValue", t.aString);
            Assert.AreEqual("test", t.APrivatePropertyAccessor);
        }
    }
}
