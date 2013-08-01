using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgram.InstagramApi;

namespace Backgram.Tests.InstagramApi
{
    [TestClass]
    public class GetUserMetaDataV1Test
    {
        [TestMethod]
        public void TestGet()
        {
            GetUserMetaDataV1 getUserMetadataV1 = new GetUserMetaDataV1();
            getUserMetadataV1.AccessToken = "32714411.1fb234f.65b186d31bff441f924ef3386e65eb69";
            var result = getUserMetadataV1.Get();

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}
