using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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

        //public ActionResult Instagram()
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://api.instagram.com/oauth/authorize/");
        //    var param = string.Format("?client_id={0}&redirect_uri={1}&response_type=code",
        //        "5c66b3716ea04b598ff6639ed7f09784",
        //        Url.Action("RedirectUri", null, null, this.Request.Url.Scheme));

        //    var response = client.GetAsync(param).Result;
        //}

        public async Task<RedirectToRouteResult> RedirectUri()
        {
            var code = this.GetCode(this.Request);
            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("Error", this.Request.Params);
            }

            var accessToken = await this.GetAccessToken(this.Request);
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

        private async Task<string> GetAccessToken(HttpRequestBase request)
        {
            var accessToken = string.Empty;
            var requestUri = new Uri("https://api.instagram.com/oauth/access_token/");
            var client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", "5c66b3716ea04b598ff6639ed7f09784"),
                new KeyValuePair<string, string>("client_secret", "c39b6fa963b24c02b7de3d7401872c5f"),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("redirect_uri", this.Url.Action("RedirectUri", null, null, request.Url.Scheme)),
                new KeyValuePair<string, string>("code", this.GetCode(request))
            };
            var content = new FormUrlEncodedContent(postData);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() =>
            {
                dynamic obj = JObject.Parse(json);
                return obj.access_token;
            });
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
