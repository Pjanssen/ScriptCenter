using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCenter.Repository;
using ScriptCenter.Utils;

namespace ScriptCenterTest.Repository
{
[TestClass]
public class ManifestTokensTest
{
    [TestMethod]
    public void ReplaceTokensTest()
    {
        ScriptManifest manifest = new ScriptManifest();
        manifest.Id = "pierjanssen.outliner";
        manifest.Author = "Pier Janssen";
        manifest.Name = "Outliner";
        manifest.Versions.Add(new ScriptVersion(2, 9, 4));

        String origString = ScriptManifestTokens.Id_Token + " something " + ScriptManifestTokens.Name_Token + " " + ScriptManifestTokens.Id_Token;
        String exptectedString = manifest.Id + " something " + manifest.Name + " " + manifest.Id;
        Assert.AreEqual(exptectedString, ScriptManifestTokens.Replace(origString, manifest));

        origString = ScriptManifestTokens.Version_Token + " something " + ScriptManifestTokens.Author_Token;
        exptectedString = manifest.Versions[0].VersionNumber.ToString() + " something " + manifest.Author;
        Assert.AreEqual(exptectedString, ScriptManifestTokens.Replace(origString, manifest));

        origString = ScriptManifestTokens.VersionMajor_Token + " " + ScriptManifestTokens.VersionMinor_Token + " " + ScriptManifestTokens.VersionRevision_Token + " " + ScriptManifestTokens.VersionStage_Token;
        exptectedString = manifest.Versions[0].VersionNumber.Major + " " + manifest.Versions[0].VersionNumber.Minor + " " + manifest.Versions[0].VersionNumber.Revision + " " + manifest.Versions[0].VersionNumber.ReleaseStage.ToString().ToLower();
        Assert.AreEqual(exptectedString, ScriptManifestTokens.Replace(origString, manifest));
    }
}
}
