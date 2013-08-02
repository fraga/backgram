using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Backgram.Core.Api;

namespace Backgram.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Auth/

        public ActionResult Index()
        {
            return View();
        }

        public RedirectToRouteResult RedirectUri()
        {
            var code = this.GetCode(this.Request);
            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("Error", this.Request.Params);
            }

            var accessToken = GetAccessToken(this.Request);
            if (string.IsNullOrEmpty(accessToken))
            {
                return RedirectToAction("Error", this.Request.Params);
            }
            else
            {
                this.StoreAccessToken(accessToken, this.Request, this.Response);
                return RedirectToAction("List", "Library");
            }
        }

        private string GetCode(HttpRequestBase request)
        {
            return request.Params["code"];
        }

        private string GetAccessToken(HttpRequestBase request)
        {
            InstagramData data = new InstagramData
            {
                ClientId = "5c66b3716ea04b598ff6639ed7f09784",
                ClientSecret = "c39b6fa963b24c02b7de3d7401872c5f",
                RedirectURI = this.Url.Action("RedirectUri", null, null, request.Url.Scheme),
                Code = GetCode(request)
            };

            Instagram instagram = new Instagram();
            return instagram.AuthorizeTokenRequest(data);
        }

        private void StoreAccessToken(string accessToken, HttpRequestBase request, HttpResponseBase response)
        {
            Session.Add("accessToken", accessToken);

            var cookieKey = "access_token";
            var cookie = new HttpCookie(cookieKey, accessToken);
            if (request.Cookies[cookieKey] == null)
            {
                response.Cookies.Add(cookie);
            }
            else if(string.IsNullOrEmpty(request.Cookies[cookieKey].Value))
            {
                response.Cookies.Set(cookie);
            }
        }
    }
}
