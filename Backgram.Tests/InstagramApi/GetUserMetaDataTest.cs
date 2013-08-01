using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgram.InstagramApi;
using Backgram.Core.Api;

namespace Backgram.Tests.InstagramApi
{
    [TestClass]
    public class GetUserMetaDataTest
    {
        [TestMethod]
        public void TestUserMetadataConstructor()
        {
            GetUserMetaData getUserMetadata = new GetUserMetaData();
            Assert.IsNotNull(getUserMetadata);
        }

        [TestMethod]
        public void TestUserMetadataInstagramDataNotNull()
        {
            GetUserMetaData getUserMetadata = new GetUserMetaData();
            Assert.IsNotNull(getUserMetadata);
            Assert.IsNotNull(getUserMetadata.InstagramData);
        }

        [TestMethod]
        public void TestUserMetadataHasAnEndPoint()
        {
            GetUserMetaData getUserMetadata = new GetUserMetaData();
            Assert.AreEqual("https://api.instagram.com/v1/users/self", getUserMetadata.EndPoint);
        }

        [TestMethod]
        public void TestUserMetadataGet()
        {
            GetUserMetaData getUserMetadata = new GetUserMetaData();
            getUserMetadata.InstagramData.AccessToken = "32714411.1fb234f.65b186d31bff441f924ef3386e65eb69";
            var result = getUserMetadata.Get();

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestUserMetadataPost()
        {
            GetUserMetaData getuserMetadata = new GetUserMetaData();
            getuserMetadata.Post();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestUserMetadataPut()
        {
            GetUserMetaData getuserMetadata = new GetUserMetaData();
            getuserMetadata.Put();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestUserMetadataDelete()
        {
            GetUserMetaData getuserMetadata = new GetUserMetaData();
            getuserMetadata.Delete();
        }


    }
}
