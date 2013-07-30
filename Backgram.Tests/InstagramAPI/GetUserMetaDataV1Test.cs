using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgram.InstagramApi;

namespace Backgram.Tests.InstagramAPI
{
    [TestClass]
    public class GetUserMetaDataV1Test
    {
        [TestMethod]
        public void TestGet()
        {
            GetUserMetaDataV1 getUserMetadataV1 = new GetUserMetaDataV1();

            var result = getUserMetadataV1.Get();

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}
