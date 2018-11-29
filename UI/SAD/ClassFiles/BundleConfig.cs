using System.Configuration;
using System.Web.Optimization;

namespace UI.ClassFiles
{
    public class BundleConfig
    {
        private static bool? _bundlingActive;
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;  
            CreateBundle_Scripts(bundles);
            CreateBundle_CSS(bundles);
        }
        public static bool BundlingActive
        {
            get
            {
                if (!_bundlingActive.HasValue)
                    _bundlingActive = ConfigurationManager.AppSettings["BundlingActive"] == "1";
                return _bundlingActive.Value;
            }
        }

        public static void CreateBundle_Scripts(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Content/Bundle/menuJS").Include(
                                                                                "~/Content/JS/XP.js",
                                                                                "~/Content/JS/scroll_controls.js",
                                                                                "~/Content/JS/dw_event.js",
                                                                                "~/Content/JS/dw_scroll.js",
                                                                                "~/Content/JS/analytics.js"
                                                                            ));



            bundles.Add(new ScriptBundle("~/Content/Bundle/jqueryJS").Include(
                                                                                "~/Content/JS/JQUERY/jquery-1.7.2.min.js",
                                                                                "~/Content/JS/JQUERY/jquery-ui-1.8.22.custom.min.js",
                                                                                "~/Content/JS/JQUERY/jquery.ui.ufd.js",
                                                                                "~/Content/JS/datepickr.min.js",
                                                                                "~/Content/JS/jquery.timepicker.js"
                                                                            ));
            bundles.Add(new ScriptBundle("~/Content/updatedJs").Include(
                "~/Content/JS/jquery-3.3.1.js",
                "~/Content/JS/jquery-ui.min.js",
                "~/Content/JS/bootstrap.min.js",
                "~/Content/JS/jquery.timepicker.js",
                "~/Content/JS/toastr.min.js",
                "~/Content/JS/ui-toastr.min.js",
                "~/Content/JS/StaticFunction.js"
            ));


            bundles.Add(new ScriptBundle("~/Content/Bundle/RegisJS").Include(
                                                                                "~/Content/JS/scriptEmployeeReg.js"
                                                                               ));
            bundles.Add(new ScriptBundle("~/Content/Bundle/ProgressJs").Include(
                                                                                "~/Content/JS/datepickr.js",
                                                                                "~/Content/JS/CustomizeScript.js"

                                                                               ));


        }
        public static void CreateBundle_CSS(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/Bundle/defaultCSS").Include(
                                                                                 "~/Content/CSS/Banner.css",
                                                                                 "~/Content/CSS/StyleSheet.css"
                                                                               ));
            bundles.Add(new StyleBundle("~/Content/updatedCss").Include(
                // defaultCSS
                "~/Content/CSS/Banner.css",
                "~/Content/CSS/StyleSheet.css",
                // hrCSS
                "~/Content/CSS/EmpRegStyleSheet.css",
                "~/Content/CSS/Lstyle.css",
                "~/Content/CSS/jquery-ui-1.8.22.custom.css",
                // yeasin new
                "~/Content/CSS/bootstrap.min.css",
                "~/Content/CSS/jquery-ui.min.css",
                "~/Content/CSS/toastr.min.css"
            ));


            bundles.Add(new StyleBundle("~/Content/Bundle/voucherInsertCSS").Include(
                                                                                "~/Content/CSS/AutoComplete.css",
                                                                                "~/Content/CSS/Calender.css",
                                                                                 "~/Content/CSS/Grid.css"
                                                                              ));


            bundles.Add(new StyleBundle("~/Content/Bundle/gridCalanderCSS").Include(

                                                                                "~/Content/CSS/Calender.css",
                                                                                 "~/Content/CSS/Grid.css"
                                                                              ));


            bundles.Add(new StyleBundle("~/Content/Bundle/printCSS").Include(

                                                                                "~/Content/CSS/PrintJournel.css",
                                                                                 "~/Content/CSS/PrintMR.css",
                                                                                 "~/Content/CSS/PrintVoucher.css"
                                                                              ));

            bundles.Add(new StyleBundle("~/Content/Bundle/hrCSS").Include(

                                                                              "~/Content/CSS/EmpRegStyleSheet.css",
                                                                              "~/Content/CSS/Lstyle.css",
                                                                               "~/Content/CSS/jquery-ui-1.8.22.custom.css"

                                                                            ));


            bundles.Add(new StyleBundle("~/Content/Bundle/AutoCompleteCSS").Include(
                                                                               "~/Content/CSS/AutoComplete.css"
                                                                             ));
            bundles.Add(new StyleBundle("~/Content/Bundle/ProgressCSS").Include(
                                                                               "~/Content/CSS/Progress.css", "~/Content/CSS/ProgressJqry.css"
                                                                             ));


        }

    }
}