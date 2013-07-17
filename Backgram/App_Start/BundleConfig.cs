using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Backgram
{
    public class BundleConfig
    {
        public const string BundlesJs   = "~/bundles/js";
        public const string BundlesCss  = "~/bundles/css";

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(BundleConfig.BundlesJs)
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/backgram.js")
                .Include("~/Scripts/backgram_tools.js")
                .Include("~/Scripts/backgram_instagram.js"));

            bundles.Add(new StyleBundle(BundleConfig.BundlesCss)
                .Include("~/Content/css/bootstrap.css")
                .Include("~/Content/css/bootstrap-responsive.css")
                .Include("~/Content/css/backgram.css"));
        }
    }
}