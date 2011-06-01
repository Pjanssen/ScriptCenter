using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;
using ScriptCenter.Project;
using System.IO;

namespace ScriptCenterTest.Project
{
    [TestClass]
    public class ScriptCenterProjectTest
    {
        private static String outputDir = TestHelperMethods.GetOutputDirectory() + "ScriptCenterProject/";

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            if (Directory.Exists(outputDir))
                Directory.Delete(outputDir, true);
        }


    }
}
