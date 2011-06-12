using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;

namespace ScriptCenterTest.Repository
{
    [TestClass]
    public class ScriptIdTest
    {
        [TestMethod]
        public void ValueObjectTest()
        {
            String idString = "pierjanssen.outliner";
            ScriptId idA = new ScriptId(idString);
            ScriptId idB = new ScriptId(idString);
            ScriptId idC = new ScriptId("anotherperson.anotherscript");
            Assert.AreEqual(idString, idA.ToString(), "ToString method.");
            Assert.IsTrue(idA.Equals(idB), "Same id's should be equal.");
            Assert.IsFalse(idA.Equals(idC), "Different id's should not be equal.");
            Assert.AreEqual(idA.GetHashCode(), idB.GetHashCode(), "Hash codes of same id's should be equal.");
        }

        [TestMethod]
        public void AuthorScriptNameConstructorTest()
        {
            ScriptId expectedId = new ScriptId("pierjanssen.outliner");
            ScriptId id = new ScriptId("Outliner", "Pier Janssen");
            Assert.AreEqual(expectedId, id, "Id constructed from author and script name.");
        }

        [TestMethod]
        public void EmptyTest()
        {
            ScriptId expectedId = new ScriptId("");
            Assert.AreEqual(expectedId, ScriptId.Empty, "Empty ScriptId");
        }
    }
}
