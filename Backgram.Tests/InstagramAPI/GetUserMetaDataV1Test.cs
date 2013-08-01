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
        public void TestUserMetadataGet()
        {
            GetUserMetaDataV1 getUserMetadataV1 = new GetUserMetaDataV1();
            getUserMetadataV1.AccessToken = "32714411.1fb234f.65b186d31bff441f924ef3386e65eb69";
            var result = getUserMetadataV1.Get();

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestUserMetadataPost()
        {
            GetUserMetaDataV1 getuserMetadataV1 = new GetUserMetaDataV1();
            getuserMetadataV1.Post();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestUserMetadataPut()
        {
            GetUserMetaDataV1 getuserMetadataV1 = new GetUserMetaDataV1();
            getuserMetadataV1.Put();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestUserMetadataDelete()
        {
            GetUserMetaDataV1 getuserMetadataV1 = new GetUserMetaDataV1();
            getuserMetadataV1.Delete();
        }


    }
}
