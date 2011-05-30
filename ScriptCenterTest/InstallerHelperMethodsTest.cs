using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;
using ScriptCenter.Installer;

namespace ScriptCenterTest
{
    [TestClass]
    public class InstallerHelperMethodsTest
    {
        [TestMethod]
        public void ReplaceTokensTest()
        {
            ScriptManifest manifest = new ScriptManifest();
            manifest.Id = "pierjanssen.outliner";
            manifest.Author = "Pier Janssen";
            manifest.Name = "Outliner";
            manifest.Versions.Add(new ScriptVersion(2, 9, 4));

            String origString = InstallerHelperMethods.Id_Token + " something " + InstallerHelperMethods.Name_Token + " " + InstallerHelperMethods.Id_Token;
            String exptectedString = manifest.Id + " something " + manifest.Name + " " + manifest.Id;
            Assert.AreEqual(exptectedString, InstallerHelperMethods.ReplaceTokens(origString, manifest));

            origString = InstallerHelperMethods.Version_Token + " something " + InstallerHelperMethods.Author_Token;
            exptectedString = manifest.Versions[0].VersionNumber.ToString() + " something " + manifest.Author;
            Assert.AreEqual(exptectedString, InstallerHelperMethods.ReplaceTokens(origString, manifest));

            origString = InstallerHelperMethods.VersionMajor_Token + " " + InstallerHelperMethods.VersionMinor_Token + " " + InstallerHelperMethods.VersionRevision_Token + " " + InstallerHelperMethods.VersionStage_Token;
            exptectedString = manifest.Versions[0].VersionNumber.Major + " " + manifest.Versions[0].VersionNumber.Minor + " " + manifest.Versions[0].VersionNumber.Revision + " " + manifest.Versions[0].VersionNumber.ReleaseStage.ToString().ToLower();
            Assert.AreEqual(exptectedString, InstallerHelperMethods.ReplaceTokens(origString, manifest));
        }
    }
}
