using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backgram.Core.Util;
using System.Text.RegularExpressions;

namespace Backgram.Tests.Core.Util
{
    [TestClass]
    public class AssemblyUtilTest
    {
        [TestMethod]
        public void GetVersionTest()
        {
            Assert.IsFalse(String.IsNullOrEmpty(AssemblyUtil.GetVersion()));
        }

        [TestMethod]
        public void GetVersionHasVersionStructureTest()
        {
            Assert.IsTrue(Regex.IsMatch(AssemblyUtil.GetVersion(), @"[0-9][.][0-9][.][0-9?]+[.][0-9]+"));
        }
    }
}
