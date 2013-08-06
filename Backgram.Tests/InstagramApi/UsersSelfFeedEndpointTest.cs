using Backgram.Core.Api;
using Backgram.InstagramApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.Tests.InstagramApi
{
    [TestClass]
    public class UsersSelfFeedEndpointTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            UsersSelfFeedEndpoint endpoint = new UsersSelfFeedEndpoint();
            Assert.IsNotNull(endpoint);
        }

        [TestMethod]
        public void TestGetShouldGetUsersFeed()
        {
            UsersSelfFeedEndpoint endpoint = new UsersSelfFeedEndpoint();
            endpoint.InstagramData.AccessToken = "32714411.1fb234f.65b186d31bff441f924ef3386e65eb69";
            var meta = new { meta = new { code = "" } };
            
            var result = endpoint.Get();

            var parsedResult = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(result, meta);

            Assert.AreEqual(parsedResult.meta.code, "200");
        }
    }
}
