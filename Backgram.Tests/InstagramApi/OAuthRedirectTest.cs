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
    public class OAuthAuthorizeCode
    {
        [TestMethod]
        public void TestOAuthAuthorizeCodeConstructor()
        {
            OAuthAuthorizeCode auth = new OAuthAuthorizeCode();
            Assert.IsNotNull(auth);
        }

    }
}
