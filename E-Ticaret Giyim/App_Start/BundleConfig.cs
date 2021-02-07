using System.Web;
using System.Web.Optimization;

namespace E_Ticaret_Giyim
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            
            #region Admin Layout

            bundles.Add(new ScriptBundle("~/bundles/adminScript").Include(
                      "~/Content/Admin/admin_paneli/vendor/jquery/jquery.min.js",
                      "~/Content/Admin/admin_paneli/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Content/Admin/admin_paneli/vendor/metisMenu/metisMenu.min.js",
                      "~/Content/Admin/admin_paneli/vendor/raphael/raphael.min.js",
                      "~/Content/Admin/admin_paneli/dist/js/sb-admin-2.js"));

            bundles.Add(new StyleBundle("~/Content/adminStyle/css").Include(
                      "~/Content/Admin/admin_paneli/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/Admin/admin_paneli/vendor/metisMenu/metisMenu.min.css",
                      "~/Content/Admin/admin_paneli/dist/css/sb-admin-2.css",
                      "~/Content/Admin/admin_paneli/vendor/font-awesome/css/font-awesome.min.css"));

            #endregion
        }
    }
}
