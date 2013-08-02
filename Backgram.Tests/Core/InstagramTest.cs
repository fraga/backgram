using Backgram.Core.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.Tests.Core
{
    [TestClass]
    public class InstagramTest
    {
        [TestMethod]
        public void AssertIsNotNull()
        {
            Instagram instagram = new Instagram();
            Assert.IsNotNull(instagram);
        }

        [TestMethod]
        public void TestCatalogShouldHookAssembly()
        {
            Instagram instagram = new Instagram();
            Assert.IsNotNull(instagram.InstagramEndpoints);
        }

        [TestMethod]
        public void TestCatalogShouldLoadClasses()
        {
            Instagram instagram = new Instagram();
            instagram.ImportAssemblyCatalog();

            foreach (Lazy<IInstagramEndpoint, IInstagramEndPointData> endpoint in instagram.InstagramEndpoints)
            {
                Assert.IsNotNull(endpoint.Value);
                Assert.IsNotNull(endpoint.Metadata.Version);
            }

        }
    }
}
