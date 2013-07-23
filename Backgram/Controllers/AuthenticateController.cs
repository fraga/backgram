using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backgram.Controllers
{
    public class AuthenticateController : Controller
    {
        //
        // GET: /Authenticate/

        public ActionResult Index()
        {
            return View();
        }

        public RedirectToRouteResult RedirectUri()
        {
            var accessToken = this.GetAccessToken(this.Request);

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

        private string GetAccessToken(HttpRequestBase request)
        {
            return request.Params["access_token"];
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
