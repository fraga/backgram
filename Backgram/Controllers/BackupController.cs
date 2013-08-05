using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Backgram.Core.Api;

namespace Backgram.Controllers
{
    public class BackupController : Controller
    {
        private Instagram _instagram;

        protected void InitializeInstagram()
        {
            _instagram = new Instagram();
            _instagram.BaseCatalogDirectory = AppDomain.CurrentDomain.RelativeSearchPath;
            _instagram.ImportAssemblyCatalog();
        }

        public ActionResult Do()
        {
            if (Session != null && (string.IsNullOrEmpty(Session.SessionID) || string.IsNullOrEmpty(Session["accessToken"].ToString())))
                return View("");

            InitializeInstagram();

            return View();
        }

    }
}
