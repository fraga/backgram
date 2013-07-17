using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Backgram
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/backgram.js")
                .Include("~/Scripts/backgram_tools.js")
                .Include("~/Scripts/backgram_instagram.js"));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/css/bootstrap.css")
                .Include("~/Content/css/bootstrap-responsive.css")
                .Include("~/Content/css/backgram.css"));
        }
    }
}