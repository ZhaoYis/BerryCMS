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

            //Bootstrap组件
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Content/scripts/bootstrap/bootstrap.min.js"));
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/scripts/bootstrap/bootstrap.min.css"
                      , "~/Content/styles/font-awesome.min.css"));

            //工具集
            bundles.Add(new ScriptBundle("~/bundles/utils").Include(
                "~/Content/scripts/plugins/cookie/jquery.cookie.js"
                , "~/Content/scripts/plugins/jquery.md5.js"
                , "~/Content/scripts/utils/berry-ajax.js"
                , "~/Content/scripts/utils/berry-ui.js"));

            //jqgrid
            bundles.Add(new ScriptBundle("~/bundles/jqgrid/js").Include(
                "~/Content/scripts/plugins/jqgrid/jqgrid.min.js"
                , "~/Content/scripts/plugins/jqgrid/grid.locale-cn.js"));
            bundles.Add(new StyleBundle("~/bundles/jqgrid/css").Include("~/Content/scripts/plugins/jqgrid/jqgrid.css"));

            //树形组件
            bundles.Add(new ScriptBundle("~/bundles/tree/js").Include("~/Content/scripts/plugins/tree/tree.js"));
            bundles.Add(new StyleBundle("~/bundles/tree/css").Include("~/Content/scripts/plugins/tree/tree.css"));

        }
    }
}
