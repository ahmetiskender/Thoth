using System.Web.Mvc;

namespace Thoth.Web.UI.Helper
{
    public class ViewEngine : RazorViewEngine
    {

        private static string[] AppViewLocationFormats = new[]
        {
            "~/Views/Protected/{0}.cshtml",
            "~/Views/Protected/{1}/{0}.cshtml",
            "~/Views/Protected/References/{0}.cshtml",
            "~/Views/Protected/References/{1}/{0}.cshtml"
        };
        private static string[] AppPartialViewLocationFormats = new[]
        {
            "~/Views/Shared/Layout/LTR/{0}.cshtml",
            "~/Views/Shared/Common/{0}.cshtml",
            "~/Views/Protected/{0}.cshtml",
            "~/Views/Protected/{1}/{0}.cshtml"
        };


        public ViewEngine()
        {
            base.ViewLocationFormats = AppViewLocationFormats;
            base.PartialViewLocationFormats = AppPartialViewLocationFormats;
        }


    }
}
