using System.Web;
using System.Web.Optimization;

namespace GieAndVince
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/themes/le-frog/css/").Include(
                        "~/Content/themes/le-frog/jquery.ui.css",
                        "~/Content/themes/le-frog/jquery.ui.button.css",
                        "~/Content/themes/le-frog/jquery.ui.core.css",
                        "~/Content/themes/le-frog/jquery.ui.datepicker.css",
                        "~/Content/themes/le-frog/jquery.ui.dialog.css",
                        "~/Content/themes/le-frog/jquery.ui.menu.css",
                        "~/Content/themes/le-frog/jquery.ui.progressbar.css",
                        "~/Content/themes/le-frog/jquery.ui.resizable.css",
                        "~/Content/themes/le-frog/jquery.ui.selectable.css",
                        "~/Content/themes/le-frog/jquery.ui.slider.css",
                        "~/Content/themes/le-frog/jquery.ui.spinner.css",
                        "~/Content/themes/le-frog/jquery.ui.tabs.css",
                        "~/Content/themes/le-frog/jquery.ui.theme.css",
                        "~/Content/themes/le-frog/jquery.ui.tooltip.css"
                        ));
        }
    }
}
