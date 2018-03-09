using System.Web;
using System.Web.Optimization;

namespace BerryCMS
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/scripts/jquery/jquery-{version}.js"));
            //bootstrap JS
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Content/scripts/bootstrap/bootstrap.min.js"));
            //bootstrap CSS
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/scripts/bootstrap/bootstrap.min.css"
                      , "~/Content/styles/font-awesome.min.css"));
            //JS工具集
            bundles.Add(new ScriptBundle("~/bundles/utils").Include(
                "~/Content/scripts/plugins/cookie/jquery.cookie.js"
                , "~/Content/scripts/plugins/jquery.md5.js"
                , "~/Content/scripts/utils/berry-ajax.js"
                , "~/Content/scripts/utils/berry-ui.js"));

        }
    }
}
