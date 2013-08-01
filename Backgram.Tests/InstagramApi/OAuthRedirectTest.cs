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
    public class OAuthRedirectTest
    {
        [TestMethod]
        public void TestOAuthRedirectConstructor()
        {
            OAuthRedirect auth = new OAuthRedirect();
            Assert.IsNotNull(auth);
        }

        [TestMethod]
        public void TestOAuthRedirectInstagramDataIsNotNull()
        {
            OAuthRedirect auth = new OAuthRedirect();
            Assert.IsNotNull(auth);
            Assert.IsNotNull(auth.InstagramData);
        }

        [TestMethod]
        public void TestOAuthRedirectGet()
        {
            OAuthRedirect auth = new OAuthRedirect();
            InstagramData data = new InstagramData { ClientId = "client_id", ClientSecret = "client_secret", RedirectURI = "redirect_uri", ResponseType = "token" };

            auth.InstagramData = data;
            var result = auth.Get();

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

    }
}
